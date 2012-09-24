using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;

using SPVisionet.CorporateSecretary.Common;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace SPVisionet.CorporateSecretary.WebParts.PerubahanPTBiasaMenjadiPMAPMDN
{
    public partial class PerubahanPTBiasaMenjadiPMAPMDNUserControl : UserControl
    {
        #region Properties

        private SPWeb web;
        private int IDP = 0;
        private string Source = string.Empty;
        private string Mode = string.Empty;

        [Serializable]
        private class PemegangSaham
        {
            public int ID { get; set; }
            public string Nama { get; set; }
            public double JumlahSaham { get; set; }
            public double JumlahNominal { get; set; }
            public double Percentages { get; set; }
            public bool Partner { get; set; }
        }

        #endregion

        #region Methods

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

        private void BindStatusPerseroan()
        {
            DataTable dt = Util.GetStatusPerseroan(web);
            ddlStatusPerseroan.DataTextField = "Title";
            ddlStatusPerseroan.DataValueField = "ID";
            ddlStatusPerseroan.DataSource = dt;
            ddlStatusPerseroan.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlStatusPerseroan.Items.Insert(0, item);
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty)
            {
                if (txtAlasanPerubahan.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Alasan Perubahan") + " \\n");
                if (txtNamaPemohon.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nama Pemohon") + " \\n");
                if (txtEmailPemohon.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Email Pemohon") + " \\n");
                if (txtNamaPerusahaan.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nama Perusahaan") + " \\n");
                if (ddlTempatKedudukan.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Tempat Kedudukan") + " \\n");
                if (txtAlamat.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Alamat") + " \\n");
                if (txtBidangUsaha.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Bidang Usaha") + " \\n");
                if (ddlStatusPerseroan.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Status Perseroan") + " \\n");
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

                decimal NilaiInvestasi = 0;
                if (txtNilaiInvestasi.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nilai Investasi") + " \\n");
                else
                {
                    try
                    {
                        NilaiInvestasi = Convert.ToDecimal(txtNilaiInvestasi.Text.Trim());
                    }
                    catch
                    {
                        sb.Append(SR.IntegerData("Nilai Investasi") + " \\n");
                    }
                }

                if (txtModalSendiri.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Modal Sendiri") + " \\n");
                else
                {
                    try
                    {
                        Convert.ToDecimal(txtModalSendiri.Text.Trim());
                    }
                    catch
                    {
                        sb.Append(SR.IntegerData("Modal Sendiri") + " \\n");
                    }
                }
                decimal ModalSendiri = 0;
                txtModalSendiri.Text = Convert.ToDecimal(txtNominalModalSetor.Text).ToString("#,##0");
                ModalSendiri = Convert.ToDecimal(txtModalSendiri.Text);

                decimal ModalLabaDitanamKembali = 0;
                if (txtModalDitanamKembali.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Modal Laba ditanam kembali") + " \\n");
                else
                {
                    try
                    {
                        ModalLabaDitanamKembali = Convert.ToDecimal(txtModalDitanamKembali.Text.Trim());
                    }
                    catch
                    {
                        sb.Append(SR.IntegerData("Modal Laba ditanam kembali") + " \\n");
                    }
                }

                decimal ModalPinjaman = 0;
                if (txtModalPinjaman.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Modal Pinjaman") + " \\n");
                //else
                //{
                //    try
                //    {
                //        ModalPinjaman = Convert.ToDecimal(txtModalPinjaman.Text.Trim());
                //    }
                //    catch
                //    {
                //        sb.Append(SR.IntegerData("Modal Pinjaman") + " \\n");
                //    }
                //}

                ModalPinjaman = NilaiInvestasi - ModalSendiri - ModalLabaDitanamKembali;
                txtModalPinjaman.Text = ModalPinjaman.ToString("#,##0");

                if ((NominalSaham * ModalSetor) != ModalSendiri)
                    sb.Append("Modal Sendiri must be equal to Nominal Modal Setor\\n");

                if (NilaiInvestasi != (ModalSendiri + ModalLabaDitanamKembali + ModalPinjaman))
                    sb.Append("Nilai Investasi must be equal to (Modal Sendiri + Modal Laba ditanam kembali + Modal Pinjaman)\\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC)
            {
                if (IDP == 0)
                {
                    if (!fu.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Surat Persetujuan PMA / PMDN Baru") + " \\n");
                }
                if (txtNo.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
                if (dtTanggalMulaiBerlaku.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku") + " \\n");
                if (dtTanggalAkhirBerlaku.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Berlaku") + " \\n");
                int i = DateTime.Compare(dtTanggalMulaiBerlaku.SelectedDate, dtTanggalAkhirBerlaku.SelectedDate);
                if (i > 0)
                    sb.Append("Tanggal Akhir Berlaku must be greater or equal than Tanggal Mulai Berlaku\\n");
            }

            return sb.ToString();
        }

        private void Display(string mode)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDN"));
            SPListItem item = list.GetItemById(IDP);

            if (item["Status"] != null)
                ViewState["Status"] = item["Status"].ToString();
            else
            {
                if (item["ApprovalStatus"] != null)
                    ViewState["Status"] = item["ApprovalStatus"].ToString();
            }

            if (item.Workflows.Count > 0 || ViewState["Status"].ToString() == "Approved")
                btnSaveUpdateRunWf.Visible = false;

            ltrRequestCode.Text = item["Title"].ToString();
            ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
            txtKodePerusahaan.Text = item["KodePerusahaan"].ToString();
            txtAlasanPerubahan.Text = item["AlasanPerubahan"].ToString();
            txtNamaPerusahaan.Text = item["NamaPerusahaan"].ToString();
            txtAlamat.Text = item["Alamat"] == null ? string.Empty : item["Alamat"].ToString();
            if (item["TempatKedudukan"] != null)
                ddlTempatKedudukan.SelectedValue = item["TempatKedudukan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            txtBidangUsaha.Text = item["BidangUsaha"].ToString();
            if (item["MataUang"] != null)
            {
                ddlMataUang.SelectedValue = item["MataUang"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
                ltrMataUangSelected.Text = ddlMataUang.SelectedItem.Text;
            }
            txtModalDasar.Text = Convert.ToDouble(item["ModalDasar"]).ToString("#,##0");
            txtModalSetor.Text = Convert.ToDouble(item["ModalSetor"]).ToString("#,##0");
            txtNominalSaham.Text = Convert.ToDouble(item["Nominal"]).ToString("#,##0");
            txtNominalModalDasar.Text = (Convert.ToDouble(txtModalDasar.Text) * Convert.ToDouble(txtNominalSaham.Text)).ToString("#,##0");
            txtNominalModalSetor.Text = (Convert.ToDouble(txtModalSetor.Text) * Convert.ToDouble(txtNominalSaham.Text)).ToString("#,##0");
            txtKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
            if (item["StatusPerseroan"] != null)
                ddlStatusPerseroan.SelectedValue = item["StatusPerseroan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];

            txtNilaiInvestasi.Text = Convert.ToDouble(item["NilaiInvestasi"]).ToString("#,##0");
            txtModalSendiri.Text = Convert.ToDouble(txtNominalModalSetor.Text).ToString("#,##0");
            if (item["ModalDitanamKembali"] != null)
                txtModalDitanamKembali.Text = Convert.ToDouble(item["ModalDitanamKembali"]).ToString("#,##0");
            txtModalPinjaman.Text = (Convert.ToDouble(txtNilaiInvestasi.Text) - Convert.ToDouble(txtModalSendiri.Text) - Convert.ToDouble(txtModalDitanamKembali.Text)).ToString("#,##0");

            if (item["Pemohon"] != null)
            {
                int IDPemohon = Convert.ToInt32(item["Pemohon"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                hfIDPemohon.Value = IDPemohon.ToString();
                SPList listPemohon = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
                SPListItem itemPemohon = listPemohon.GetItemById(IDPemohon);
                txtNamaPemohon.Text = itemPemohon.Title;
                txtEmailPemohon.Text = itemPemohon["EmailPemohon"].ToString();
            }

            txtNo.Text = item["No"] == null ? string.Empty : item["No"].ToString();
            if (item["TanggalMulaiBerlaku"] != null)
                dtTanggalMulaiBerlaku.SelectedDate = Convert.ToDateTime(item["TanggalMulaiBerlaku"]);
            if (item["TanggalAkhirBerlaku"] != null)
                dtTanggalAkhirBerlaku.SelectedDate = Convert.ToDateTime(item["TanggalAkhirBerlaku"]);
            txtKeteranganPMAPMDN.Text = item["KeteranganPMAPMDN"] == null ? string.Empty : item["KeteranganPMAPMDN"].ToString();

            ltrKodePerusahaan.Text = txtKodePerusahaan.Text;
            ltrAlasanPerubahan.Text = txtAlasanPerubahan.Text;
            ltrNamaPerusahaaan.Text = txtNamaPerusahaan.Text;
            if (item["TempatKedudukan"] != null)
                ltrTempatKedudukan.Text = ddlTempatKedudukan.SelectedItem.Text;
            ltrBidangUsaha.Text = txtBidangUsaha.Text;
            if (item["MataUang"] != null)
            {
                ltrMataUang.Text = ddlMataUang.SelectedItem.Text;
                ltrMataUangSelected.Text = ddlMataUang.SelectedItem.Text;
            }
            ltrAlamat.Text = txtAlamat.Text;
            ltrModalDasar.Text = Convert.ToDouble(txtModalDasar.Text).ToString("#,##0");
            ltrModalSetor.Text = Convert.ToDouble(txtModalSetor.Text).ToString("#,##0");
            ltrNominalSaham.Text = Convert.ToDouble(txtNominalSaham.Text).ToString("#,##0");
            ltrNominalModalDasar.Text = (Convert.ToDouble(ltrModalDasar.Text) * Convert.ToDouble(ltrNominalSaham.Text)).ToString("#,##0");
            ltrNominalModalSetor.Text = (Convert.ToDouble(ltrModalSetor.Text) * Convert.ToDouble(ltrNominalSaham.Text)).ToString("#,##0");
            ltrKeterangan.Text = txtKeterangan.Text;
            if (item["StatusPerseroan"] != null)
                ltrStatusPerseroan.Text = ddlStatusPerseroan.SelectedItem.Text;

            ltrNilaiInvestasi.Text = Convert.ToDouble(txtNilaiInvestasi.Text).ToString("#,##0");
            ltrModalSendiri.Text = Convert.ToDouble(txtNominalModalSetor.Text).ToString("#,##0");
            if (item["ModalDitanamKembali"] != null)
                ltrModalDitanamKembali.Text = Convert.ToDouble(txtModalDitanamKembali.Text).ToString("#,##0");
            ltrModalPinjaman.Text = (Convert.ToDouble(ltrNilaiInvestasi.Text) - Convert.ToDouble(ltrModalSendiri.Text) - Convert.ToDouble(ltrModalDitanamKembali.Text)).ToString("#,##0");

            ltrNamaPemohon.Text = txtNamaPemohon.Text;
            ltrEmailPemohon.Text = txtEmailPemohon.Text;

            ltrNo.Text = txtNo.Text;
            if (item["TanggalMulaiBerlaku"] != null)
                ltrTanggalMulaiBerlaku.Text = dtTanggalMulaiBerlaku.SelectedDate.ToString("dd-MMM-yyyy");
            if (item["TanggalAkhirBerlaku"] != null)
                ltrTanggalAkhirBerlaku.Text = dtTanggalAkhirBerlaku.SelectedDate.ToString("dd-MMM-yyyy");
            ltrKeteranganPMAPMDN.Text = txtKeteranganPMAPMDN.Text;

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

            SPList listPemegangSaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PemegangSahamPerubahanPTBiasaMenjadiPMAPMDN"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='PerubahanPTBiasaMenjadiPMAPMDN' LookupId='True' />" +
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
                collPemegangSaham.Add(o);
            }
            ViewState["PemegangSaham"] = collPemegangSaham;
            ViewState["PemegangSahamEdit"] = collPemegangSaham;
            BindPemegangSaham();

            SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDNDokumen"));
            SPListItemCollection coll = document.GetItems(query);
            if (coll.Count > 0)
            {
                SPListItem documentItem = coll[0];
                ltrfu.Text = string.Format("<a href='{0}/PerubahanPTBiasaMenjadiPMAPMDNDokumen/{1}'>{1}</a>", web.Url, documentItem["Name"].ToString());
                if (documentItem["Original"] != null)
                {
                    ltrOriginal.Text = Convert.ToBoolean(documentItem["Original"]) == true ? "Original" : "Copy";
                    chkOriginal.Checked = Convert.ToBoolean(documentItem["Original"]);
                }
            }

            if (item["Status"] != null)
            {
                if (item["Status"].ToString() == Roles.PIC_CORSEC)
                    pnlOriginator.Visible = true;
                else
                {
                    pnlOriginator.Visible = false;
                    pnlAssign.Visible = false;
                    btnSaveUpdate.Visible = false;
                }
            }
            if (item["ApprovalStatus"] != null)
            {
                if (item["ApprovalStatus"].ToString() == "Approved")
                {
                    pnlOriginator.Visible = true;
                    pnlAssign.Visible = true;

                    ltrPICCorsec.Text = item["Created By"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    ltrDivHead.Text = item["DivHead"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    ltrChiefCS.Text = item["ChiefCorsec"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                }
            }

            HiddenControls(mode, item["Status"] == null ? string.Empty : item["Status"].ToString());
        }

        private void HiddenControls(string mode, string status)
        {
            if (mode == "display")
            {
                txtKodePerusahaan.Visible = false;
                txtAlasanPerubahan.Visible = false;
                txtNamaPemohon.Visible = false;
                txtEmailPemohon.Visible = false;
                txtAlamat.Visible = false;
                imgbtnNamaPemohon.Visible = false;
                imgbtnNamaPerusahaan.Visible = false;
                txtNamaPerusahaan.Visible = false;
                ddlTempatKedudukan.Visible = false;
                txtBidangUsaha.Visible = false;
                ddlStatusPerseroan.Visible = false;
                ddlMataUang.Visible = false;
                txtModalDasar.Visible = false;
                txtNominalModalDasar.Visible = false;
                txtModalSetor.Visible = false;
                txtNominalModalSetor.Visible = false;
                txtNominalSaham.Visible = false;
                txtKeterangan.Visible = false;
                txtNilaiInvestasi.Visible = false;
                txtModalSendiri.Visible = false;
                txtModalDitanamKembali.Visible = false;
                txtModalPinjaman.Visible = false;

                fu.Visible = false;
                txtNo.Visible = false;
                dtTanggalMulaiBerlaku.Visible = false;
                dtTanggalAkhirBerlaku.Visible = false;
                txtKeteranganPMAPMDN.Visible = false;
                chkOriginal.Visible = false;

                dgPemegangSaham.ShowFooter = false;
                dgPemegangSaham.Columns[6].Visible = false;
            }
            else if (mode == "edit")
            {
                if (status == Roles.PIC_CORSEC)
                {
                    txtKodePerusahaan.Visible = false;
                    txtAlasanPerubahan.Visible = false;
                    txtNamaPemohon.Visible = false;
                    txtEmailPemohon.Visible = false;
                    txtAlamat.Visible = false;
                    imgbtnNamaPemohon.Visible = false;
                    imgbtnNamaPerusahaan.Visible = false;
                    txtNamaPerusahaan.Visible = false;
                    ddlTempatKedudukan.Visible = false;
                    txtBidangUsaha.Visible = false;
                    ddlStatusPerseroan.Visible = false;
                    ddlMataUang.Visible = false;
                    txtModalDasar.Visible = false;
                    txtNominalModalDasar.Visible = false;
                    txtModalSetor.Visible = false;
                    txtNominalModalSetor.Visible = false;
                    txtNominalSaham.Visible = false;
                    txtKeterangan.Visible = false;
                    txtNilaiInvestasi.Visible = false;
                    txtModalSendiri.Visible = false;
                    txtModalDitanamKembali.Visible = false;
                    txtModalPinjaman.Visible = false;

                    dgPemegangSaham.ShowFooter = false;
                    dgPemegangSaham.Columns[6].Visible = false;
                }
                else
                {
                    ltrKodePerusahaan.Visible = false;
                    ltrAlasanPerubahan.Visible = false;
                    ltrNamaPemohon.Visible = false;
                    ltrEmailPemohon.Visible = false;
                    imgbtnNamaPemohon.Visible = false;
                    ltrNamaPerusahaaan.Visible = false;
                    ltrTempatKedudukan.Visible = false;
                    ltrBidangUsaha.Visible = false;
                    ltrAlamat.Visible = false;
                    ltrStatusPerseroan.Visible = false;
                    ltrMataUang.Visible = false;
                    ltrModalDasar.Visible = false;
                    ltrNominalModalDasar.Visible = false;
                    ltrModalSetor.Visible = false;
                    ltrNominalModalSetor.Visible = false;
                    ltrNominalSaham.Visible = false;
                    ltrKeterangan.Visible = false;
                    ltrKeterangan.Visible = false;
                    ltrNilaiInvestasi.Visible = false;
                    ltrModalSendiri.Visible = false;
                    ltrModalDitanamKembali.Visible = false;
                    ltrModalPinjaman.Visible = false;
                }

                ltrNo.Visible = false;
                ltrTanggalMulaiBerlaku.Visible = false;
                ltrTanggalAkhirBerlaku.Visible = false;
                ltrKeteranganPMAPMDN.Visible = false;
                ltrOriginal.Visible = false;

                if (ltrfu.Text.Trim() == string.Empty)
                    reqfu.Visible = true;
                else
                    reqfu.Visible = false;
            }
        }

        private string SaveUpdate(string mode)
        {
            SPWeb currentWeb = SPContext.Current.Web;
            SPList list = currentWeb.GetList(Util.CreateSharePointListStrUrl(currentWeb.Url, "PerubahanPTBiasaMenjadiPMAPMDN"));
            currentWeb.AllowUnsafeUpdates = true;

            SPListItem item;
            try
            {
                if (IDP == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, RequestCode.PERUBAHAN_PT_BIASA_MENJADI_PMAPMDN, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(IDP);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty)
                {
                    item["KodePerusahaan"] = txtKodePerusahaan.Text;
                    item["Tanggal"] = Convert.ToDateTime(ltrDate.Text);
                    item["AlasanPerubahan"] = txtAlasanPerubahan.Text.Trim();
                    item["Pemohon"] = hfIDPemohon.Value.ToString();
                    item["NamaPerusahaan"] = txtNamaPerusahaan.Text.Trim();
                    item["TempatKedudukan"] = ddlTempatKedudukan.SelectedValue;
                    item["BidangUsaha"] = txtBidangUsaha.Text.Trim();
                    item["Alamat"] = txtAlamat.Text.Trim();
                    item["StatusPerseroan"] = ddlStatusPerseroan.SelectedValue;
                    item["MataUang"] = ddlMataUang.SelectedValue;
                    item["ModalDasar"] = txtModalDasar.Text.Trim();
                    item["ModalSetor"] = txtModalSetor.Text.Trim();
                    item["Nominal"] = txtNominalSaham.Text.Trim();
                    item["NilaiInvestasi"] = txtNilaiInvestasi.Text.Trim();
                    item["ModalDitanamKembali"] = txtModalDitanamKembali.Text.Trim();
                    item["Keterangan"] = txtKeterangan.Text.Trim();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC)
                {
                    item["No"] = txtNo.Text.Trim();
                    item["TanggalMulaiBerlaku"] = dtTanggalMulaiBerlaku.SelectedDate;
                    item["TanggalAkhirBerlaku"] = dtTanggalAkhirBerlaku.SelectedDate;
                    item["KeteranganPMAPMDN"] = txtKeteranganPMAPMDN.Text.Trim();
                }
                item.Update();
                currentWeb.AllowUnsafeUpdates = false;

                ViewState["ID"] = item.ID;

                int j = 0;
                SPList listPemegangSaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PemegangSahamPerubahanPTBiasaMenjadiPMAPMDN"));
                web.AllowUnsafeUpdates = true;
                if (IDP == 0)
                {
                    List<PemegangSaham> collPemegangSaham = ViewState["PemegangSaham"] as List<PemegangSaham>;
                    foreach (PemegangSaham i in collPemegangSaham)
                    {
                        SPListItem itemPemegangSaham;
                        if (i.ID == 0)
                        {
                            itemPemegangSaham = listPemegangSaham.Items.Add();
                            itemPemegangSaham["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        }
                        else
                        {
                            itemPemegangSaham = listPemegangSaham.GetItemById(i.ID);
                            itemPemegangSaham["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        }

                        itemPemegangSaham["PerubahanPTBiasaMenjadiPMAPMDN"] = item.ID;
                        itemPemegangSaham["Title"] = i.Nama;
                        itemPemegangSaham["JumlahSaham"] = i.JumlahSaham;
                        itemPemegangSaham["JumlahNominal"] = i.JumlahNominal;
                        itemPemegangSaham["Percentages"] = i.Percentages;
                        itemPemegangSaham["Partner"] = i.Partner;
                        itemPemegangSaham.Update();

                        collPemegangSaham[j].ID = itemPemegangSaham.ID;

                        j += 1;
                    }
                }
                else
                {
                    if (dgPemegangSaham.Items.Count > 0)
                    {
                        j = 0;
                        List<PemegangSaham> collPemegangSaham = ViewState["PemegangSaham"] as List<PemegangSaham>;
                        foreach (PemegangSaham i in collPemegangSaham)
                        {
                            SPListItem itemPemegangSaham;
                            if (i.ID != 0)
                            {
                                itemPemegangSaham = listPemegangSaham.GetItemById(i.ID);
                                itemPemegangSaham["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }
                            else
                            {
                                itemPemegangSaham = listPemegangSaham.Items.Add();
                                itemPemegangSaham["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                            }

                            itemPemegangSaham["PerubahanPTBiasaMenjadiPMAPMDN"] = item.ID;
                            itemPemegangSaham["Title"] = i.Nama;
                            itemPemegangSaham["JumlahSaham"] = i.JumlahSaham;
                            itemPemegangSaham["JumlahNominal"] = i.JumlahNominal;
                            itemPemegangSaham["Percentages"] = i.Percentages;
                            itemPemegangSaham["Partner"] = i.Partner;
                            itemPemegangSaham.Update();

                            collPemegangSaham[j].ID = itemPemegangSaham.ID;

                            j += 1;
                        }
                    }

                    if (ViewState["PemegangSahamEdit"] != null)
                    {
                        List<PemegangSaham> collPemegangSahamEdit = ViewState["PemegangSahamEdit"] as List<PemegangSaham>;
                        foreach (PemegangSaham itemEdit in collPemegangSahamEdit)
                        {
                            bool isExist = false;
                            foreach (DataGridItem dgItem in dgPemegangSaham.Items)
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
                }
                web.AllowUnsafeUpdates = false;

                if (fu.PostedFile.ContentLength > 0)
                {
                    string fileName = fu.FileName.Replace("&", string.Empty);

                    try
                    {
                        Stream strm = fu.PostedFile.InputStream;
                        byte[] bytes = new byte[Convert.ToInt32(fu.PostedFile.ContentLength)];
                        strm.Read(bytes, 0, Convert.ToInt32(fu.PostedFile.ContentLength));
                        strm.Close();

                        SPFolder document = web.Folders["PerubahanPTBiasaMenjadiPMAPMDNDokumen"];
                        web.AllowUnsafeUpdates = true;
                        SPFile file = document.Files.Add(fileName, bytes);
                        SPItem itemDocument = file.Item;
                        itemDocument["Title"] = Path.GetFileNameWithoutExtension(fileName);
                        itemDocument["PerubahanPTBiasaMenjadiPMAPMDN"] = item.ID;
                        itemDocument["Original"] = chkOriginal.Checked;
                        itemDocument["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                        itemDocument.Update();
                        web.AllowUnsafeUpdates = false;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("already exist"))
                            return SR.DataIsExist(fileName);
                        else
                            return SR.AttachmentFailed(fileName);
                    }
                }
                else
                {
                    if (IDP != 0)
                    {
                        SPQuery query = new SPQuery();
                        query.Query = "<Where>" +
                                          "<Eq>" +
                                             "<FieldRef Name='PerubahanPTBiasaMenjadiPMAPMDN' LookupId='True' />" +
                                             "<Value Type='Lookup'>" + IDP + "</Value>" +
                                          "</Eq>" +
                                      "</Where>" +
                                      "<OrderBy>" +
                                        "<FieldRef Name='Created' Ascending='False' />" +
                                      "</OrderBy>";

                        SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDNDokumen"));
                        SPListItemCollection coll = document.GetItems(query);
                        if (coll.Count > 0)
                        {
                            SPListItem documentItem = coll[0];
                            documentItem.Web.AllowUnsafeUpdates = true;
                            documentItem["Original"] = chkOriginal.Checked;
                            documentItem.Update();
                            documentItem.Web.AllowUnsafeUpdates = false;
                        }
                    }
                }

                if (item["Status"] == null)
                {
                    if (mode == "SaveRunWf")
                    {
                        if (list.WorkflowAssociations.Count > 0)
                        {
                            string WfId = Util.GetSettingValue(web, "Workflow BasedId", "Perubahan PT Biasa menjadi PMA/PMDN");
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
            Util.RegisterStartupScript(Page, "Pemohon", "RegisterDialog('divPemohonSearch','divPemohonDlgContainer', '480');");
            Util.RegisterStartupScript(Page, "Perusahaan", "RegisterDialog('divPerusahaanSearch','divPerusahaanDlgContainer', '630');");

            Pemohon.btnSelectedData.Click += new EventHandler(btnSelectedDataPemohon_Click);
            //Pemohon.btnClosedData.Click += new EventHandler(btnClosedData_Click);

            Perusahaan.btnSelectedData.Click += new EventHandler(btnSelectedDataPerusahaan_Click);
            //Perusahaan.btnClosedSearch.Click += new EventHandler(btnClosedSearch_Click);

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

                    if (!IsPostBack)
                    {
                        ViewState["Status"] = string.Empty;

                        string AdministratorGroup = Util.GetSettingValue(web, "SharePoint Group", "Administrator");
                        ViewState["Admin"] = Util.IsUserExistInSharePointGroup(web, SPContext.Current.Web.CurrentUser.LoginName, AdministratorGroup);
                        if (Convert.ToBoolean(ViewState["Admin"]) == true)
                        {
                            pnlOriginator.Visible = true;
                            pnlAssign.Visible = true;
                        }

                        txtModalDasar.Attributes.Add("onkeyup", "FormatNumber('" + txtModalDasar.ClientID + "'); Total('" + txtModalDasar.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalDasar.ClientID + "');");
                        txtModalDasar.Attributes.Add("onblur", " FormatNumber('" + txtModalDasar.ClientID + "')");

                        txtModalSetor.Attributes.Add("onkeyup", "FormatNumber('" + txtModalSetor.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalSetor.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtModalSendiri.ClientID + "'); TotalPembiayaan('" + txtNilaiInvestasi.ClientID + "','" + txtModalSendiri.ClientID + "','" + txtModalDitanamKembali.ClientID + "','" + txtModalPinjaman.ClientID + "');");
                        txtModalSetor.Attributes.Add("onblur", " FormatNumber('" + txtModalSetor.ClientID + "')");

                        txtNominalSaham.Attributes.Add("onkeyup", "FormatNumber('" + txtNominalSaham.ClientID + "'); Total('" + txtModalDasar.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalDasar.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalSetor.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtModalSendiri.ClientID + "'); TotalPembiayaan('" + txtNilaiInvestasi.ClientID + "','" + txtModalSendiri.ClientID + "','" + txtModalDitanamKembali.ClientID + "','" + txtModalPinjaman.ClientID + "');");
                        txtNominalSaham.Attributes.Add("onblur", " FormatNumber('" + txtNominalSaham.ClientID + "')");

                        txtNilaiInvestasi.Attributes.Add("onkeyup", "FormatNumber('" + txtNilaiInvestasi.ClientID + "'); TotalPembiayaan('" + txtNilaiInvestasi.ClientID + "','" + txtModalSendiri.ClientID + "','" + txtModalDitanamKembali.ClientID + "','" + txtModalPinjaman.ClientID + "');");
                        txtNilaiInvestasi.Attributes.Add("onblur", " FormatNumber('" + txtNilaiInvestasi.ClientID + "')");

                        txtModalDitanamKembali.Attributes.Add("onkeyup", "FormatNumber('" + txtModalDitanamKembali.ClientID + "'); TotalPembiayaan('" + txtNilaiInvestasi.ClientID + "','" + txtModalSendiri.ClientID + "','" + txtModalDitanamKembali.ClientID + "','" + txtModalPinjaman.ClientID + "');");
                        txtModalDitanamKembali.Attributes.Add("onblur", " FormatNumber('" + txtModalDitanamKembali.ClientID + "')");

                        ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                        BindTempatKedudukan();
                        BindMataUang();
                        BindStatusPerseroan();

                        if (isID)
                            Display(Mode);
                        else
                            BindPemegangSaham();
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
                    Response.Redirect(string.Format("{0}/Lists/PerubahanPTBiasaMenjadiPMAPMDN", web.Url), true);
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
                Response.Redirect(string.Format("{0}/Lists/PerubahanPTBiasaMenjadiPMAPMDN", web.Url), true);
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
            if (e.Item.ItemType == ListItemType.Footer)
            {
                TextBox txtJumlahSahamAdd = e.Item.FindControl("txtJumlahSahamAdd") as TextBox;
                TextBox txtJumlahNominalAdd = e.Item.FindControl("txtJumlahNominalAdd") as TextBox;
                TextBox txtPercentagesAdd = e.Item.FindControl("txtPercentagesAdd") as TextBox;

                txtJumlahSahamAdd.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamAdd.ClientID + "'); Total('" + txtJumlahSahamAdd.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtJumlahNominalAdd.ClientID + "'); Percentages('" + txtJumlahSahamAdd.ClientID + "','" + txtModalSetor.ClientID + "','" + txtPercentagesAdd.ClientID + "');");
                txtJumlahSahamAdd.Attributes.Add("onblur", " FormatNumber('" + txtJumlahSahamAdd.ClientID + "')");

                TextBox txtNamaPemegangSahamAdd = e.Item.FindControl("txtNamaPemegangSahamAdd") as TextBox;
                txtNamaPemegangSahamAdd.Attributes.Add("onkeyup", "PemegangSahamPerubahanPMAPMDN('" + txtNamaPemegangSahamAdd.ClientID + "');");
            }
            else if (e.Item.ItemType == ListItemType.EditItem)
            {
                TextBox txtJumlahSahamEdit = e.Item.FindControl("txtJumlahSahamEdit") as TextBox;
                TextBox txtJumlahNominalEdit = e.Item.FindControl("txtJumlahNominalEdit") as TextBox;
                TextBox txtPercentagesEdit = e.Item.FindControl("txtPercentagesEdit") as TextBox;

                txtJumlahSahamEdit.Attributes.Add("onkeyup", "FormatNumber('" + txtJumlahSahamEdit.ClientID + "'); Total('" + txtJumlahSahamEdit.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtJumlahNominalEdit.ClientID + "'); Percentages('" + txtJumlahSahamEdit.ClientID + "','" + txtModalSetor.ClientID + "','" + txtPercentagesEdit.ClientID + "');");
                txtJumlahSahamEdit.Attributes.Add("onblur", " FormatNumber('" + txtJumlahSahamEdit.ClientID + "')");

                TextBox txtNamaPemegangSahamEdit = e.Item.FindControl("txtNamaPemegangSahamEdit") as TextBox;
                txtNamaPemegangSahamEdit.Attributes.Add("onkeyup", "PemegangSahamPerubahanPMAPMDN('" + txtNamaPemegangSahamEdit.ClientID + "');");
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                PemegangSaham o = e.Item.DataItem as PemegangSaham;

                Label lblPartner = e.Item.FindControl("lblPartner") as Label;
                lblPartner.Text = o.Partner == true ? "Yes" : "No";
            }
        }

        protected void dgPemegangSaham_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (txtNominalModalSetor.Text.Trim() == string.Empty || txtNominalSaham.Text.Trim() == string.Empty)
            {
                Util.ShowMessage(Page, SR.FieldCanNotEmpty("Nominal Modal Setor and Nominal Saham"));
                return;
            }

            decimal NominalModalSetor = Convert.ToDecimal(txtNominalModalSetor.Text);
            decimal NominalSaham = Convert.ToDecimal(txtNominalSaham.Text);

            List<PemegangSaham> coll = new List<PemegangSaham>();
            if (ViewState["PemegangSaham"] != null)
                coll = ViewState["PemegangSaham"] as List<PemegangSaham>;

            if (e.CommandName == "add")
            {
                TextBox txtNamaPemegangSahamAdd = e.Item.FindControl("txtNamaPemegangSahamAdd") as TextBox;
                TextBox txtJumlahSahamAdd = e.Item.FindControl("txtJumlahSahamAdd") as TextBox;
                TextBox txtJumlahNominalAdd = e.Item.FindControl("txtJumlahNominalAdd") as TextBox;
                TextBox txtPercentagesAdd = e.Item.FindControl("txtPercentagesAdd") as TextBox;
                CheckBox cboPartnerAdd = e.Item.FindControl("cboPartnerAdd") as CheckBox;

                if (isExistInPemegangSahamGrid(txtNamaPemegangSahamAdd.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaPemegangSahamAdd.Text.Trim()));
                    return;
                }

                string msg = Util.IsPemegangSahamOK(dgPemegangSaham, Convert.ToDecimal(txtJumlahSahamAdd.Text), Convert.ToDecimal(txtJumlahNominalAdd.Text), NominalModalSetor, NominalSaham);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                PemegangSaham o = new PemegangSaham();
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

                if (isExistInPemegangSahamGrid(txtNamaPemegangSahamEdit.Text))
                {
                    Util.ShowMessage(Page, SR.DataIsExist(txtNamaPemegangSahamEdit.Text.Trim()));
                    return;
                }

                string msg = Util.IsPemegangSahamOK(dgPemegangSaham, Convert.ToDecimal(txtJumlahSahamEdit.Text), Convert.ToDecimal(txtJumlahNominalEdit.Text), NominalModalSetor, NominalSaham);
                if (msg != string.Empty)
                {
                    Util.ShowMessage(Page, msg);
                    return;
                }

                PemegangSaham o = new PemegangSaham();
                o.Nama = txtNamaPemegangSahamEdit.Text.Trim();
                o.JumlahNominal = Convert.ToDouble(txtJumlahNominalEdit.Text);
                o.JumlahSaham = Convert.ToDouble(txtJumlahSahamEdit.Text);
                o.Partner = cboPartnerEdit.Checked;
                o.Percentages = Convert.ToDouble(txtPercentagesEdit.Text);

                coll[e.Item.ItemIndex] = o;
                ViewState["PemegangSaham"] = coll;

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
                coll.RemoveAt(e.Item.ItemIndex);
                ViewState["PemegangSaham"] = coll;
            }
            BindPemegangSaham();
        }

        #endregion

        #region Search Pemohon

        protected void imgbtnNamaPemohon_Click(object sender, ImageClickEventArgs e)
        {
            Pemohon.SearchClientIDProp = "divPemohonSearch";
        }

        void btnSelectedDataPemohon_Click(object sender, EventArgs e)
        {
            SPListItem item = Pemohon.itemProp;
            if (item != null)
            {
                hfIDPemohon.Value = item.ID.ToString();
                txtNamaPemohon.Text = item.Title;
                txtEmailPemohon.Text = item["EmailPemohon"].ToString();

                BindPemegangSaham();

                upMain.Update();
            }
        }

        //void btnClosedData_Click(object sender, EventArgs e)
        //{
        //    BindPemegangSaham();

        //    upMain.Update();
        //}

        #endregion

        #region Search Perusahaan

        protected void imgbtnNamaPerusahaan_Click(object sender, ImageClickEventArgs e)
        {
            //txtSearch.Text = string.Empty;
            //grv.Visible = false;
            Perusahaan.SearchClientIDProp = "divPerusahaanSearch";
        }

        void btnSelectedDataPerusahaan_Click(object sender, EventArgs e)
        {
            SPListItem item = Perusahaan.itemProp;
            if (item != null)
            {
                txtKodePerusahaan.Text = item["CompanyCodeAPV"] == null ? string.Empty : item["CompanyCodeAPV"].ToString();
                txtNamaPerusahaan.Text = item["NamaPerusahaan"] == null ? string.Empty : item["NamaPerusahaan"].ToString();
                if (item["TempatKedudukan"] != null)
                    ddlTempatKedudukan.SelectedValue = item["TempatKedudukan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
                else
                    ddlTempatKedudukan.SelectedValue = string.Empty;
                txtAlamat.Text = item["AlamatSKDP"] == null ? string.Empty : item["AlamatSKDP"].ToString();

                if (item["Pemohon"] != null)
                {
                    int IDPemohon = Convert.ToInt32(item["Pemohon"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    hfIDPemohon.Value = IDPemohon.ToString();
                    SPList listPemohon = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Pemohon"));
                    SPListItem itemPemohon = listPemohon.GetItemById(IDPemohon);
                    txtNamaPemohon.Text = itemPemohon.Title;
                    txtEmailPemohon.Text = itemPemohon["EmailPemohon"].ToString();
                }
                else
                {
                    txtNamaPemohon.Text = string.Empty;
                    txtEmailPemohon.Text = string.Empty;
                }
            }

            BindPemegangSaham();

            upMain.Update();
            upDataPerusahaan.Update();
        }

        //void btnClosedSearch_Click(object sender, EventArgs e)
        //{
        //    BindPemegangSaham();

        //    upMain.Update();
        //    upDataPerusahaan.Update();
        //}

        #endregion

        #endregion
    }
}
