using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.DocumentManagement.DocumentSets;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using SPVisionet.CorporateSecretary.Common;

namespace SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruIndonesia
{
    public partial class PendirianPerusahaanBaruIndonesiaUserControl : UserControl
    {
        #region Properties

        private const string PIC_CORSEC_UPLOAD_AKTA = Roles.PIC_CORSEC + " Upload Akta";
        private const string PIC_CORSEC_UPLOAD_SKDP = Roles.PIC_CORSEC + " Upload SKDP";
        private const string ACCOUNTING_HEAD_INPUT_COMPANY_CODE = Roles.ACCOUNTING_HEAD + " Input Company Code";
        private const string ACCOUNTING_UPLOAD_APV = Roles.ACCOUNTING + " Upload APV";
        private const string FINANCE_UPLOAD_SETORAN_MODAL = Roles.FINANCE + " Upload Setoran Modal";
        private const string PIC_CORSEC_UPLOAD_SK_PENGESAHAN = Roles.PIC_CORSEC + " Upload SK Pengesahan and BNRI";
        private const string TAX_UPLOAD_NPWP = Roles.TAX + " Upload NPWP";
        private const string TAX_UPLOAD_PKP = Roles.TAX + " Upload PKP";
        private const string APPROVED = "Approved";

        [Serializable]
        private class WewenangDireksi
        {
            public int ID { get; set; }
            public string Nama { get; set; }
        }

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
        }

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
        }

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

        [Serializable]
        private class NPWP
        {
            public int ID { get; set; }
            public string NoNPWP { get; set; }
            public string Keterangan { get; set; }
            public string NamaFile { get; set; }
            public byte[] Attachment { get; set; }
            public string Url { get; set; }
        }

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

        private SPWeb web;
        private int IDP = 0;
        private string Source = string.Empty;
        private string Mode = string.Empty;
        //private Guid ListId = Guid.Empty;

        #endregion

        #region Methods

        private void BindTempatKedudukan(DropDownList ddl)
        {
            DataTable dt = Util.GetTempatKedudukan(web);
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataSource = dt;
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
        }

        private void BindMaksudTujuan(DropDownList ddl)
        {
            DataTable dt = Util.GetMaksudTujuan(web);
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataSource = dt;
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
        }

        private void BindStatusOwnership(DropDownList ddl)
        {
            DataTable dt = Util.GetStatusOwnership(web);
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataSource = dt;
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
        }

        private void BindMataUang(DropDownList ddl)
        {
            DataTable dt = Util.GetMataUang(web);
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataSource = dt;
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
        }

        private void BindStatusPerseroan(DropDownList ddl)
        {
            DataTable dt = Util.GetStatusPerseroan(web);
            ddl.DataTextField = "Title";
            ddl.DataValueField = "ID";
            ddl.DataSource = dt;
            ddl.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddl.Items.Insert(0, item);
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

        private string UpdateSKPengesahan(string RequestCode, string DocumentType)
        {
            if (ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
            {
                if (fuAkte.PostedFile != null)
                {
                    if (fuAkte.PostedFile.ContentLength > 0)
                    {
                        SPListItem item = GetLatestDocument(RequestCode, DocumentType);

                        try
                        {
                            Stream strm = fuAkte.PostedFile.InputStream;
                            byte[] bytes = new byte[Convert.ToInt32(fuAkte.PostedFile.ContentLength)];
                            strm.Read(bytes, 0, Convert.ToInt32(fuAkte.PostedFile.ContentLength));
                            strm.Close();

                            item.File.SaveBinary(bytes);
                            item.File.Update();
                            item.File.Item["DocumentType"] = "Akta and SK Pengesahan Pendirian";
                            item.File.Item.Update();
                        }
                        catch
                        {
                            return SR.AttachmentFailed(item.Title);
                        }
                    }
                }
            }
            return string.Empty;
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

        private SPListItem GetLatestDocument(string RequestCode, string DocumentType)
        {
            SPList documentPendirianPerusahaanBaru = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                             "<And>" +
                                 "<Eq>" +
                                      "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                      "<Value Type='Lookup'>" + IDP + "</Value>" +
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

            SPListItemCollection coll = documentPendirianPerusahaanBaru.GetItems(query);
            if (coll.Count > 0)
                return coll[0];
            return null;
        }

        private void DisplayDocument(Literal ltr, string RequestCode, string DocumentType)
        {
            SPListItem item = GetLatestDocument(RequestCode, DocumentType);
            if (item != null)
                ltr.Text = string.Format("<a href='/PerusahaanBaruDokumen/{0}/{1}'>{1}</a>", RequestCode, item["Name"].ToString());
        }

        private string SaveDocument(FileUpload fu, string RequestCode, string Folder)
        {
            if (fu.PostedFile != null)
            {
                if (fu.PostedFile.ContentLength > 0)
                {
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
                        itemDocument["DocumentType"] = Folder;
                        itemDocument["PerusahaanBaru"] = Convert.ToInt32(ViewState["ID"]);
                        itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemDocument.Update();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("already exist"))
                            return SR.DataIsExist(fileName);
                        else
                            return SR.AttachmentFailed(fileName);
                    }
                }
            }
            return string.Empty;
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();

            //    if (Util.isExistNamaPerusahaan(web, txtNamaPerusahaanDP.Text.Trim()))
            //        sb.Append(SR.DataIsExist("Nama Perusahaan with Name " + txtNamaPerusahaanDP.Text.Trim()) + "\\n");

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty)
            {
                if (txtTujuanPenggunaan.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Tujuan Penggunaan") + " \\n");
                if (txtNamaPemohon.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nama Pemohon") + " \\n");
                if (txtEmailPemohon.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Email Pemohon") + " \\n");
                if (txtNamaPerusahaan.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nama Perusahaan") + " \\n");
                if (ddlTempatKedudukan.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Tempat Kedudukan") + " \\n");
                if (ddlMaksudTujuan.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Maksud dan Tujuan") + " \\n");
                if (ddlStatusOwnership.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Status Ownership") + " \\n");
                if (ddlMataUang.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Mata Uang") + " \\n");

                decimal ModalDasar = 0;
                if (txtModalDasar.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Modal Dasar") + " \\n");
                else
                {
                    try
                    {
                        ModalDasar = Convert.ToDecimal(txtModalDasar.Text.Trim());
                    }
                    catch
                    {
                        sb.Append(SR.IntegerData("Modal Dasar") + " \\n");
                    }
                }

                decimal ModalSetor = 0;
                if (txtModalSetor.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Modal Setor") + " \\n");
                else
                {
                    try
                    {
                        ModalSetor = Convert.ToDecimal(txtModalSetor.Text.Trim());
                    }
                    catch
                    {
                        sb.Append(SR.IntegerData("Modal Setor") + " \\n");
                    }
                }

                decimal NominalSaham = 0;
                if (txtNominalSaham.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nominal Saham") + " \\n");
                else
                {
                    try
                    {
                        NominalSaham = Convert.ToDecimal(txtNominalSaham.Text.Trim());
                    }
                    catch
                    {
                        sb.Append(SR.IntegerData("Nominal Saham") + " \\n");
                    }
                }

                txtNominalModalDasar.Text = (ModalDasar * NominalSaham).ToString("#,##0");
                txtNominalModalSetor.Text = (ModalSetor * NominalSaham).ToString("#,##0");

                if (ModalDasar < ModalSetor)
                    sb.Append("Modal Dasar must be greater or equal to Modal Setor\\n");
                if (dgPemegangSaham.Items.Count == 0)
                    sb.Append(SR.FieldCanNotEmpty("Pemegang Saham") + " \\n");
                else
                {
                    decimal NominalModalSetor = Convert.ToDecimal(txtNominalModalSetor.Text);
                    decimal JumlahNominal = 0;
                    foreach (DataGridItem item in dgPemegangSaham.Items)
                    {
                        Label lblJumlahNominal = item.FindControl("lblJumlahNominal") as Label;
                        JumlahNominal += Convert.ToDecimal(lblJumlahNominal.Text);
                    }
                    if (NominalModalSetor != JumlahNominal)
                        sb.Append("Data in Pemegang Saham is not equal to Struktur Permodalan\\n");
                }

                if (dgKomisaris.Items.Count == 0)
                    sb.Append(SR.FieldCanNotEmpty("Komisaris dan Direksi") + " \\n");
                if (dgWewenangDireksi.Items.Count == 0)
                    sb.Append(SR.FieldCanNotEmpty("Wewenang Direksi") + " \\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
            {
                if (IDP == 0)
                {
                    if (!fuAkte.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Akta") + " \\n");
                }
                if (txtNoAkte.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No Akta") + " \\n");
                if (dtTanggalAkte.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Akta") + " \\n");
                if (txtNotarisAkte.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Notaris") + " \\n");

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
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SKDP || ViewState["Status"].ToString() == APPROVED)
            {
                if (IDP == 0 || ViewState["Status"].ToString() == APPROVED)
                {
                    if (!fuSKDP.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload SKDP") + " \\n");
                }
                if (txtNoSKDP.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No SKDP") + " \\n");
                if (dtTanggalBerlakuSKDP.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku SKDP") + " \\n");
                if (dtTanggalAkhirBerlakuSKDP.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Berlaku SKDP") + " \\n");
                if (txtAlamatSKDP.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Alamat SKDP") + " \\n");
                int i = DateTime.Compare(dtTanggalBerlakuSKDP.SelectedDate, dtTanggalAkhirBerlakuSKDP.SelectedDate);
                if (i > 0)
                    sb.Append("Tanggal Akhir Berlaku SKDP must be greater or equal than Tanggal Mulai Berlaku SKDP\\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == ACCOUNTING_HEAD_INPUT_COMPANY_CODE)
            {
                if (txtKodePerusahaanAPV.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Kode Perusahaan") + " \\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == ACCOUNTING_UPLOAD_APV)
            {
                if (IDP == 0)
                {
                    if (!fuAPV.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload APV") + " \\n");
                }
                if (txtNoAPV.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No APV") + " \\n");
                if (dtTanggalAPV.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal APV") + " \\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == FINANCE_UPLOAD_SETORAN_MODAL)
            {
                if (IDP == 0)
                {
                    if (!fuSetoranModal.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Setoran Modal") + " \\n");
                }
                if (dtTanggalSetoran.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Setoran") + " \\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
            {
                //if (IDP == 0)
                //{
                //    if (!fuSKPengesahan.HasFile)
                //        sb.Append(SR.FieldCanNotEmpty("File Upload SK Pengesahan") + " \\n");
                //}

                if (!fuAkte.HasFile)
                    sb.Append(SR.FieldCanNotEmpty("File Upload Akta + SK Pengesahan") + " \\n");

                if (txtNoSK.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No SK Pengesahan") + " \\n");
                if (dtTanggalDiterbitkanSK.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Diterbitkan SK Pengesahan") + " \\n");

                if (IDP == 0)
                {
                    if (!fuBNRI.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload BNRI") + " \\n");
                }
                if (txtNoBNRI.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No BNRI") + " \\n");
                if (dtTanggalBNRI.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal BNRI") + " \\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_NPWP)
            {
                if (IDP == 0)
                {
                    if (!fuNPWP.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload NPWP") + " \\n");
                }
                if (txtNOSKTNPWP.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No SKT") + " \\n");
                if (dtTanggalSKTNPWP.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal SKT") + " \\n");
                if (txtNoNPWP.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No NPWP") + " \\n");
                if (dtTanggalTerdaftarNPWP.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Terdaftar NPWP") + " \\n");
                if (txtNamaKPP.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nama KPP") + " \\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_PKP)
            {
                if (chkStatusPKP.Checked)
                {
                    if (txtNoPKP.Text.Trim() == string.Empty)
                        sb.Append(SR.FieldCanNotEmpty("No PKP") + " \\n");
                    if (dtTanggalTerdaftarPKP.ErrorMessage != null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Terdaftar PKP") + " \\n");
                    if (txtNamaPKP.Text.Trim() == string.Empty)
                        sb.Append(SR.FieldCanNotEmpty("Nama PKP") + " \\n");
                }
            }

            return sb.ToString();
        }

        private void BindAllRelatedData(SPListItem item)
        {
            SPList listPemegangSaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PemegangSaham"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + IDP + "</Value>" +
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
                collPemegangSaham.Add(o);
            }
            ViewState["PemegangSaham"] = collPemegangSaham;
            ViewState["PemegangSahamEdit"] = collPemegangSaham;
            BindPemegangSaham();

            SPList listWewenangDireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "WewenangDireksi"));
            SPListItemCollection collSPWewenangDireksi = listWewenangDireksi.GetItems(query);

            List<WewenangDireksi> collWewenangDireksi = new List<WewenangDireksi>();
            foreach (SPListItem i in collSPWewenangDireksi)
            {
                WewenangDireksi o = new WewenangDireksi();
                o.ID = i.ID;
                o.Nama = i["Title"].ToString();
                collWewenangDireksi.Add(o);
            }
            ViewState["WewenangDireksi"] = collWewenangDireksi;
            ViewState["WewenangDireksiEdit"] = collWewenangDireksi;
            BindWewenangDireksi();

            SPList listKomisarisDireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "KomisarisDireksi"));
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
                collKomisarisDireksi.Add(o);
            }
            ViewState["KomisarisDireksi"] = collKomisarisDireksi;
            ViewState["KomisarisDireksiEdit"] = collKomisarisDireksi;
            BindKomisarisDireksi();

            SPList listDokumen = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "DokumenLainnya"));
            SPListItemCollection collSPDokumen = listDokumen.GetItems(query);

            List<Dokumen> collDokumen = new List<Dokumen>();
            foreach (SPListItem i in collSPDokumen)
            {
                Dokumen o = new Dokumen();
                o.ID = i.ID;
                o.NamaFile = i["Name"].ToString();
                if (i["Penjelasan"] != null)
                    o.Penjelasan = i["Penjelasan"].ToString();
                o.TipeDokumen = i["TipeDokumen"] == null ? string.Empty : i["TipeDokumen"].ToString();
                o.Attachment = i.File.OpenBinary();
                o.Url = string.Format("<a href='/DokumenLainnya/{0}'>{0}</a>", i["Name"].ToString());
                collDokumen.Add(o);
            }
            ViewState["Dokumen"] = collDokumen;
            ViewState["DokumenEdit"] = collDokumen;
            BindDokumen();

            SPList listNPWP = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "NPWPLainnya"));
            SPListItemCollection collSPNPWP = listNPWP.GetItems(query);

            List<NPWP> collDokumenNPWP = new List<NPWP>();
            foreach (SPListItem i in collSPNPWP)
            {
                NPWP o = new NPWP();
                o.ID = i.ID;
                o.NamaFile = i["Name"].ToString();
                o.NoNPWP = i["NoNPWP"].ToString();
                if (i["Keterangan"] != null)
                    o.Keterangan = i["Keterangan"].ToString();
                o.Attachment = i.File.OpenBinary();
                o.Url = string.Format("<a href='/NPWPLainnya/{0}'>{0}</a>", i["Name"].ToString());
                collDokumenNPWP.Add(o);
            }
            ViewState["NPWP"] = collDokumenNPWP;
            ViewState["NPWPEdit"] = collDokumenNPWP;
            BindNPWP();

            SPList listPKP = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PKPLainnya"));
            SPListItemCollection collSPPKP = listPKP.GetItems(query);

            List<PKP> collDokumenPKP = new List<PKP>();
            foreach (SPListItem i in collSPPKP)
            {
                PKP o = new PKP();
                o.ID = i.ID;
                o.NamaFile = i["Name"].ToString();
                o.NoPKP = i["NoPKP"].ToString();
                if (i["Keterangan"] != null)
                    o.Keterangan = i["Keterangan"].ToString();
                o.Attachment = i.File.OpenBinary();
                o.Url = string.Format("<a href='/PKPLainnya/{0}'>{0}</a>", i["Name"].ToString());
                collDokumenPKP.Add(o);
            }
            ViewState["PKP"] = collDokumenPKP;
            ViewState["PKPEdit"] = collDokumenPKP;
            BindPKP();

            DisplayDocument(ltrfuSKDP, item.Title, "SKDP");
            DisplayDocument(ltrfuAkte, item.Title, "Akta");
            DisplayDocument(ltrfuNPWP, item.Title, "NPWP");
            DisplayDocument(ltrfuPKP, item.Title, "PKP");
            DisplayDocument(ltrfuAPV, item.Title, "APV");
            DisplayDocument(ltrfuSetoranModal, item.Title, "Setoran Modal");
            //DisplayDocument(ltrfuSKPengesahan, item.Title, "SK Pengesahan");
            DisplayDocument(ltrfuBNRI, item.Title, "BNRI");
        }

        private void Display(string mode)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));//web.Lists[ListId];
            SPListItem item = list.GetItemById(IDP);

            if (item["Status"] != null)
                ViewState["Status"] = item["Status"].ToString();
            else
            {
                if (item["ApprovalStatus"] != null)
                    ViewState["Status"] = item["ApprovalStatus"].ToString();
            }

            if (mode == "edit")
                btnSaveUpdate.Text = "Update";
            else if (mode == "display")
                btnSaveUpdate.Visible = false;

            ltrRequestCode.Text = item["Title"].ToString();
            ltrTanggal.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
            txtTujuanPenggunaan.Text = item["TujuanPenggunaan"] == null ? string.Empty : item["TujuanPenggunaan"].ToString();
            txtNamaPerusahaan.Text = item["NamaPerusahaan"] == null ? string.Empty : item["NamaPerusahaan"].ToString();
            if (item["TempatKedudukan"] != null)
                ddlTempatKedudukan.SelectedValue = item["TempatKedudukan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (item["MaksudTujuan"] != null)
                ddlMaksudTujuan.SelectedValue = item["MaksudTujuan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (item["StatusOwnership"] != null)
                ddlStatusOwnership.SelectedValue = item["StatusOwnership"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (item["MataUang"] != null)
                ddlMataUang.SelectedValue = item["MataUang"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            if (item["StatusPerseroan"] != null)
                ddlStatusPerseroan.SelectedValue = item["StatusPerseroan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            ltrMataUangSelected.Text = ddlMataUang.SelectedItem.Text;
            txtModalDasar.Text = item["ModalDasar"] == null ? string.Empty : Convert.ToDouble(item["ModalDasar"]).ToString("#,##0");
            txtModalSetor.Text = item["ModalSetor"] == null ? string.Empty : Convert.ToDouble(item["ModalSetor"]).ToString("#,##0");
            txtNominalSaham.Text = item["Nominal"] == null ? string.Empty : Convert.ToDouble(item["Nominal"]).ToString("#,##0");
            if (txtModalDasar.Text != string.Empty && txtNominalSaham.Text != string.Empty)
                txtNominalModalDasar.Text = (Convert.ToDouble(txtModalDasar.Text) * Convert.ToDouble(txtNominalSaham.Text)).ToString("#,##0");
            if (txtModalSetor.Text != string.Empty && txtNominalSaham.Text != string.Empty)
                txtNominalModalSetor.Text = (Convert.ToDouble(txtModalSetor.Text) * Convert.ToDouble(txtNominalSaham.Text)).ToString("#,##0");
            txtKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
            if (item["StatusPKP"] != null)
                chkStatusPKP.Checked = Convert.ToBoolean(item["StatusPKP"]);

            if (item["Pemohon"] != null)
            {
                int IDPemohon = Convert.ToInt32(item["Pemohon"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                hfIDPemohon.Value = IDPemohon.ToString();
                SPList listPemohon = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
                SPListItem itemPemohon = listPemohon.GetItemById(IDPemohon);
                txtNamaPemohon.Text = itemPemohon.Title;
                txtEmailPemohon.Text = itemPemohon["EmailPemohon"].ToString();
            }

            /* SKDP */
            if (item["PembuatSKDP"] != null)
            {
                txtNoSKDP.Text = item["NoSKDP"].ToString();
                dtTanggalBerlakuSKDP.SelectedDate = Convert.ToDateTime(item["TanggalMulaiBerlakuSKDP"]);
                dtTanggalAkhirBerlakuSKDP.SelectedDate = Convert.ToDateTime(item["TanggalAkhirBerlakuSKDP"]);
                txtAlamatSKDP.Text = item["AlamatSKDP"] == null ? string.Empty : item["AlamatSKDP"].ToString();
                ltrUsernameSKDP.Text = item["PembuatSKDP"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* Akte */
            if (item["PembuatAkte"] != null)
            {
                txtNoAkte.Text = item["NoAkte"].ToString();
                dtTanggalAkte.SelectedDate = Convert.ToDateTime(item["TanggalAkte"]);
                txtNotarisAkte.Text = item["NotarisAkte"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                txtKeteranganAkte.Text = item["KeteranganAkte"] == null ? string.Empty : item["KeteranganAkte"].ToString();
                ltrUsernameAkte.Text = item["PembuatAkte"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* NPWP */
            if (item["PembuatNPWP"] != null)
            {
                txtNOSKTNPWP.Text = item["NoSKTNPWP"].ToString();
                dtTanggalSKTNPWP.SelectedDate = Convert.ToDateTime(item["TanggalSKTNPWP"]);
                txtNoNPWP.Text = item["NoNPWP"].ToString();
                dtTanggalTerdaftarNPWP.SelectedDate = Convert.ToDateTime(item["TanggalTerdaftarNPWP"]);
                txtNamaKPP.Text = item["NamaKPPNPWP"].ToString();
                txtKeteranganNPWP.Text = item["KeteranganNPWP"] == null ? string.Empty : item["KeteranganNPWP"].ToString();
                ltrUsernameNPWP.Text = item["PembuatNPWP"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* PKP */
            if (item["PembuatPKP"] != null)
            {
                txtNoPKP.Text = item["NoPKP"] == null ? string.Empty : item["NoPKP"].ToString();
                if (item["TanggalTerdaftarPKP"] != null)
                    dtTanggalTerdaftarPKP.SelectedDate = Convert.ToDateTime(item["TanggalTerdaftarPKP"]);
                txtNamaPKP.Text = item["NamaPKP"] == null ? string.Empty : item["NamaPKP"].ToString();
                txtKeteranganPKP.Text = item["KeteranganPKP"] == null ? string.Empty : item["KeteranganPKP"].ToString();
                if (item["StatusPKP"] == null)
                    ltrStatusPKP.Text = "No";
                else
                    ltrStatusPKP.Text = Convert.ToBoolean(item["StatusPKP"]) == true ? "Yes" : "No";
                ltrUsernamePKP.Text = item["PembuatPKP"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* APV */
            if (item["PembuatAPV"] != null)
            {
                txtKodePerusahaanAPV.Text = item["CompanyCodeAPV"] == null ? string.Empty : item["CompanyCodeAPV"].ToString();
                if (item["NoAPV"] != null)
                    txtNoAPV.Text = item["NoAPV"].ToString();
                if (item["TanggalAPV"] != null)
                    dtTanggalAPV.SelectedDate = Convert.ToDateTime(item["TanggalAPV"]);
                txtKeteranganAPV.Text = item["KeteranganAPV"] == null ? string.Empty : item["KeteranganAPV"].ToString();
                if (item["PembuatAPV"] != null)
                    ltrUsernameAPV.Text = item["PembuatAPV"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* Setoran Modal */
            if (item["PembuatSetoran"] != null)
            {
                dtTanggalSetoran.SelectedDate = Convert.ToDateTime(item["TanggalSetoran"]);
                txtKeteranganSetoran.Text = item["KeteranganSetoran"] == null ? string.Empty : item["KeteranganSetoran"].ToString();
                chkStatusSetoran.Checked = Convert.ToBoolean(item["StatusSetoran"]);
                ltrUsernameSetoran.Text = item["PembuatSetoran"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* SK Pengesahan */
            if (item["PembuatSK"] != null)
            {
                txtNoSK.Text = item["NoSK"].ToString();
                dtTanggalDiterbitkanSK.SelectedDate = Convert.ToDateTime(item["TanggalDiterbitkanSK"]);
                txtKeteranganSK.Text = item["KeteranganSK"] == null ? string.Empty : item["KeteranganSK"].ToString();
                ltrUsernameSKPengesahan.Text = item["PembuatSK"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* BNRI */
            if (item["PembuatBNRI"] != null)
            {
                txtNoBNRI.Text = item["NoBNRI"].ToString();
                dtTanggalBNRI.SelectedDate = Convert.ToDateTime(item["TanggalBNRI"]);
                txtTambahanNoBNRI.Text = item["TambahanNoBNRI"] == null ? string.Empty : item["TambahanNoBNRI"].ToString();
                ltrUsernameBNRI.Text = item["PembuatBNRI"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            ltrTujuanPenggunaan.Text = txtTujuanPenggunaan.Text;
            ltrNamaPerusahaan.Text = txtNamaPerusahaan.Text;

            ltrNamaPemohon.Text = txtNamaPemohon.Text;
            ltrEmailPemohon.Text = txtEmailPemohon.Text;

            if (item["TempatKedudukan"] != null)
                ltrTempatKedudukan.Text = ddlTempatKedudukan.SelectedItem.Text;
            if (item["MaksudTujuan"] != null)
                ltrMaksudTujuan.Text = ddlMaksudTujuan.SelectedItem.Text;
            if (item["StatusOwnership"] != null)
                ltrStatusOwnership.Text = ddlStatusOwnership.SelectedItem.Text;
            if (item["StatusPerseroan"] != null)
                ltrStatusPerseroan.Text = ddlStatusPerseroan.SelectedItem.Text;
            if (item["MataUang"] != null)
                ltrMataUang.Text = ddlMataUang.SelectedItem.Text;
            if (item["ModalDasar"] != null)
                ltrModalDasar.Text = Convert.ToDouble(item["ModalDasar"]).ToString("#,##0");
            if (item["ModalSetor"] != null)
                ltrModalSetor.Text = Convert.ToDouble(item["ModalSetor"]).ToString("#,##0");
            if (item["Nominal"] != null)
                ltrNominalSaham.Text = Convert.ToDouble(item["Nominal"]).ToString("#,##0");
            if (ltrModalDasar.Text != string.Empty && ltrNominalSaham.Text != string.Empty)
                ltrNominalModalDasar.Text = (Convert.ToDouble(ltrModalDasar.Text) * Convert.ToDouble(ltrNominalSaham.Text)).ToString("#,##0");
            if (ltrModalSetor.Text != string.Empty && ltrNominalSaham.Text != string.Empty)
                ltrNominalModalSetor.Text = (Convert.ToDouble(ltrModalSetor.Text) * Convert.ToDouble(ltrNominalSaham.Text)).ToString("#,##0");
            ltrKeterangan.Text = txtKeterangan.Text;

            /* SKDP */
            if (item["PembuatSKDP"] != null)
            {
                ltrNoSKDP.Text = item["NoSKDP"].ToString();
                ltrTanggalBerlakuSKDP.Text = Convert.ToDateTime(item["TanggalMulaiBerlakuSKDP"]).ToString("dd-MMM-yyyy");
                ltrTanggalAkhirBerlakuSKDP.Text = Convert.ToDateTime(item["TanggalAkhirBerlakuSKDP"]).ToString("dd-MMM-yyyy");
                ltrAlamatSKDP.Text = item["AlamatSKDP"] == null ? string.Empty : item["AlamatSKDP"].ToString();
                ltrUsernameSKDP.Text = item["PembuatSKDP"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* Akte */
            if (item["PembuatAkte"] != null)
            {
                ltrNoAkte.Text = item["NoAkte"].ToString();
                ltrTanggalAkte.Text = Convert.ToDateTime(item["TanggalAkte"]).ToString("dd-MMM-yyyy");
                ltrNotarisAkte.Text = item["NotarisAkte"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                ltrKeteranganAkte.Text = item["KeteranganAkte"] == null ? string.Empty : item["KeteranganAkte"].ToString();
                ltrUsernameAkte.Text = item["PembuatAkte"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* NPWP */
            if (item["PembuatNPWP"] != null)
            {
                ltrNOSKTNPWP.Text = item["NoSKTNPWP"].ToString();
                ltrTanggalSKTNPWP.Text = Convert.ToDateTime(item["TanggalSKTNPWP"]).ToString("dd-MMM-yyyy");
                ltrNoNPWP.Text = item["NoNPWP"].ToString();
                ltrTanggalTerdaftarNPWP.Text = Convert.ToDateTime(item["TanggalTerdaftarNPWP"]).ToString("dd-MMM-yyyy");
                ltrNamaKPP.Text = item["NamaKPPNPWP"].ToString();
                ltrKeteranganNPWP.Text = item["KeteranganNPWP"] == null ? string.Empty : item["KeteranganNPWP"].ToString();
                ltrUsernameNPWP.Text = item["PembuatNPWP"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* PKP */
            if (item["PembuatPKP"] != null)
            {
                ltrNoPKP.Text = item["NoPKP"] == null ? string.Empty : item["NoPKP"].ToString();
                if (item["TanggalTerdaftarPKP"] != null)
                    ltrTanggalTerdaftarPKP.Text = Convert.ToDateTime(item["TanggalTerdaftarPKP"]).ToString("dd-MMM-yyyy");
                ltrNamaPKP.Text = item["NamaPKP"] == null ? string.Empty : item["NamaPKP"].ToString();
                ltrKeteranganPKP.Text = item["KeteranganPKP"] == null ? string.Empty : item["KeteranganPKP"].ToString();
                ltrUsernamePKP.Text = item["PembuatPKP"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* APV */
            if (item["PembuatAPV"] != null)
            {
                ltrKodePerusahaanAPV.Text = item["CompanyCodeAPV"] == null ? string.Empty : item["CompanyCodeAPV"].ToString();
                if (item["NoAPV"] != null)
                    ltrNoAPV.Text = item["NoAPV"].ToString();
                if (item["TanggalAPV"] != null)
                    ltrTanggalAPV.Text = Convert.ToDateTime(item["TanggalAPV"]).ToString("dd-MMM-yyyy");
                ltrKeteranganAPV.Text = item["KeteranganAPV"] == null ? string.Empty : item["KeteranganAPV"].ToString();
                if (item["PembuatAPV"] != null)
                    ltrUsernameAPV.Text = item["PembuatAPV"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* Setoran Modal */
            if (item["PembuatSetoran"] != null)
            {
                ltrTanggalSetoran.Text = Convert.ToDateTime(item["TanggalSetoran"]).ToString("dd-MMM-yyyy");
                ltrKeteranganSetoran.Text = item["KeteranganSetoran"] == null ? string.Empty : item["KeteranganSetoran"].ToString();
                ltrStatusSetoran.Text = Convert.ToBoolean(item["StatusSetoran"]) == true ? "Yes" : "No";
                ltrUsernameSetoran.Text = item["PembuatSetoran"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* SK Pengesahan */
            if (item["PembuatSK"] != null)
            {
                ltrNoSK.Text = item["NoSK"].ToString();
                ltrTanggalDiterbitkanSK.Text = Convert.ToDateTime(item["TanggalDiterbitkanSK"]).ToString("dd-MMM-yyyy");
                ltrKeteranganSK.Text = item["KeteranganSK"] == null ? string.Empty : item["KeteranganSK"].ToString();
                ltrUsernameSKPengesahan.Text = item["PembuatSK"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            /* BNRI */
            if (item["PembuatBNRI"] != null)
            {
                ltrNoBNRI.Text = item["NoBNRI"].ToString();
                ltrTanggalBNRI.Text = Convert.ToDateTime(item["TanggalBNRI"]).ToString("dd-MMM-yyyy");
                ltrTambahanNoBNRI.Text = item["TambahanNoBNRI"] == null ? string.Empty : item["TambahanNoBNRI"].ToString();
                ltrUsernameBNRI.Text = item["PembuatBNRI"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            BindAllRelatedData(item);

            if (ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                pnlPICCorsec1.Visible = true;
            else if (ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SKDP)
            {
                pnlPICCorsec1.Visible = true;
                pnlPICCorsec2.Visible = true;
            }
            else if (ViewState["Status"].ToString() == ACCOUNTING_HEAD_INPUT_COMPANY_CODE || ViewState["Status"].ToString() == ACCOUNTING_UPLOAD_APV)
            {
                pnlPICCorsec1.Visible = true;
                pnlPICCorsec2.Visible = true;
                pnlAccounting.Visible = true;
            }
            else if (ViewState["Status"].ToString() == FINANCE_UPLOAD_SETORAN_MODAL)
            {
                pnlPICCorsec1.Visible = true;
                pnlPICCorsec2.Visible = true;
                pnlAccounting.Visible = true;
                pnlFinance.Visible = true;
            }
            else if (ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
            {
                pnlPICCorsec1.Visible = true;
                pnlPICCorsec2.Visible = true;
                pnlAccounting.Visible = true;
                pnlFinance.Visible = true;
                pnlPICCorsec3.Visible = true;
            }
            else if (ViewState["Status"].ToString() == TAX_UPLOAD_NPWP)
            {
                pnlPICCorsec1.Visible = true;
                pnlPICCorsec2.Visible = true;
                pnlAccounting.Visible = true;
                pnlFinance.Visible = true;
                pnlPICCorsec3.Visible = true;
                pnlTax.Visible = true;
            }
            else if (ViewState["Status"].ToString() == TAX_UPLOAD_PKP)
            {
                pnlPICCorsec1.Visible = true;
                pnlPICCorsec2.Visible = true;
                pnlAccounting.Visible = true;
                pnlFinance.Visible = true;
                pnlPICCorsec3.Visible = true;
                pnlTax.Visible = true;
                pnlTax2.Visible = true;
            }
            else
            {
                pnlAccounting.Visible = false;
                pnlFinance.Visible = false;
                pnlPICCorsec1.Visible = false;
                pnlPICCorsec2.Visible = false;
                pnlPICCorsec3.Visible = false;
                pnlTax.Visible = false;
                pnlTax2.Visible = false;
                pnlAssign.Visible = false;
            }

            if (item["ApprovalStatus"] != null)
            {
                if (item["ApprovalStatus"].ToString() == APPROVED)
                {
                    pnlAccounting.Visible = true;
                    pnlFinance.Visible = true;
                    pnlPICCorsec1.Visible = true;
                    pnlPICCorsec2.Visible = true;
                    pnlPICCorsec3.Visible = true;
                    pnlTax.Visible = true;
                    pnlTax2.Visible = true;
                    pnlAssign.Visible = true;
                }
            }

            HiddenControls(mode, ViewState["Status"].ToString());
        }

        private void HiddenControls(string mode, string status)
        {
            if (mode == "display")
            {
                txtTujuanPenggunaan.Visible = false;
                txtNamaPemohon.Visible = false;
                txtEmailPemohon.Visible = false;
                imgbtnNamaPemohon.Visible = false;
                txtNamaPerusahaan.Visible = false;
                ddlTempatKedudukan.Visible = false;
                ddlMaksudTujuan.Visible = false;
                ddlStatusOwnership.Visible = false;
                ddlStatusPerseroan.Visible = false;
                ddlMataUang.Visible = false;
                txtModalDasar.Visible = false;
                txtNominalModalDasar.Visible = false;
                txtModalSetor.Visible = false;
                txtNominalModalSetor.Visible = false;
                txtNominalSaham.Visible = false;
                txtKeterangan.Visible = false;
                chkStatusPKP.Visible = false;

                fuSKDP.Visible = false;
                txtNoSKDP.Visible = false;
                dtTanggalBerlakuSKDP.Visible = false;
                dtTanggalAkhirBerlakuSKDP.Visible = false;
                txtAlamatSKDP.Visible = false;

                fuAkte.Visible = false;
                txtNoAkte.Visible = false;
                dtTanggalAkte.Visible = false;
                txtNotarisAkte.Visible = false;
                txtKeteranganAkte.Visible = false;

                fuNPWP.Visible = false;
                txtNOSKTNPWP.Visible = false;
                dtTanggalSKTNPWP.Visible = false;
                txtNoNPWP.Visible = false;
                dtTanggalTerdaftarNPWP.Visible = false;
                txtNamaKPP.Visible = false;
                txtKeteranganNPWP.Visible = false;

                fuPKP.Visible = false;
                txtNoPKP.Visible = false;
                dtTanggalTerdaftarPKP.Visible = false;
                txtNamaPKP.Visible = false;
                txtKeteranganPKP.Visible = false;

                fuAPV.Visible = false;
                txtKodePerusahaanAPV.Visible = false;
                txtNoAPV.Visible = false;
                dtTanggalAPV.Visible = false;
                txtKeteranganAPV.Visible = false;

                fuSetoranModal.Visible = false;
                dtTanggalSetoran.Visible = false;
                txtKeteranganSetoran.Visible = false;
                chkStatusSetoran.Visible = false;

                //fuSKPengesahan.Visible = false;
                txtNoSK.Visible = false;
                dtTanggalDiterbitkanSK.Visible = false;
                txtKeteranganSK.Visible = false;

                fuBNRI.Visible = false;
                txtNoBNRI.Visible = false;
                dtTanggalBNRI.Visible = false;
                txtTambahanNoBNRI.Visible = false;

                dgPemegangSaham.ShowFooter = false;
                dgPemegangSaham.Columns[6].Visible = true;
                dgPemegangSaham.Columns[7].Visible = true;
                dgPemegangSaham.Columns[8].Visible = false;

                dgKomisaris.ShowFooter = false;
                dgKomisaris.Columns[5].Visible = true;
                dgKomisaris.Columns[6].Visible = true;
                dgKomisaris.Columns[7].Visible = false;

                dgWewenangDireksi.ShowFooter = false;
                dgWewenangDireksi.Columns[2].Visible = false;

                dgNPWPLainnya.ShowFooter = false;
                dgNPWPLainnya.Columns[4].Visible = false;

                dgPKPLainnya.ShowFooter = false;
                dgPKPLainnya.Columns[4].Visible = false;

                dgDokumenLainnya.ShowFooter = false;
                dgDokumenLainnya.Columns[4].Visible = false;
            }
            else if (mode == "edit")
            {
                if (Convert.ToBoolean(ViewState["Admin"]) == false)
                {
                    if (status == APPROVED || status == PIC_CORSEC_UPLOAD_AKTA || status == PIC_CORSEC_UPLOAD_SKDP || status == ACCOUNTING_HEAD_INPUT_COMPANY_CODE || status == ACCOUNTING_UPLOAD_APV || status == FINANCE_UPLOAD_SETORAN_MODAL || status == PIC_CORSEC_UPLOAD_SK_PENGESAHAN || status == TAX_UPLOAD_NPWP || status == TAX_UPLOAD_PKP)
                    {
                        txtTujuanPenggunaan.Visible = false;
                        txtNamaPemohon.Visible = false;
                        txtEmailPemohon.Visible = false;
                        imgbtnNamaPemohon.Visible = false;
                        txtNamaPerusahaan.Visible = false;
                        ddlTempatKedudukan.Visible = false;
                        ddlMaksudTujuan.Visible = false;
                        ddlStatusOwnership.Visible = false;
                        ddlStatusPerseroan.Visible = false;
                        ddlMataUang.Visible = false;
                        txtModalDasar.Visible = false;
                        txtModalSetor.Visible = false;
                        txtNominalModalDasar.Visible = false;
                        txtNominalModalSetor.Visible = false;
                        txtNominalSaham.Visible = false;
                        txtKeterangan.Visible = false;

                        dgPemegangSaham.Columns[6].Visible = true;
                        dgPemegangSaham.Columns[7].Visible = true;

                        dgKomisaris.Columns[5].Visible = true;
                        dgKomisaris.Columns[6].Visible = true;

                        if (status == PIC_CORSEC_UPLOAD_AKTA)
                        {
                            dgPemegangSaham.ShowFooter = true;
                            dgPemegangSaham.Columns[8].Visible = true;

                            dgKomisaris.ShowFooter = true;
                            dgKomisaris.Columns[7].Visible = true;
                        }
                        else
                        {
                            dgPemegangSaham.ShowFooter = false;
                            dgPemegangSaham.Columns[8].Visible = false;

                            dgKomisaris.ShowFooter = false;
                            dgKomisaris.Columns[7].Visible = false;
                        }

                        dgWewenangDireksi.ShowFooter = false;
                        dgWewenangDireksi.Columns[2].Visible = false;

                        dgDokumenLainnya.ShowFooter = false;
                        dgDokumenLainnya.Columns[4].Visible = false;
                    }

                    if (status == Roles.DIV_HEAD_CORSEC)
                    {
                        ltrTujuanPenggunaan.Visible = false;
                        ltrNamaPemohon.Visible = false;
                        ltrEmailPemohon.Visible = false;
                        ltrNamaPerusahaan.Visible = false;
                        ltrTempatKedudukan.Visible = false;
                        ltrMaksudTujuan.Visible = false;
                        ltrStatusOwnership.Visible = false;
                        ltrStatusPerseroan.Visible = false;
                        ltrMataUang.Visible = false;
                        ltrModalDasar.Visible = false;
                        ltrModalSetor.Visible = false;
                        ltrNominalModalDasar.Visible = false;
                        ltrNominalModalSetor.Visible = false;
                        ltrNominalSaham.Visible = false;
                        ltrKeterangan.Visible = false;
                        ltrStatusPKP.Visible = false;
                    }

                    if (status == PIC_CORSEC_UPLOAD_AKTA)
                    {
                        ltrNoAkte.Visible = false;
                        ltrTanggalAkte.Visible = false;
                        ltrNotarisAkte.Visible = false;
                        ltrKeteranganAkte.Visible = false;
                    }
                    else
                    {
                        txtNoAkte.Visible = false;
                        dtTanggalAkte.Visible = false;
                        txtNotarisAkte.Visible = false;
                        txtKeteranganAkte.Visible = false;
                        fuAkte.Visible = false;
                        reqtxtNoAkte.Visible = false;
                        reqdtTanggalAkte.Visible = false;
                        reqtxtNotarisAkte.Visible = false;
                    }

                    if (status == PIC_CORSEC_UPLOAD_SKDP || status == APPROVED)
                    {
                        ltrNoSKDP.Visible = false;
                        ltrTanggalBerlakuSKDP.Visible = false;
                        ltrTanggalAkhirBerlakuSKDP.Visible = false;
                        ltrAlamatSKDP.Visible = false;
                    }
                    else
                    {
                        txtNoSKDP.Visible = false;
                        dtTanggalBerlakuSKDP.Visible = false;
                        dtTanggalAkhirBerlakuSKDP.Visible = false;
                        txtAlamatSKDP.Visible = false;
                        fuSKDP.Visible = false;
                        reqtxtNoSKDP.Visible = false;
                        reqdtTanggalBerlakuSKDP.Visible = false;
                        reqdtTanggalAkhirBerlakuSKDP.Visible = false;
                    }

                    if (status == ACCOUNTING_UPLOAD_APV || status == ACCOUNTING_HEAD_INPUT_COMPANY_CODE)
                    {
                        ltrKodePerusahaanAPV.Visible = false;
                        ltrNoAPV.Visible = false;
                        ltrTanggalAPV.Visible = false;
                        ltrKeteranganAPV.Visible = false;

                        if (status == ACCOUNTING_HEAD_INPUT_COMPANY_CODE)
                        {
                            txtNoAPV.Enabled = false;
                            dtTanggalAPV.Enabled = false;
                            txtKeteranganAPV.Enabled = false;
                            fuAPV.Visible = false;

                            reqtxtNoAPV.Enabled = false;
                            reqdtTanggalAPV.Enabled = false;
                        }
                        else
                            txtKodePerusahaanAPV.Enabled = false;
                    }
                    else
                    {
                        txtKodePerusahaanAPV.Visible = false;
                        txtNoAPV.Visible = false;
                        dtTanggalAPV.Visible = false;
                        txtKeteranganAPV.Visible = false;
                        fuAPV.Visible = false;

                        reqtxtKodePerusahaanAPV.Visible = false;
                        reqtxtNoAPV.Visible = false;
                        reqdtTanggalAPV.Visible = false;
                    }

                    if (status == FINANCE_UPLOAD_SETORAN_MODAL)
                    {
                        ltrTanggalSetoran.Visible = false;
                        ltrKeteranganSetoran.Visible = false;
                        ltrStatusSetoran.Visible = false;
                    }
                    else
                    {
                        dtTanggalSetoran.Visible = false;
                        txtKeteranganSetoran.Visible = false;
                        chkStatusSetoran.Visible = false;
                        fuSetoranModal.Visible = false;

                        reqdtTanggalSetoran.Visible = false;
                    }

                    if (status == PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
                    {
                        fuAkte.Visible = true;

                        ltrNoSK.Visible = false;
                        ltrTanggalDiterbitkanSK.Visible = false;
                        ltrKeteranganSK.Visible = false;

                        ltrNoBNRI.Visible = false;
                        ltrTanggalBNRI.Visible = false;
                        ltrTambahanNoBNRI.Visible = false;
                    }
                    else
                    {
                        txtNoSK.Visible = false;
                        dtTanggalDiterbitkanSK.Visible = false;
                        txtKeteranganSK.Visible = false;
                        //fuSKPengesahan.Visible = false;
                        reqtxtNoSK.Visible = false;
                        reqdtTanggalDiterbitkanSK.Visible = false;

                        txtNoBNRI.Visible = false;
                        dtTanggalBNRI.Visible = false;
                        txtTambahanNoBNRI.Visible = false;
                        fuBNRI.Visible = false;
                        reqtxtNoBNRI.Visible = false;
                        reqdtTanggalBNRI.Visible = false;
                    }

                    if (status == TAX_UPLOAD_NPWP)
                    {
                        ltrNOSKTNPWP.Visible = false;
                        ltrTanggalSKTNPWP.Visible = false;
                        ltrNoNPWP.Visible = false;
                        ltrTanggalTerdaftarNPWP.Visible = false;
                        ltrNamaKPP.Visible = false;
                        ltrKeteranganNPWP.Visible = false;

                        dgNPWPLainnya.ShowFooter = true;
                        dgNPWPLainnya.Columns[4].Visible = true;
                    }
                    else
                    {
                        txtNOSKTNPWP.Visible = false;
                        dtTanggalSKTNPWP.Visible = false;
                        txtNoNPWP.Visible = false;
                        dtTanggalTerdaftarNPWP.Visible = false;
                        txtNamaKPP.Visible = false;
                        txtKeteranganNPWP.Visible = false;
                        fuNPWP.Visible = false;
                        reqtxtNOSKTNPWP.Visible = false;
                        reqdtTanggalSKTNPWP.Visible = false;
                        reqtxtNoNPWP.Visible = false;
                        reqdtTanggalTerdaftarNPWP.Visible = false;
                        reqtxtNamaKPP.Visible = false;

                        dgNPWPLainnya.ShowFooter = false;
                        dgNPWPLainnya.Columns[4].Visible = false;
                    }

                    if (status == TAX_UPLOAD_PKP)
                    {
                        if (chkStatusPKP.Checked)
                        {
                            reqfuPKP.Visible = true;
                            reqtxtNoPKP.Visible = true;
                            reqdtTanggalTerdaftarPKP.Visible = true;
                            reqtxtNamaPKP.Visible = true;
                        }
                        else
                        {
                            reqfuPKP.Visible = false;
                            reqtxtNoPKP.Visible = false;
                            reqdtTanggalTerdaftarPKP.Visible = false;
                            reqtxtNamaPKP.Visible = false;
                        }

                        ltrNoPKP.Visible = false;
                        ltrTanggalTerdaftarPKP.Visible = false;
                        ltrNamaPKP.Visible = false;
                        ltrKeteranganPKP.Visible = false;
                        ltrStatusPKP.Visible = false;

                        dgPKPLainnya.ShowFooter = true;
                        dgPKPLainnya.Columns[4].Visible = true;
                    }
                    else
                    {
                        txtNoPKP.Visible = false;
                        dtTanggalTerdaftarPKP.Visible = false;
                        txtNamaPKP.Visible = false;
                        txtKeteranganPKP.Visible = false;
                        chkStatusPKP.Visible = false;
                        fuPKP.Visible = false;

                        dgPKPLainnya.ShowFooter = false;
                        dgPKPLainnya.Columns[4].Visible = false;
                    }
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || status == string.Empty)
                {
                    ltrTujuanPenggunaan.Visible = false;
                    ltrNamaPemohon.Visible = false;
                    ltrEmailPemohon.Visible = false;
                    ltrNamaPerusahaan.Visible = false;
                    ltrTempatKedudukan.Visible = false;
                    ltrMaksudTujuan.Visible = false;
                    ltrStatusOwnership.Visible = false;
                    ltrStatusPerseroan.Visible = false;
                    ltrMataUang.Visible = false;
                    ltrModalDasar.Visible = false;
                    ltrModalSetor.Visible = false;
                    ltrNominalModalDasar.Visible = false;
                    ltrNominalModalSetor.Visible = false;
                    ltrNominalSaham.Visible = false;
                    ltrKeterangan.Visible = false;
                    ltrStatusPKP.Visible = false;

                    ltrNoAkte.Visible = false;
                    ltrTanggalAkte.Visible = false;
                    ltrNotarisAkte.Visible = false;
                    ltrKeteranganAkte.Visible = false;

                    ltrNoSKDP.Visible = false;
                    ltrTanggalBerlakuSKDP.Visible = false;
                    ltrTanggalAkhirBerlakuSKDP.Visible = false;
                    ltrAlamatSKDP.Visible = false;

                    ltrNOSKTNPWP.Visible = false;
                    ltrTanggalSKTNPWP.Visible = false;
                    ltrNoNPWP.Visible = false;
                    ltrTanggalTerdaftarNPWP.Visible = false;
                    ltrNamaKPP.Visible = false;
                    ltrKeteranganNPWP.Visible = false;

                    ltrNoPKP.Visible = false;
                    ltrTanggalTerdaftarPKP.Visible = false;
                    ltrNamaPKP.Visible = false;
                    ltrKeteranganPKP.Visible = false;

                    ltrKodePerusahaanAPV.Visible = false;
                    ltrNoAPV.Visible = false;
                    ltrTanggalAPV.Visible = false;
                    ltrKeteranganAPV.Visible = false;

                    ltrTanggalSetoran.Visible = false;
                    ltrKeteranganSetoran.Visible = false;
                    ltrStatusSetoran.Visible = false;

                    ltrNoSK.Visible = false;
                    ltrTanggalDiterbitkanSK.Visible = false;
                    ltrKeteranganSK.Visible = false;

                    ltrNoBNRI.Visible = false;
                    ltrTanggalBNRI.Visible = false;
                    ltrTambahanNoBNRI.Visible = false;
                }

                if (ltrfuSKDP.Text.Trim() == string.Empty)
                    reqfuSKDP.Visible = true;
                else
                    reqfuSKDP.Visible = false;

                if (status != PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
                {
                    if (ltrfuAkte.Text.Trim() == string.Empty)
                        reqfuAkte.Visible = true;
                    else
                        reqfuAkte.Visible = false;
                }

                if (ltrfuNPWP.Text.Trim() == string.Empty)
                    reqfuNPWP.Visible = true;
                else
                    reqfuNPWP.Visible = false;

                if (chkStatusPKP.Checked)
                {
                    if (ltrfuPKP.Text.Trim() == string.Empty)
                        reqfuPKP.Visible = true;
                    else
                        reqfuPKP.Visible = false;
                }

                if (ltrfuAPV.Text.Trim() == string.Empty)
                    reqfuAPV.Visible = true;
                else
                    reqfuAPV.Visible = false;

                if (ltrfuSetoranModal.Text.Trim() == string.Empty)
                    reqfuSetoranModal.Visible = true;
                else
                    reqfuSetoranModal.Visible = false;

                //if (ltrfuSKPengesahan.Text.Trim() == string.Empty)
                //    reqfuSKPengesahan.Visible = true;
                //else
                //    reqfuSKPengesahan.Visible = false;

                if (ltrfuBNRI.Text.Trim() == string.Empty)
                    reqfuBNRI.Visible = true;
                else
                    reqfuBNRI.Visible = false;

                if (status == APPROVED)
                    reqfuSKDP.Visible = true;
            }
        }

        private string SaveUpdate()
        {
            string message = string.Empty;

            SPWeb currentWeb = SPContext.Current.Web;
            SPList list = currentWeb.GetList(Util.CreateSharePointListStrUrl(currentWeb.Url, "PerusahaanBaru")); //web.Lists[ListId];
            currentWeb.AllowUnsafeUpdates = true;
            SPListItem item;

            try
            {
                if (IDP == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(IDP);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty || ViewState["Status"].ToString() == Roles.DIV_HEAD_CORSEC)
                {
                    item["Tanggal"] = Convert.ToDateTime(ltrTanggal.Text);
                    item["TujuanPenggunaan"] = txtTujuanPenggunaan.Text.Trim();
                    item["Pemohon"] = hfIDPemohon.Value.ToString();
                    item["NamaPerusahaan"] = txtNamaPerusahaan.Text.Trim();
                    item["TempatKedudukan"] = ddlTempatKedudukan.SelectedValue;
                    item["MaksudTujuan"] = ddlMaksudTujuan.SelectedValue;
                    item["StatusOwnership"] = ddlStatusOwnership.SelectedValue;
                    item["StatusPerseroan"] = ddlStatusPerseroan.SelectedValue;
                    item["MataUang"] = ddlMataUang.SelectedValue;
                    item["ModalDasar"] = txtModalDasar.Text.Trim();
                    item["ModalSetor"] = txtModalSetor.Text.Trim();
                    item["Nominal"] = txtNominalSaham.Text.Trim();
                    item["Keterangan"] = txtKeterangan.Text.Trim();

                }
                item["StatusPKP"] = chkStatusPKP.Checked;

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                {
                    /* Akte */
                    item["NoAkte"] = txtNoAkte.Text.Trim();
                    item["TanggalAkte"] = dtTanggalAkte.SelectedDate;
                    item["NotarisAkte"] = GetNotarisID(txtNotarisAkte.Text.Trim());
                    item["KeteranganAkte"] = txtKeteranganAkte.Text.Trim();
                    item["PembuatAkte"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SKDP)
                {
                    /* SKDP */
                    item["NoSKDP"] = txtNoSKDP.Text.Trim();
                    item["TanggalMulaiBerlakuSKDP"] = dtTanggalBerlakuSKDP.SelectedDate;
                    item["TanggalAkhirBerlakuSKDP"] = dtTanggalAkhirBerlakuSKDP.SelectedDate;
                    item["AlamatSKDP"] = txtAlamatSKDP.Text.Trim();
                    item["PembuatSKDP"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == ACCOUNTING_UPLOAD_APV || ViewState["Status"].ToString() == ACCOUNTING_HEAD_INPUT_COMPANY_CODE)
                {
                    /* APV */
                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == ACCOUNTING_HEAD_INPUT_COMPANY_CODE)
                        item["CompanyCodeAPV"] = txtKodePerusahaanAPV.Text.Trim();

                    if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == ACCOUNTING_UPLOAD_APV)
                    {
                        item["NoAPV"] = txtNoAPV.Text.Trim();
                        item["TanggalAPV"] = dtTanggalAPV.SelectedDate;
                        item["KeteranganAPV"] = txtKeteranganAPV.Text.Trim();
                    }

                    item["PembuatAPV"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == FINANCE_UPLOAD_SETORAN_MODAL)
                {
                    /* Setoran Modal */
                    item["TanggalSetoran"] = dtTanggalSetoran.SelectedDate;
                    item["KeteranganSetoran"] = txtKeteranganSetoran.Text.Trim();
                    item["StatusSetoran"] = chkStatusSetoran.Checked;
                    item["PembuatSetoran"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
                {
                    /* SK Pengesahan */
                    item["NoSK"] = txtNoSK.Text.Trim();
                    item["TanggalDiterbitkanSK"] = dtTanggalDiterbitkanSK.SelectedDate;
                    item["KeteranganSK"] = txtKeteranganSK.Text.Trim();
                    item["PembuatSK"] = SPContext.Current.Web.CurrentUser.ID.ToString();

                    /* BNRI */
                    item["NoBNRI"] = txtNoBNRI.Text.Trim();
                    item["TanggalBNRI"] = dtTanggalBNRI.SelectedDate;
                    item["TambahanNoBNRI"] = txtTambahanNoBNRI.Text.Trim();
                    item["PembuatBNRI"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_NPWP)
                {
                    /* NPWP */
                    item["NoSKTNPWP"] = txtNOSKTNPWP.Text.Trim();
                    item["TanggalSKTNPWP"] = dtTanggalSKTNPWP.SelectedDate;
                    item["NoNPWP"] = txtNoNPWP.Text.Trim();
                    item["TanggalTerdaftarNPWP"] = dtTanggalTerdaftarNPWP.SelectedDate;
                    item["NamaKPPNPWP"] = txtNamaKPP.Text.Trim();
                    item["KeteranganNPWP"] = txtKeteranganNPWP.Text.Trim();
                    item["PembuatNPWP"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_PKP)
                {
                    /* PKP */
                    if (chkStatusPKP.Checked)
                    {
                        item["NoPKP"] = txtNoPKP.Text.Trim();
                        item["TanggalTerdaftarPKP"] = dtTanggalTerdaftarPKP.SelectedDate;
                        item["NamaPKP"] = txtNamaPKP.Text.Trim();
                        item["KeteranganPKP"] = txtKeteranganPKP.Text.Trim();
                        item["PembuatPKP"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    }
                }

                item.Update();

                currentWeb.AllowUnsafeUpdates = false;

                if (IDP == 0)
                {
                    web.AllowUnsafeUpdates = true;

                    SPDocumentLibrary listDocument = (SPDocumentLibrary)web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
                    System.Collections.Hashtable properties = new System.Collections.Hashtable();
                    properties.Add("PerusahaanBaru", item.ID);

                    // Creating the document set
                    SPContentType ctype = web.ContentTypes["Document Set"];
                    DocumentSet.Create(listDocument.RootFolder, item.Title, listDocument.ContentTypes.BestMatch(ctype.Id), properties, true);

                    web.AllowUnsafeUpdates = false;
                }

                ViewState["ID"] = item.ID;

                web.AllowUnsafeUpdates = true;

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty || ViewState["Status"].ToString() == Roles.DIV_HEAD_CORSEC || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA || ViewState["Status"].ToString() == TAX_UPLOAD_NPWP || ViewState["Status"].ToString() == TAX_UPLOAD_PKP)
                    SaveGridData(dgPemegangSaham, dgKomisaris, dgWewenangDireksi, dgNPWPLainnya, dgPKPLainnya);

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                {
                    message = SaveDocument(fuAkte, item.Title, "Akta");
                    if (message != string.Empty)
                        return message;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SKDP)
                {
                    message = SaveDocument(fuSKDP, item.Title, "SKDP");
                    if (message != string.Empty)
                        return message;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == ACCOUNTING_UPLOAD_APV)
                {
                    message = SaveDocument(fuAPV, item.Title, "APV");
                    if (message != string.Empty)
                        return message;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == FINANCE_UPLOAD_SETORAN_MODAL)
                {
                    message = SaveDocument(fuSetoranModal, item.Title, "Setoran Modal");
                    if (message != string.Empty)
                        return message;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
                {
                    //message = SaveDocument(fuSKPengesahan, item.Title, "SK Pengesahan");
                    //if (message != string.Empty)
                    //    return message;

                    message = UpdateSKPengesahan(item.Title, "Akta");
                    if (message != string.Empty)
                        return message;

                    message = SaveDocument(fuBNRI, item.Title, "BNRI");
                    if (message != string.Empty)
                        return message;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_NPWP)
                {
                    message = SaveDocument(fuNPWP, item.Title, "NPWP");
                    if (message != string.Empty)
                        return message;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_PKP)
                {
                    message = SaveDocument(fuPKP, item.Title, "PKP");
                    if (message != string.Empty)
                        return message;
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

        private string UpdateApprovedData()
        {
            SPWeb currentWeb = SPContext.Current.Web;
            SPList list = currentWeb.GetList(Util.CreateSharePointListStrUrl(currentWeb.Url, "PerusahaanBaru")); //web.Lists[ListId];
            currentWeb.AllowUnsafeUpdates = true;
            SPListItem item = list.GetItemById(IDP);
            try
            {
                item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                /* SKDP */
                item["NoSKDP"] = txtNoSKDP.Text.Trim();
                item["TanggalMulaiBerlakuSKDP"] = dtTanggalBerlakuSKDP.SelectedDate;
                item["TanggalAkhirBerlakuSKDP"] = dtTanggalAkhirBerlakuSKDP.SelectedDate;
                item["AlamatSKDP"] = txtAlamatSKDP.Text.Trim();
                item["PembuatSKDP"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                item.Update();

                ViewState["ID"] = item.ID;

                currentWeb.AllowUnsafeUpdates = false;
                web.AllowUnsafeUpdates = true;

                string message = SaveDocument(fuSKDP, item.Title, "SKDP");
                if (message != string.Empty)
                    return message;

                web.AllowUnsafeUpdates = false;

            }
            catch
            {
                return SR.UpdateFail;
            }
            return string.Empty;
        }

        private void SaveGridData(DataGrid dgPS, DataGrid dgK, DataGrid dgWD, DataGrid dgNPWP, DataGrid dgPKP)
        {
            SPList listPemegangSaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PemegangSaham"));
            SPList listWewenangDireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "WewenangDireksi"));
            SPList listKomisarisDireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "KomisarisDireksi"));
            SPList listDokumen = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "DokumenLainnya"));
            SPList listNPWP = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "NPWPLainnya"));
            SPList listPKP = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PKPLainnya"));

            if (IDP == 0)
            {
                List<PemegangSaham> collPemegangSaham = ViewState["PemegangSaham"] as List<PemegangSaham>;
                foreach (PemegangSaham i in collPemegangSaham)
                {
                    SPListItem itemPemegangSaham = listPemegangSaham.Items.Add();
                    itemPemegangSaham["PerusahaanBaru"] = ViewState["ID"].ToString();
                    itemPemegangSaham["Title"] = i.Nama;
                    itemPemegangSaham["JumlahSaham"] = i.JumlahSaham;
                    itemPemegangSaham["JumlahNominal"] = i.JumlahNominal;
                    itemPemegangSaham["Percentages"] = i.Percentages;
                    itemPemegangSaham["Partner"] = i.Partner;
                    if (Convert.ToBoolean(ViewState["Admin"]) == true)
                    {
                        itemPemegangSaham["TanggalMulaiMenjabat"] = i.MulaiMenjabat;
                        itemPemegangSaham["TanggalAkhirMenjabat"] = i.AkhirMenjabat;
                    }
                    itemPemegangSaham["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    itemPemegangSaham.Update();
                }

                List<KomisarisDireksi> collKomisarisDireksi = ViewState["KomisarisDireksi"] as List<KomisarisDireksi>;
                foreach (KomisarisDireksi i in collKomisarisDireksi)
                {
                    SPListItem itemKomisarisDireksi = listKomisarisDireksi.Items.Add();
                    itemKomisarisDireksi["PerusahaanBaru"] = ViewState["ID"].ToString();
                    itemKomisarisDireksi["Title"] = i.Nama;
                    itemKomisarisDireksi["Jabatan"] = i.IDJabatan;
                    itemKomisarisDireksi["NoKTP"] = i.NoKTP;
                    itemKomisarisDireksi["NoNPWP"] = i.NoNPWP;
                    if (Convert.ToBoolean(ViewState["Admin"]) == true)
                    {
                        itemKomisarisDireksi["TanggalMulaiMenjabat"] = i.MulaiMenjabat;
                        itemKomisarisDireksi["TanggalAkhirMenjabat"] = i.AkhirMenjabat;
                    }
                    itemKomisarisDireksi["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    itemKomisarisDireksi.Update();
                }

                List<WewenangDireksi> collWewenangDireksi = ViewState["WewenangDireksi"] as List<WewenangDireksi>;
                foreach (WewenangDireksi i in collWewenangDireksi)
                {
                    SPListItem itemWewenangDireksi = listWewenangDireksi.Items.Add();
                    itemWewenangDireksi["PerusahaanBaru"] = ViewState["ID"].ToString();
                    itemWewenangDireksi["Title"] = i.Nama;
                    itemWewenangDireksi["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                    itemWewenangDireksi.Update();
                }

                if (ViewState["Dokumen"] != null)
                {
                    List<Dokumen> collDokumen = ViewState["Dokumen"] as List<Dokumen>;
                    foreach (Dokumen i in collDokumen)
                    {
                        SPFolder document = web.Folders["DokumenLainnya"];
                        SPFile file = document.Files.Add(i.NamaFile, i.Attachment);
                        SPItem itemDocument = file.Item;
                        itemDocument["Title"] = Path.GetFileNameWithoutExtension(i.NamaFile);
                        itemDocument["PerusahaanBaru"] = Convert.ToInt32(ViewState["ID"]);
                        itemDocument["TipeDokumen"] = i.TipeDokumen;
                        itemDocument["Penjelasan"] = i.Penjelasan;
                        itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemDocument.Update();
                    }
                }

                if (ViewState["NPWP"] != null)
                {
                    List<NPWP> collDokumen = ViewState["NPWP"] as List<NPWP>;
                    foreach (NPWP i in collDokumen)
                    {
                        SPFolder document = web.Folders["NPWPLainnya"];
                        SPFile file = document.Files.Add(i.NamaFile, i.Attachment);
                        SPItem itemDocument = file.Item;
                        itemDocument["Title"] = Path.GetFileNameWithoutExtension(i.NamaFile);
                        itemDocument["PerusahaanBaru"] = Convert.ToInt32(ViewState["ID"]);
                        itemDocument["NoNPWP"] = i.NoNPWP;
                        itemDocument["Keterangan"] = i.Keterangan;
                        itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemDocument.Update();
                    }
                }

                if (ViewState["PKP"] != null)
                {
                    List<PKP> collDokumen = ViewState["PKP"] as List<PKP>;
                    foreach (PKP i in collDokumen)
                    {
                        SPFolder document = web.Folders["PKPLainnya"];
                        SPFile file = document.Files.Add(i.NamaFile, i.Attachment);
                        SPItem itemDocument = file.Item;
                        itemDocument["Title"] = Path.GetFileNameWithoutExtension(i.NamaFile);
                        itemDocument["PerusahaanBaru"] = Convert.ToInt32(ViewState["ID"]);
                        itemDocument["NoPKP"] = i.NoPKP;
                        itemDocument["Keterangan"] = i.Keterangan;
                        itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemDocument.Update();
                    }
                }
            }
            else
            {
                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                {
                    if (dgPS.Items.Count > 0)
                    {
                        foreach (DataGridItem dgItem in dgPS.Items)
                        {
                            Label lblID = dgItem.FindControl("lblID") as Label;
                            Label lblNamaPemegangSaham = dgItem.FindControl("lblNamaPemegangSaham") as Label;
                            Label lblJumlahSaham = dgItem.FindControl("lblJumlahSaham") as Label;
                            Label lblJumlahNominal = dgItem.FindControl("lblJumlahNominal") as Label;
                            Label lblPercentages = dgItem.FindControl("lblPercentages") as Label;
                            Label lblPartner = dgItem.FindControl("lblPartner") as Label;
                            Label lblTanggalMulaiMenjabat = null;
                            Label lblTanggalAkhirMenjabat = null;

                            SPListItem itemPemegangSaham;
                            if (Convert.ToInt32(lblID.Text) != 0)
                            {
                                itemPemegangSaham = listPemegangSaham.GetItemById(Convert.ToInt32(lblID.Text));
                                itemPemegangSaham["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemPemegangSaham = listPemegangSaham.Items.Add();
                                itemPemegangSaham["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemPemegangSaham["PerusahaanBaru"] = ViewState["ID"].ToString();
                            itemPemegangSaham["Title"] = lblNamaPemegangSaham.Text;
                            itemPemegangSaham["JumlahSaham"] = lblJumlahSaham.Text;
                            itemPemegangSaham["JumlahNominal"] = lblJumlahNominal.Text;
                            itemPemegangSaham["Percentages"] = lblPercentages.Text;
                            itemPemegangSaham["Partner"] = lblPartner.Text == "Yes" ? true : false;
                            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                            {
                                lblTanggalMulaiMenjabat = dgItem.FindControl("lblTanggalMulaiMenjabat") as Label;
                                lblTanggalAkhirMenjabat = dgItem.FindControl("lblTanggalAkhirMenjabat") as Label;

                                itemPemegangSaham["TanggalMulaiMenjabat"] = Convert.ToDateTime(lblTanggalMulaiMenjabat.Text);
                                itemPemegangSaham["TanggalAkhirMenjabat"] = Convert.ToDateTime(lblTanggalAkhirMenjabat.Text);
                            }
                            itemPemegangSaham.Update();
                        }
                    }

                    if (ViewState["PemegangSahamEdit"] != null)
                    {
                        List<PemegangSaham> collPemegangSahamEdit = ViewState["PemegangSahamEdit"] as List<PemegangSaham>;
                        foreach (PemegangSaham itemEdit in collPemegangSahamEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgPS.Items)
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
                                SPListItem itemPemegangSaham = listPemegangSaham.GetItemById(itemEdit.ID);
                                if (itemPemegangSaham != null)
                                    itemPemegangSaham.Delete();
                            }
                        }
                    }

                    if (dgK.Items.Count > 0)
                    {
                        foreach (DataGridItem dgItem in dgK.Items)
                        {
                            Label lblID = dgItem.FindControl("lblID") as Label;
                            Label lblNama = dgItem.FindControl("lblNama") as Label;
                            Label lblJabatan = dgItem.FindControl("lblJabatan") as Label;
                            Label lblJabatanID = dgItem.FindControl("lblJabatanID") as Label;
                            Label lblNoKTP = dgItem.FindControl("lblNoKTP") as Label;
                            Label lblNoNPWP = dgItem.FindControl("lblNoNPWP") as Label;
                            Label lblTanggalMulaiMenjabat = null;
                            Label lblTanggalAkhirMenjabat = null;

                            SPListItem itemKomisarisDireksi;
                            if (Convert.ToInt32(lblID.Text) != 0)
                            {
                                itemKomisarisDireksi = listKomisarisDireksi.GetItemById(Convert.ToInt32(lblID.Text));
                                itemKomisarisDireksi["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemKomisarisDireksi = listKomisarisDireksi.Items.Add();
                                itemKomisarisDireksi["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemKomisarisDireksi["NoKTP"] = lblNoKTP.Text;
                            itemKomisarisDireksi["NoNPWP"] = lblNoNPWP.Text;
                            itemKomisarisDireksi["PerusahaanBaru"] = ViewState["ID"].ToString();
                            itemKomisarisDireksi["Title"] = lblNama.Text;
                            itemKomisarisDireksi["Jabatan"] = lblJabatanID.Text;
                            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                            {
                                lblTanggalMulaiMenjabat = dgItem.FindControl("lblTanggalMulaiMenjabat") as Label;
                                lblTanggalAkhirMenjabat = dgItem.FindControl("lblTanggalAkhirMenjabat") as Label;

                                itemKomisarisDireksi["TanggalMulaiMenjabat"] = Convert.ToDateTime(lblTanggalMulaiMenjabat.Text);
                                itemKomisarisDireksi["TanggalAkhirMenjabat"] = Convert.ToDateTime(lblTanggalAkhirMenjabat.Text);
                            }
                            itemKomisarisDireksi.Update();
                        }
                    }

                    if (ViewState["KomisarisDireksiEdit"] != null)
                    {
                        List<KomisarisDireksi> collKomisarisDireksiEdit = ViewState["KomisarisDireksiEdit"] as List<KomisarisDireksi>;
                        foreach (KomisarisDireksi itemEdit in collKomisarisDireksiEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgK.Items)
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
                                SPListItem itemKomisarisDireksi = listKomisarisDireksi.GetItemById(itemEdit.ID);
                                if (itemKomisarisDireksi != null)
                                    itemKomisarisDireksi.Delete();
                            }
                        }
                    }
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty)
                {
                    if (dgWD.Items.Count > 0)
                    {
                        foreach (DataGridItem dgItem in dgWD.Items)
                        {
                            Label lblID = dgItem.FindControl("lblID") as Label;
                            Label lblNama = dgItem.FindControl("lblNama") as Label;

                            SPListItem itemWewenangDireksi;
                            if (Convert.ToInt32(lblID.Text) != 0)
                            {
                                itemWewenangDireksi = listWewenangDireksi.GetItemById(Convert.ToInt32(lblID.Text));
                                itemWewenangDireksi["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemWewenangDireksi = listWewenangDireksi.Items.Add();
                                itemWewenangDireksi["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemWewenangDireksi["PerusahaanBaru"] = ViewState["ID"].ToString();
                            itemWewenangDireksi["Title"] = lblNama.Text;
                            itemWewenangDireksi.Update();
                        }
                    }

                    if (ViewState["WewenangDireksiEdit"] != null)
                    {
                        List<WewenangDireksi> collWewenangDireksiEdit = ViewState["WewenangDireksiEdit"] as List<WewenangDireksi>;
                        foreach (WewenangDireksi itemEdit in collWewenangDireksiEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgWD.Items)
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
                                SPListItem itemWewenangDireksi = listWewenangDireksi.GetItemById(itemEdit.ID);
                                if (itemWewenangDireksi != null)
                                    itemWewenangDireksi.Delete();
                            }
                        }
                    }

                    if (dgDokumenLainnya.Items.Count > 0)
                    {
                        List<Dokumen> collDokumen = ViewState["Dokumen"] as List<Dokumen>;
                        foreach (Dokumen i in collDokumen)
                        {
                            SPListItem itemDocument;
                            if (i.ID != 0)
                            {
                                itemDocument = listDokumen.GetItemById(i.ID);
                                itemDocument["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                SPFolder document = web.Folders["DokumenLainnya"];
                                SPFile file = document.Files.Add(i.NamaFile, i.Attachment);
                                itemDocument = file.Item;
                                itemDocument["Title"] = Path.GetFileNameWithoutExtension(i.NamaFile);
                                itemDocument["PerusahaanBaru"] = Convert.ToInt32(ViewState["ID"]);
                                itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemDocument["Penjelasan"] = i.Penjelasan;
                            itemDocument["TipeDokumen"] = i.TipeDokumen;
                            itemDocument.Update();
                        }
                    }

                    if (ViewState["DokumenEdit"] != null)
                    {
                        List<Dokumen> collDokumenEdit = ViewState["DokumenEdit"] as List<Dokumen>;
                        foreach (Dokumen itemEdit in collDokumenEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgDokumenLainnya.Items)
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
                                SPListItem itemDokument = listDokumen.GetItemById(itemEdit.ID);
                                if (itemDokument != null)
                                    itemDokument.Delete();
                            }
                        }
                    }
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_NPWP)
                {
                    if (dgNPWP.Items.Count > 0)
                    {
                        List<NPWP> collDokumen = ViewState["NPWP"] as List<NPWP>;
                        foreach (NPWP i in collDokumen)
                        {
                            SPListItem itemDocument;
                            if (i.ID != 0)
                            {
                                itemDocument = listNPWP.GetItemById(i.ID);
                                itemDocument["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                SPFolder document = web.Folders["NPWPLainnya"];
                                SPFile file = document.Files.Add(i.NamaFile, i.Attachment);
                                itemDocument = file.Item;
                                itemDocument["Title"] = Path.GetFileNameWithoutExtension(i.NamaFile);
                                itemDocument["PerusahaanBaru"] = Convert.ToInt32(ViewState["ID"]);
                                itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemDocument["Keterangan"] = i.Keterangan;
                            itemDocument["NoNPWP"] = i.NoNPWP;
                            itemDocument.Update();
                        }
                    }

                    if (ViewState["NPWPEdit"] != null)
                    {
                        List<NPWP> collDokumenEdit = ViewState["NPWPEdit"] as List<NPWP>;
                        foreach (NPWP itemEdit in collDokumenEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgNPWP.Items)
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
                                SPListItem itemDokument = listNPWP.GetItemById(itemEdit.ID);
                                if (itemDokument != null)
                                    itemDokument.Delete();
                            }
                        }
                    }
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == TAX_UPLOAD_PKP)
                {
                    if (dgPKP.Items.Count > 0)
                    {
                        List<PKP> collDokumen = ViewState["PKP"] as List<PKP>;
                        foreach (PKP i in collDokumen)
                        {
                            SPListItem itemDocument;
                            if (i.ID != 0)
                            {
                                itemDocument = listPKP.GetItemById(i.ID);
                                itemDocument["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                SPFolder document = web.Folders["PKPLainnya"];
                                SPFile file = document.Files.Add(i.NamaFile, i.Attachment);
                                itemDocument = file.Item;
                                itemDocument["Title"] = Path.GetFileNameWithoutExtension(i.NamaFile);
                                itemDocument["PerusahaanBaru"] = Convert.ToInt32(ViewState["ID"]);
                                itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemDocument["Keterangan"] = i.Keterangan;
                            itemDocument["NoPKP"] = i.NoPKP;
                            itemDocument.Update();
                        }
                    }

                    if (ViewState["PKPEdit"] != null)
                    {
                        List<PKP> collDokumenEdit = ViewState["PKPEdit"] as List<PKP>;
                        foreach (PKP itemEdit in collDokumenEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgPKP.Items)
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
                                SPListItem itemDokument = listPKP.GetItemById(itemEdit.ID);
                                if (itemDokument != null)
                                    itemDokument.Delete();
                            }
                        }
                    }
                }
            }
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
                            pnlAccounting.Visible = true;
                            pnlFinance.Visible = true;
                            pnlPICCorsec1.Visible = true;
                            pnlPICCorsec2.Visible = true;
                            pnlPICCorsec3.Visible = true;
                            pnlTax.Visible = true;
                            pnlTax2.Visible = true;
                            pnlAssign.Visible = true;

                            dgPemegangSaham.Columns[6].Visible = true;
                            dgPemegangSaham.Columns[7].Visible = true;

                            dgKomisaris.Columns[5].Visible = true;
                            dgKomisaris.Columns[6].Visible = true;
                        }
                        else
                        {
                            dgPemegangSaham.Columns[6].Visible = false;
                            dgPemegangSaham.Columns[7].Visible = false;

                            dgKomisaris.Columns[5].Visible = false;
                            dgKomisaris.Columns[6].Visible = false;
                        }

                        txtNotarisAkte.Attributes.Add("onkeyup", "Notaris('" + txtNotarisAkte.ClientID + "');");

                        txtModalDasar.Attributes.Add("onkeyup", "FormatNumber('" + txtModalDasar.ClientID + "'); Total('" + txtModalDasar.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalDasar.ClientID + "');");
                        txtModalDasar.Attributes.Add("onblur", " FormatNumber('" + txtModalDasar.ClientID + "')");

                        txtModalSetor.Attributes.Add("onkeyup", "FormatNumber('" + txtModalSetor.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalSetor.ClientID + "');");
                        txtModalSetor.Attributes.Add("onblur", " FormatNumber('" + txtModalSetor.ClientID + "')");

                        txtNominalSaham.Attributes.Add("onkeyup", "FormatNumber('" + txtNominalSaham.ClientID + "'); Total('" + txtModalDasar.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalDasar.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalSetor.ClientID + "');");
                        txtNominalSaham.Attributes.Add("onblur", " FormatNumber('" + txtNominalSaham.ClientID + "')");

                        ltrTanggal.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                        BindMaksudTujuan(ddlMaksudTujuan);
                        BindMataUang(ddlMataUang);
                        BindStatusOwnership(ddlStatusOwnership);
                        BindTempatKedudukan(ddlTempatKedudukan);
                        BindStatusPerseroan(ddlStatusPerseroan);

                        if (isID)
                            Display(Mode);
                        else
                        {
                            BindWewenangDireksi();
                            BindKomisarisDireksi();
                            BindPemegangSaham();
                            BindDokumen();
                            BindNPWP();
                            BindPKP();
                        }
                    }
                }
            }
        }

        protected void ddlMataUang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMataUang.SelectedValue == string.Empty)
                ltrMataUangSelected.Text = "Mata Uang";
            else
                ltrMataUangSelected.Text = ddlMataUang.SelectedItem.Text;

            upStrukturPermodalan.Update();
        }

        protected void chkStatusPKP_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStatusPKP.Checked == true)
            {
                reqfuPKP.Visible = true;
                reqtxtNoPKP.Visible = true;
                reqdtTanggalTerdaftarPKP.Visible = true;
                reqtxtNamaPKP.Visible = true;
            }
            else
            {
                reqfuPKP.Visible = false;
                reqtxtNoPKP.Visible = false;
                reqdtTanggalTerdaftarPKP.Visible = false;
                reqtxtNamaPKP.Visible = false;
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
            string result = string.Empty;

            if (ViewState["Status"].ToString() == APPROVED)
                result = UpdateApprovedData();
            else
                result = SaveUpdate();

            if (result == string.Empty)
            {
                if (Source != string.Empty)
                    SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
                else
                    Response.Redirect("/Lists/PerusahaanBaru", true);
            }
            else
                Util.ShowMessage(Page, result);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect("/Lists/PerusahaanBaru", true);
        }

        #region Pemegang Saham

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

        private void BindPemegangSaham()
        {
            List<PemegangSaham> coll = new List<PemegangSaham>();
            if (ViewState["PemegangSaham"] != null)
                coll = ViewState["PemegangSaham"] as List<PemegangSaham>;

            dgPemegangSaham.DataSource = coll;
            dgPemegangSaham.DataBind();

            upPemegangSaham.Update();
        }

        protected void dgPemegangSaham_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            PemegangSaham o = e.Item.DataItem as PemegangSaham;

            if (e.Item.ItemType == ListItemType.Footer)
            {
                TextBox txtJumlahSahamAdd = e.Item.FindControl("txtJumlahSahamAdd") as TextBox;
                TextBox txtJumlahNominalAdd = e.Item.FindControl("txtJumlahNominalAdd") as TextBox;
                TextBox txtPercentagesAdd = e.Item.FindControl("txtPercentagesAdd") as TextBox;

                txtJumlahSahamAdd.Attributes.Add("onblur", " FormatNumber('" + txtJumlahSahamAdd.ClientID + "')");

                if (ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                    txtJumlahSahamAdd.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamAdd.ClientID + "'); Total('" + txtJumlahSahamAdd.ClientID + "','" + ltrNominalSaham.ClientID + "','" + txtJumlahNominalAdd.ClientID + "'); Percentages('" + txtJumlahSahamAdd.ClientID + "','" + ltrModalSetor.ClientID + "','" + txtPercentagesAdd.ClientID + "');");
                else
                    txtJumlahSahamAdd.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamAdd.ClientID + "'); Total('" + txtJumlahSahamAdd.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtJumlahNominalAdd.ClientID + "'); Percentages('" + txtJumlahSahamAdd.ClientID + "','" + txtModalSetor.ClientID + "','" + txtPercentagesAdd.ClientID + "');");

                TextBox txtNamaPemegangSahamAdd = e.Item.FindControl("txtNamaPemegangSahamAdd") as TextBox;
                txtNamaPemegangSahamAdd.Attributes.Add("onkeyup", "PemegangSaham('" + txtNamaPemegangSahamAdd.ClientID + "');");
            }
            else if (e.Item.ItemType == ListItemType.EditItem)
            {
                TextBox txtJumlahSahamEdit = e.Item.FindControl("txtJumlahSahamEdit") as TextBox;
                TextBox txtJumlahNominalEdit = e.Item.FindControl("txtJumlahNominalEdit") as TextBox;
                TextBox txtPercentagesEdit = e.Item.FindControl("txtPercentagesEdit") as TextBox;

                txtJumlahSahamEdit.Attributes.Add("onblur", " FormatNumber('" + txtJumlahSahamEdit.ClientID + "')");

                if (ViewState["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                    txtJumlahSahamEdit.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamEdit.ClientID + "'); Total('" + txtJumlahSahamEdit.ClientID + "','" + ltrNominalSaham.ClientID + "','" + txtJumlahNominalEdit.ClientID + "'); Percentages('" + txtJumlahSahamEdit.ClientID + "','" + ltrModalSetor.ClientID + "','" + txtPercentagesEdit.ClientID + "');");
                else
                    txtJumlahSahamEdit.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamEdit.ClientID + "'); Total('" + txtJumlahSahamEdit.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtJumlahNominalEdit.ClientID + "'); Percentages('" + txtJumlahSahamEdit.ClientID + "','" + txtModalSetor.ClientID + "','" + txtPercentagesEdit.ClientID + "');");

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

        protected void dgPemegangSaham_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (txtNominalModalSetor.Text.Trim() == string.Empty || txtNominalSaham.Text.Trim() == string.Empty)
            {
                Util.ShowMessage(Page, SR.FieldCanNotEmpty("Nominal Modal Setor and Nominal Saham"));
                return;
            }

            DataGrid dg = source as DataGrid;
            List<PemegangSaham> coll = new List<PemegangSaham>();
            if (ViewState["PemegangSaham"] != null)
                coll = ViewState["PemegangSaham"] as List<PemegangSaham>;

            decimal NominalModalSetor = 0;
            decimal NominalSaham = 0;

            NominalModalSetor = Convert.ToDecimal(txtNominalModalSetor.Text);
            NominalSaham = Convert.ToDecimal(txtNominalSaham.Text);

            if (e.CommandName == "add")
            {
                TextBox txtNamaPemegangSahamAdd = e.Item.FindControl("txtNamaPemegangSahamAdd") as TextBox;
                TextBox txtJumlahSahamAdd = e.Item.FindControl("txtJumlahSahamAdd") as TextBox;
                TextBox txtJumlahNominalAdd = e.Item.FindControl("txtJumlahNominalAdd") as TextBox;
                TextBox txtPercentagesAdd = e.Item.FindControl("txtPercentagesAdd") as TextBox;
                CheckBox cboPartnerAdd = e.Item.FindControl("cboPartnerAdd") as CheckBox;
                DateTimeControl dtTanggalMulaiMenjabatAdd = null;
                DateTimeControl dtTanggalAkhirMenjabatAdd = null;

                PemegangSaham o = new PemegangSaham();

                if (isExistInPemegangSahamGrid(txtNamaPemegangSahamAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaPemegangSahamAdd.Text.Trim()));
                    return;
                }

                string msg = Util.IsPemegangSahamOK(dg, Convert.ToDecimal(txtJumlahSahamAdd.Text), Convert.ToDecimal(txtJumlahNominalAdd.Text), NominalModalSetor, NominalSaham);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC + " Upload Akta")
                {
                    dtTanggalMulaiMenjabatAdd = e.Item.FindControl("dtTanggalMulaiMenjabatAdd") as DateTimeControl;
                    dtTanggalAkhirMenjabatAdd = e.Item.FindControl("dtTanggalAkhirMenjabatAdd") as DateTimeControl;
                    o.MulaiMenjabat = dtTanggalMulaiMenjabatAdd.SelectedDate;
                    o.AkhirMenjabat = dtTanggalAkhirMenjabatAdd.SelectedDate;

                    int i = DateTime.Compare(dtTanggalMulaiMenjabatAdd.SelectedDate, dtTanggalAkhirMenjabatAdd.SelectedDate);
                    if (i > 0)
                    {
                        Util.ShowMessage(Page, "Tanggal Akhir Menjabat must be greater or equal than Tanggal Mulai Menjabat");
                        return;
                    }
                }

                o.Nama = txtNamaPemegangSahamAdd.Text.Trim();
                o.JumlahNominal = Convert.ToDouble(txtJumlahNominalAdd.Text);
                o.JumlahSaham = Convert.ToDouble(txtJumlahSahamAdd.Text);
                o.Partner = cboPartnerAdd.Checked;
                o.Percentages = Convert.ToDouble(txtPercentagesAdd.Text);
                o.ID = 0;
                coll.Add(o);

                ViewState["PemegangSaham"] = coll;
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

                PemegangSaham o = new PemegangSaham();

                if (isExistInPemegangSahamGrid(txtNamaPemegangSahamEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaPemegangSahamEdit.Text.Trim()));
                    return;
                }

                string msg = Util.IsPemegangSahamOK(dg, Convert.ToDecimal(txtJumlahSahamEdit.Text), Convert.ToDecimal(txtJumlahNominalEdit.Text), NominalModalSetor, NominalSaham);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC + " Upload Akta")
                {
                    dtTanggalMulaiMenjabatEdit = e.Item.FindControl("dtTanggalMulaiMenjabatEdit") as DateTimeControl;
                    dtTanggalAkhirMenjabatEdit = e.Item.FindControl("dtTanggalAkhirMenjabatEdit") as DateTimeControl;
                    o.MulaiMenjabat = dtTanggalMulaiMenjabatEdit.SelectedDate;
                    o.AkhirMenjabat = dtTanggalAkhirMenjabatEdit.SelectedDate;

                    int i = DateTime.Compare(dtTanggalMulaiMenjabatEdit.SelectedDate, dtTanggalAkhirMenjabatEdit.SelectedDate);
                    if (i > 0)
                    {
                        Util.ShowMessage(Page, "Tanggal Akhir Menjabat must be greater or equal than Tanggal Mulai Menjabat");
                        return;
                    }
                }

                o.Nama = txtNamaPemegangSahamEdit.Text.Trim();
                o.JumlahNominal = Convert.ToDouble(txtJumlahNominalEdit.Text);
                o.JumlahSaham = Convert.ToDouble(txtJumlahSahamEdit.Text);
                o.Partner = cboPartnerEdit.Checked;
                o.Percentages = Convert.ToDouble(txtPercentagesEdit.Text);

                coll[e.Item.ItemIndex] = o;
                ViewState["PemegangSaham"] = coll;

                dg.EditItemIndex = -1;
                dg.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dg.ShowFooter = false;
                dg.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dg.EditItemIndex = -1;
                dg.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["PemegangSaham"] = coll;
            }
            BindPemegangSaham();
        }

        #endregion

        #region Komisaris dan Direksi

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

        private void BindKomisarisDireksi()
        {
            List<KomisarisDireksi> coll = new List<KomisarisDireksi>();
            if (ViewState["KomisarisDireksi"] != null)
                coll = ViewState["KomisarisDireksi"] as List<KomisarisDireksi>;

            dgKomisaris.DataSource = coll;
            dgKomisaris.DataBind();

            upKomisarisDireksi.Update();
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
            DataGrid dg = source as DataGrid;
            List<KomisarisDireksi> coll = new List<KomisarisDireksi>();
            if (ViewState["KomisarisDireksi"] != null)
                coll = ViewState["KomisarisDireksi"] as List<KomisarisDireksi>;

            if (e.CommandName == "add")
            {
                TextBox txtNamaAdd = e.Item.FindControl("txtNamaAdd") as TextBox;
                DropDownList ddlJabatanAdd = e.Item.FindControl("ddlJabatanAdd") as DropDownList;
                DateTimeControl dtTanggalMulaiMenjabatAdd = null;
                DateTimeControl dtTanggalAkhirMenjabatAdd = null;
                TextBox txtNoKTPAdd = e.Item.FindControl("txtNoKTPAdd") as TextBox;
                TextBox txtNoNPWPAdd = e.Item.FindControl("txtNoNPWPAdd") as TextBox;

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

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC + " Upload Akta")
                {
                    dtTanggalMulaiMenjabatAdd = e.Item.FindControl("dtTanggalMulaiMenjabatAdd") as DateTimeControl;
                    dtTanggalAkhirMenjabatAdd = e.Item.FindControl("dtTanggalAkhirMenjabatAdd") as DateTimeControl;
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

                ViewState["KomisarisDireksi"] = coll;
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

                KomisarisDireksi o = new KomisarisDireksi();
                o.Nama = txtNamaEdit.Text.Trim();
                o.IDJabatan = Convert.ToInt32(ddlJabatanEdit.SelectedValue);
                o.Jabatan = ddlJabatanEdit.SelectedItem.Text;
                o.NoKTP = txtNoKTPEdit.Text;
                o.NoNPWP = txtNoNPWPEdit.Text;

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC + " Upload Akta")
                {
                    dtTanggalMulaiMenjabatEdit = e.Item.FindControl("dtTanggalMulaiMenjabatEdit") as DateTimeControl;
                    dtTanggalAkhirMenjabatEdit = e.Item.FindControl("dtTanggalAkhirMenjabatEdit") as DateTimeControl;
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
                ViewState["KomisarisDireksi"] = coll;

                dg.EditItemIndex = -1;
                dg.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dg.ShowFooter = false;
                dg.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dg.EditItemIndex = -1;
                dg.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["KomisarisDireksi"] = coll;
            }
            BindKomisarisDireksi();
        }

        #endregion

        #region Wewenang Direksi

        private bool isExistInWewenangDireksiGrid(string Nama)
        {
            foreach (DataGridItem item in dgWewenangDireksi.Items)
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

        private void BindWewenangDireksi()
        {
            List<WewenangDireksi> coll = new List<WewenangDireksi>();
            if (ViewState["WewenangDireksi"] != null)
                coll = ViewState["WewenangDireksi"] as List<WewenangDireksi>;

            dgWewenangDireksi.DataSource = coll;
            dgWewenangDireksi.DataBind();

            upWewenangDireksi.Update();
        }

        protected void dgWewenangDireksi_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                TextBox txtNamaAdd = e.Item.FindControl("txtNamaAdd") as TextBox;
                txtNamaAdd.Attributes.Add("onkeyup", "WewenangDireksi('" + txtNamaAdd.ClientID + "');");
            }
            else if (e.Item.ItemType == ListItemType.EditItem)
            {
                TextBox txtNamaEdit = e.Item.FindControl("txtNamaEdit") as TextBox;
                txtNamaEdit.Attributes.Add("onkeyup", "WewenangDireksi('" + txtNamaEdit.ClientID + "');");
            }
        }

        protected void dgWewenangDireksi_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            DataGrid dg = source as DataGrid;
            List<WewenangDireksi> coll = new List<WewenangDireksi>();
            if (ViewState["WewenangDireksi"] != null)
                coll = ViewState["WewenangDireksi"] as List<WewenangDireksi>;

            if (e.CommandName == "add")
            {
                TextBox txtNamaAdd = e.Item.FindControl("txtNamaAdd") as TextBox;

                if (isExistInWewenangDireksiGrid(txtNamaAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaAdd.Text.Trim()));
                    return;
                }

                WewenangDireksi o = new WewenangDireksi();
                o.Nama = txtNamaAdd.Text.Trim();
                o.ID = 0;
                coll.Add(o);

                ViewState["WewenangDireksi"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtNamaEdit = e.Item.FindControl("txtNamaEdit") as TextBox;

                if (isExistInWewenangDireksiGrid(txtNamaEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaEdit.Text.Trim()));
                    return;
                }

                WewenangDireksi o = new WewenangDireksi();
                o.Nama = txtNamaEdit.Text.Trim();

                coll[e.Item.ItemIndex] = o;
                ViewState["WewenangDireksi"] = coll;

                dg.EditItemIndex = -1;
                dg.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dg.ShowFooter = false;
                dg.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dg.EditItemIndex = -1;
                dg.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["WewenangDireksi"] = coll;
            }
            BindWewenangDireksi();
        }

        #endregion

        #region Dokumen

        private bool isExistInDokumenGrid(string Nama, string Label)
        {
            foreach (DataGridItem item in dgDokumenLainnya.Items)
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

        private void BindDokumen()
        {
            List<Dokumen> coll = new List<Dokumen>();
            if (ViewState["Dokumen"] != null)
                coll = ViewState["Dokumen"] as List<Dokumen>;

            dgDokumenLainnya.DataSource = coll;
            dgDokumenLainnya.DataBind();
        }

        protected void dgDokumenLainnya_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
                return;

            Dokumen o = e.Item.DataItem as Dokumen;

            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DropDownList ddlTipeDokumenEdit = e.Item.FindControl("ddlTipeDokumenEdit") as DropDownList;
                ddlTipeDokumenEdit.SelectedValue = o.TipeDokumen;
            }

            if (!string.IsNullOrEmpty(o.Url))
            {
                Label lblAtttachment = e.Item.FindControl("lblAtttachment") as Label;
                lblAtttachment.Text = o.Url;
            }
        }

        protected void dgDokumenLainnya_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<Dokumen> coll = new List<Dokumen>();
            if (ViewState["Dokumen"] != null)
                coll = ViewState["Dokumen"] as List<Dokumen>;

            if (e.CommandName == "add")
            {
                TextBox txtPenjelasanAdd = e.Item.FindControl("txtPenjelasanAdd") as TextBox;
                FileUpload fuAdd = e.Item.FindControl("fuAdd") as FileUpload;
                DropDownList ddlTipeDokumenAdd = e.Item.FindControl("ddlTipeDokumenAdd") as DropDownList;

                if (isExistInDokumenGrid(fuAdd.FileName, "lblAtttachmentHidden"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(fuAdd.FileName));
                    return;
                }

                Dokumen o = new Dokumen();

                Stream strm = fuAdd.PostedFile.InputStream;
                byte[] bytes = new byte[Convert.ToInt32(fuAdd.PostedFile.ContentLength)];
                strm.Read(bytes, 0, Convert.ToInt32(fuAdd.PostedFile.ContentLength));
                strm.Close();

                o.Attachment = bytes;
                o.TipeDokumen = ddlTipeDokumenAdd.SelectedValue;
                o.NamaFile = fuAdd.FileName;
                o.Penjelasan = txtPenjelasanAdd.Text.Trim();
                o.ID = 0;
                coll.Add(o);

                ViewState["Dokumen"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtPenjelasanEdit = e.Item.FindControl("txtPenjelasanEdit") as TextBox;
                FileUpload fuEdit = e.Item.FindControl("fuEdit") as FileUpload;
                DropDownList ddlTipeDokumenEdit = e.Item.FindControl("ddlTipeDokumenEdit") as DropDownList;

                if (isExistInDokumenGrid(fuEdit.FileName, "lblAtttachmentHidden"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(fuEdit.FileName));
                    return;
                }

                Dokumen o = coll[e.Item.ItemIndex];

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

                o.Penjelasan = txtPenjelasanEdit.Text.Trim();
                o.TipeDokumen = ddlTipeDokumenEdit.SelectedValue;

                coll[e.Item.ItemIndex] = o;
                ViewState["Dokumen"] = coll;

                dgDokumenLainnya.EditItemIndex = -1;
                dgDokumenLainnya.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgDokumenLainnya.ShowFooter = false;
                dgDokumenLainnya.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgDokumenLainnya.EditItemIndex = -1;
                dgDokumenLainnya.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["Dokumen"] = coll;
            }
            BindDokumen();
        }

        #endregion

        #region NPWP

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

        private void BindNPWP()
        {
            List<NPWP> coll = new List<NPWP>();
            if (ViewState["NPWP"] != null)
                coll = ViewState["NPWP"] as List<NPWP>;

            dgNPWPLainnya.DataSource = coll;
            dgNPWPLainnya.DataBind();
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

                NPWP o = coll[e.Item.ItemIndex];
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

        #region NPWP

        private bool isExistInPKPGrid(string Nama, string Label)
        {
            foreach (DataGridItem item in dgPKPLainnya.Items)
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

        private void BindPKP()
        {
            List<PKP> coll = new List<PKP>();
            if (ViewState["PKP"] != null)
                coll = ViewState["PKP"] as List<PKP>;

            dgPKPLainnya.DataSource = coll;
            dgPKPLainnya.DataBind();
        }

        protected void dgPKPLainnya_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0)
                return;

            PKP o = e.Item.DataItem as PKP;

            if (!string.IsNullOrEmpty(o.Url))
            {
                Label lblAtttachment = e.Item.FindControl("lblAtttachment") as Label;
                lblAtttachment.Text = o.Url;
            }
        }

        protected void dgPKPLainnya_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            List<PKP> coll = new List<PKP>();
            if (ViewState["PKP"] != null)
                coll = ViewState["PKP"] as List<PKP>;

            if (e.CommandName == "add")
            {
                TextBox txtPKPAdd = e.Item.FindControl("txtPKPAdd") as TextBox;
                TextBox txtKeteranganAdd = e.Item.FindControl("txtKeteranganAdd") as TextBox;
                FileUpload fuAdd = e.Item.FindControl("fuAdd") as FileUpload;

                if (isExistInPKPGrid(txtPKPAdd.Text, "lblNPWP"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtPKPAdd.Text.Trim()));
                    return;
                }

                if (isExistInPKPGrid(fuAdd.FileName, "lblAtttachmentHidden"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(fuAdd.FileName));
                    return;
                }

                PKP o = new PKP();
                o.NoPKP = txtPKPAdd.Text.Trim();

                Stream strm = fuAdd.PostedFile.InputStream;
                byte[] bytes = new byte[Convert.ToInt32(fuAdd.PostedFile.ContentLength)];
                strm.Read(bytes, 0, Convert.ToInt32(fuAdd.PostedFile.ContentLength));
                strm.Close();

                o.Attachment = bytes;
                o.NamaFile = fuAdd.FileName;
                o.Keterangan = txtKeteranganAdd.Text.Trim();
                o.ID = 0;
                coll.Add(o);

                ViewState["PKP"] = coll;
            }
            if (e.CommandName == "save")
            {
                TextBox txtPKPEdit = e.Item.FindControl("txtPKPEdit") as TextBox;
                TextBox txtKeteranganEdit = e.Item.FindControl("txtKeteranganEdit") as TextBox;
                FileUpload fuEdit = e.Item.FindControl("fuEdit") as FileUpload;

                if (isExistInPKPGrid(txtPKPEdit.Text, "lblNPWP"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtPKPEdit.Text.Trim()));
                    return;
                }

                if (isExistInPKPGrid(fuEdit.FileName, "lblAtttachmentHidden"))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(fuEdit.FileName));
                    return;
                }

                PKP o = coll[e.Item.ItemIndex];
                o.NoPKP = txtPKPEdit.Text.Trim();

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
                ViewState["PKP"] = coll;

                dgPKPLainnya.EditItemIndex = -1;
                dgPKPLainnya.ShowFooter = true;
            }
            if (e.CommandName == "edit")
            {
                dgPKPLainnya.ShowFooter = false;
                dgPKPLainnya.EditItemIndex = e.Item.ItemIndex;
            }
            if (e.CommandName == "cancel")
            {
                dgPKPLainnya.EditItemIndex = -1;
                dgPKPLainnya.ShowFooter = true;
            }
            if (e.CommandName == "delete")
            {
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["PKP"] = coll;
            }
            BindPKP();
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
                    hfIDPemohon.Value = IDPemohon.ToString();
                    txtNamaPemohon.Text = item.Title;
                    txtEmailPemohon.Text = item["EmailPemohon"].ToString();
                }
            }

            BindKomisarisDireksi();
            BindPemegangSaham();
            BindWewenangDireksi();
            BindDokumen();

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
