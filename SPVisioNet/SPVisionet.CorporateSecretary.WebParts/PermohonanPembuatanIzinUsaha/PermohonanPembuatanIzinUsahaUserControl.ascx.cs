using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Web;
using System.Data;
using System.IO;

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

        private void BindKlasifikasiLapanganUsaha()
        {
            DataTable dt = Util.GetKlasifikasiLapanganUsaha(web);
            ddlKlasifikasiLapanganUsaha.DataSource = dt;
            ddlKlasifikasiLapanganUsaha.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlKlasifikasiLapanganUsaha.Items.Insert(0, item);
        }

        private void BindStatusPerseroan()
        {
            DataTable dt = Util.GetStatusPerseroan(web);
            ddlStatusPerseroan.DataSource = dt;
            ddlStatusPerseroan.DataTextField = "Title";
            ddlStatusPerseroan.DataValueField = "ID";
            ddlStatusPerseroan.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlStatusPerseroan.Items.Insert(0, item);
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (txtKodePerusahaan.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Kode Perusahaan") + " \\n");
            if (txtNamaPerusahaan.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Nama Perusahaan") + " \\n");
            if (txtTempatKedudukan.Text.Trim() == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Tempat Kedudukan") + " \\n");
            if (ddlKlasifikasiLapanganUsaha.SelectedValue == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Klasifikasi Lapangan Usaha") + " \\n");
            if (ddlStatusPerseroan.SelectedValue == string.Empty)
                sb.Append(SR.FieldCanNotEmpty("Status Perseroan") + " \\n");
            if (ID == 0)
            {
                if (!fu.HasFile)
                    sb.Append(SR.FieldCanNotEmpty("File Upload Izin Usaha") + " \\n");
            }
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

        private string SaveUpdate()
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
                item["KlasifikasiLapanganUsaha"] = ddlKlasifikasiLapanganUsaha.SelectedValue;
                item["StatusPerseroan"] = ddlStatusPerseroan.SelectedValue;
                item["Keterangan"] = txtKeterangan.Text.Trim();
                item["No"] = txtNo.Text.Trim();
                item["TanggalBerlaku"] = dtTanggalMulaiBerlaku.SelectedDate;
                item["KeteranganIzinUsaha"] = txtKeteranganIzinUsaha.Text.Trim();
                item.Update();

                ViewState["ID"] = item.ID;

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

                            SPFolder document = web.Folders["IzinUsahaDokumen"];
                            SPFile file = document.Files.Add(fileName, bytes);
                            SPItem itemDocument = file.Item;
                            itemDocument["Title"] = Path.GetFileNameWithoutExtension(fileName);
                            itemDocument["IzinUsaha"] = Convert.ToInt32(ViewState["ID"]);
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

        private void Display(string mode)
        {
            SPList list = web.Lists[ListId]; //web.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha"));
            SPListItem item = list.GetItemById(ID);

            if (mode == "edit")
            {
                btnSaveUpdate.Text = "Update";

                ltrRequestCode.Text = item["Title"].ToString();
                ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
                txtKodePerusahaan.Text = item["KodePerusahaan"].ToString();
                txtNamaPerusahaan.Text = item["NamaPerusahaan"].ToString();
                txtTempatKedudukan.Text = item["TempatKedudukan"].ToString();
                ddlKlasifikasiLapanganUsaha.SelectedValue = item["KlasifikasiLapanganUsaha"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
                ddlStatusPerseroan.SelectedValue = item["StatusPerseroan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
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
                ltrKlasifikasi.Text = item["KlasifikasiLapanganUsaha"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                ltrStatusPerseroan.Text = item["StatusPerseroan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                ltrKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
                ltrNo.Text = item["No"].ToString();
                ltrTanggalMulaiBerlaku.Text = Convert.ToDateTime(item["TanggalBerlaku"]).ToString("dd-MMM-yyyy");
                ltrKeteranganIzinUsaha.Text = item["KeteranganIzinUsaha"] == null ? string.Empty : item["KeteranganIzinUsaha"].ToString();
            }

            SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "IzinUsahaDokumen"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='IzinUsaha' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + ID + "</Value>" +
                              "</Eq>" +
                          "</Where>" +
                          "<OrderBy>" +
                            "<FieldRef Name='Created' Ascending='False' />" +
                          "</OrderBy>";
            SPListItemCollection coll = document.GetItems(query);
            if (coll.Count > 0)
            {
                SPListItem documentItem = coll[0];
                ltrfu.Text = string.Format("<a href='/IzinUsahaDokumen/{0}'>{0}</a>", documentItem["Name"].ToString());
            }

            HiddenControls(mode);
        }

        private void HiddenControls(string mode)
        {
            if (mode == "display")
            {
                txtKeterangan.Visible = false;
                txtKeteranganIzinUsaha.Visible = false;
                ddlKlasifikasiLapanganUsaha.Visible = false;
                txtKodePerusahaan.Visible = false;
                txtNamaPerusahaan.Visible = false;
                txtNo.Visible = false;
                txtTempatKedudukan.Visible = false;
                dtTanggalMulaiBerlaku.Visible = false;
                ddlStatusPerseroan.Visible = false;
                fu.Visible = false;

                reqddlStatusPerseroan.Visible = false;
                reqfu.Visible = false;
                reqddlKlasifikasiLapanganUsaha.Visible = false;
                reqtxtKodePerusahaan.Visible = false;
                reqtxtNamaPerusahaan.Visible = false;
                reqtxtNo.Visible = false;
                reqtxtTempatKedudukan.Visible = false;
                reqdtTanggalMulaiBerlaku.Visible = false;
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

                if (ltrfu.Text.Trim() == string.Empty)
                    reqfu.Visible = true;
                else
                    reqfu.Visible = false;
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

                    if (!IsPostBack)
                    {
                        txtNo.Attributes.Add("onkeyup", "NumericOnly('" + txtNo.ClientID + "');");

                        ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");
                        BindKlasifikasiLapanganUsaha();
                        BindStatusPerseroan();

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
