using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using SPVisionet.CorporateSecretary.Common;

namespace SPVisionet.CorporateSecretary.WebParts.PermohonanPembuatanIzinUsaha
{
    public partial class PermohonanPembuatanIzinUsahaUserControl : UserControl
    {
        #region Properties

        private SPWeb web;
        private int ID = 0;
        private Guid ListId = Guid.Empty;

        #endregion

        #region Methods

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (txtKodePerusahaan.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Kode Perusahaan") + " \\n");
            if (txtNamaPerusahaan.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Nama Perusahaan") + " \\n");
            if (txtTempatKedudukan.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Tempat Kedudukan") + " \\n");
            if (txtKlasifikasi.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Klasifikasi Lapangan Usaha") + " \\n");
            if (ddlStatusPerseroan.SelectedValue == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Status Perseroan") + " \\n");
            if (!fu.HasFile)
                sb.Append(SR.FieldCanNotEmpty("File Upload Izin Usaha") + " \\n");
            if (txtNo.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
            else
            {
                try
                {
                    Convert.ToInt32(txtNo.Text.Trim());
                }
                catch
                {
                    sb.Append(SR.IntegerData("No") + " \\n");
                }
            }
            if (!dtTanggalMulaiBerlaku.IsValid)
                sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku") + " \\n");

            return sb.ToString();
        }

        private bool SaveUpdate()
        {
            SPList list = web.Lists[ListId]; //web.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha"));
            web.AllowUnsafeUpdates = true;
            SPListItem item;

            try
            {
                if (ID == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, RequestCode.IZIN_USAHA, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(ID);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                item["Tanggal"] = Convert.ToDateTime(ltrDate.Text);
                item["KodePerusahaan"] = txtKodePerusahaan.Text.Trim();
                item["NamaPerusahaan"] = txtNamaPerusahaan.Text.Trim();
                item["TempatKedudukan"] = txtTempatKedudukan.Text.Trim();
                item["KlasifikasiLapanganUsaha"] = txtKlasifikasi.Text.Trim();
                item["StatusPerseroan"] = ddlStatusPerseroan.SelectedValue;
                item["Keterangan"] = txtKeterangan.Text.Trim();
                item["No"] = txtNo.Text.Trim();
                item["TanggalBerlaku"] = dtTanggalMulaiBerlaku.SelectedDate;
                item["KeteranganIzinUsaha"] = txtKeteranganIzinUsaha.Text.Trim();
                if (fu.HasFile)
                {
                    string fileName = fu.FileName.Replace("&", string.Empty);
                    item.Attachments.Add(fileName, fu.FileBytes);
                }
                item.Update();

                web.AllowUnsafeUpdates = false;
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void Display(string mode)
        {
            SPList list = web.Lists[ListId]; //web.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha"));
            SPListItem item = list.GetItemById(ID);

            HiddenControls(mode);

            if (mode == "edit")
            {
                btnSaveUpdate.Text = "Update";

                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                txtKodePerusahaan.Text = item["KodePerusahaan"].ToString();
                txtNamaPerusahaan.Text = item["NamaPerusahaan"].ToString();
                txtTempatKedudukan.Text = item["TempatKedudukan"].ToString();
                txtKlasifikasi.Text = item["KlasifikasiLapanganUsaha"].ToString();
                ddlStatusPerseroan.SelectedValue = item["StatusPerseroan"].ToString();
                txtKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
                txtNo.Text = item["No"].ToString();
                dtTanggalMulaiBerlaku.SelectedDate = Convert.ToDateTime(item["TanggalBerlaku"]);
                txtKeteranganIzinUsaha.Text = item["KeteranganIzinUsaha"] == null ? string.Empty : item["KeteranganIzinUsaha"].ToString();
            }
            else if (mode == "display")
            {
                btnSaveUpdate.Visible = false;

                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                ltrKodePerusahaan.Text = item["KodePerusahaan"].ToString();
                ltrNamaPerusahaan.Text = item["NamaPerusahaan"].ToString();
                ltrTempatKedudukan.Text = item["TempatKedudukan"].ToString();
                ltrKlasifikasi.Text = item["KlasifikasiLapanganUsaha"].ToString();
                ltrStatusPerseroan.Text = item["StatusPerseroan"].ToString();
                ltrKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
                ltrNo.Text = item["No"].ToString();
                ltrTanggalMulaiBerlaku.Text = Convert.ToDateTime(item["TanggalBerlaku"]).ToString("dd-MMM-yyyy");
                ltrKeteranganIzinUsaha.Text = item["KeteranganIzinUsaha"] == null ? string.Empty : item["KeteranganIzinUsaha"].ToString();
            }

            if (item.Attachments.Count > 0)
            {
                pnlfuFile.Visible = true;
                pnlfu.Visible = false;
                reqfu.Visible = false;
                foreach (string filename in item.Attachments)
                {
                    ltrfu.Text = string.Format("<a href='/Lists/IzinUsaha/Attachments/{0}/{1}'>{1}</a>", ID.ToString(), filename, filename);
                }
            }
            else
            {
                pnlfuFile.Visible = false;
                pnlfu.Visible = true;
                reqfu.Visible = true;
            }
        }

        private void HiddenControls(string mode)
        {
            if (mode == "display")
            {
                txtKeterangan.Visible = false;
                txtKeteranganIzinUsaha.Visible = false;
                txtKlasifikasi.Visible = false;
                txtKodePerusahaan.Visible = false;
                txtNamaPerusahaan.Visible = false;
                txtNo.Visible = false;
                txtTempatKedudukan.Visible = false;
                dtTanggalMulaiBerlaku.Visible = false;
                ddlStatusPerseroan.Visible = false;
                fu.Visible = false;
                lbDelete.Visible = false;

                reqddlStatusPerseroan.Visible = false;
                reqfu.Visible = false;
                reqtxtKlasifikasi.Visible = false;
                reqtxtKodePerusahaan.Visible = false;
                reqtxtNamaPerusahaan.Visible = false;
                reqtxtNo.Visible = false;
                reqtxtTempatKedudukan.Visible = false;

                pnlfu.Visible = false;
            }
            else if (mode == "edit")
            {
                ltrKeterangan.Visible = false;
                ltrKeteranganIzinUsaha.Visible = false;
                ltrKlasifikasi.Visible = false;
                ltrNamaPerusahaan.Visible = false;
                ltrNo.Visible = false;
                ltrStatusPerseroan.Visible = false;
                ltrTanggalMulaiBerlaku.Visible = false;
                ltrTempatKedudukan.Visible = false;
            }
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url, SPContext.Current.Site.SystemAccount.UserToken))
            {
                using (web = site.OpenWeb())
                {
                    bool isID = int.TryParse(Request.QueryString["ID"], out ID);
                    string mode = Request.QueryString["mode"] == null ? string.Empty : Request.QueryString["mode"].ToString();

                    if (Request.QueryString["List"] != null)
                        ListId = new Guid(HttpUtility.UrlDecode(Request.QueryString["List"]));

                    if (!IsPostBack)
                    {
                        ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");

                        if (isID)
                            Display(mode);
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
            bool result = SaveUpdate();
            if (result)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
            {
                if (ID == 0)
                    Util.ShowMessage(Page, SR.SaveFail);
                else
                    Util.ShowMessage(Page, SR.UpdateFail);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
        }

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            SPListItem item = web.Lists[ListId].GetItemById(ID); //web.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha")).GetItemById(ID);
            web.AllowUnsafeUpdates = true;
            int count = item.Attachments.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                item.Attachments.Delete(item.Attachments[i]);
            }
            item.Update();
            pnlfuFile.Visible = false;
            pnlfu.Visible = true;
            reqfu.Visible = true;
        }

        #endregion
    }
}
