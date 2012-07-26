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
        private int IDP = 0;
        private string Source = string.Empty;
        private string Mode = string.Empty;

        #endregion

        #region Methods

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

        private void BindTempatKedudukan()
        {
            DataTable dt = Util.GetTempatKedudukan(web);
            ddlTempatKedudukan.DataSource = dt;
            ddlTempatKedudukan.DataTextField = "Title";
            ddlTempatKedudukan.DataValueField = "ID";
            ddlTempatKedudukan.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlTempatKedudukan.Items.Insert(0, item);
        }

        private string Validation()
        {
            StringBuilder sb = new StringBuilder();
            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty)
            {
                if (txtKodePerusahaan.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Kode Perusahaan") + " \\n");
                if (txtNamaPerusahaan.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Nama Perusahaan") + " \\n");
                if (ddlTempatKedudukan.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Tempat Kedudukan") + " \\n");
                if (txtKlasifikasiLapanganUsaha.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Klasifikasi Lapangan Usaha") + " \\n");
                if (ddlStatusPerseroan.SelectedValue == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("Status Perseroan") + " \\n");
            }

            if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC)
            {
                if (IDP == 0)
                {
                    if (!fu.HasFile)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Izin Usaha") + " \\n");
                }
                if (txtNo.Text.Trim() == string.Empty)
                    sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
                if (dtTanggalMulaiBerlaku.ErrorMessage != null)
                    sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku") + " \\n");
            }

            return sb.ToString();
        }

        private string SaveUpdate()
        {
            SPWeb currentWeb = SPContext.Current.Web;
            SPList list = currentWeb.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha"));//web.Lists[ListId];
            currentWeb.AllowUnsafeUpdates = true;
            SPListItem item;

            try
            {
                if (IDP == 0)
                {
                    item = list.Items.Add();
                    item["Title"] = Util.GenerateRequestCode(web, RequestCode.IZIN_USAHA, DateTime.Now.Month, DateTime.Now.Year);
                    item["Created By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }
                else
                {
                    item = list.GetItemById(IDP);
                    item["Modified By"] = SPContext.Current.Web.CurrentUser.ID.ToString();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == string.Empty)
                {
                    item["Tanggal"] = Convert.ToDateTime(ltrDate.Text);
                    item["KodePerusahaan"] = txtKodePerusahaan.Text.Trim();
                    item["NamaPerusahaan"] = txtNamaPerusahaan.Text.Trim();
                    item["TempatKedudukan"] = ddlTempatKedudukan.SelectedValue;
                    item["KlasifikasiLapanganUsaha"] = txtKlasifikasiLapanganUsaha.Text.Trim();
                    item["StatusPerseroan"] = ddlStatusPerseroan.SelectedValue;
                    item["Keterangan"] = txtKeterangan.Text.Trim();
                }

                if (Convert.ToBoolean(ViewState["Admin"]) == true || ViewState["Status"].ToString() == Roles.PIC_CORSEC)
                {
                    item["No"] = txtNo.Text.Trim();
                    item["TanggalBerlaku"] = dtTanggalMulaiBerlaku.SelectedDate;
                    item["KeteranganIzinUsaha"] = txtKeteranganIzinUsaha.Text.Trim();
                }
                item.Update();

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
                            web.AllowUnsafeUpdates = true;
                            SPFile file = document.Files.Add(fileName, bytes);
                            SPItem itemDocument = file.Item;
                            itemDocument["Title"] = Path.GetFileNameWithoutExtension(fileName);
                            itemDocument["IzinUsaha"] = item.ID;
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
                }

                currentWeb.AllowUnsafeUpdates = false;
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

        private void Display(string mode)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha")); //web.Lists[ListId];
            SPListItem item = list.GetItemById(IDP);

            if (item["Status"] != null)
                ViewState["Status"] = item["Status"].ToString();

            ltrRequestCode.Text = item["Title"].ToString();
            ltrDate.Text = Convert.ToDateTime(item["Tanggal"].ToString()).ToString("dd-MMM-yyyy HH:mm");
            txtKodePerusahaan.Text = item["KodePerusahaan"].ToString();
            txtNamaPerusahaan.Text = item["NamaPerusahaan"].ToString();
            if (item["TempatKedudukan"] != null)
                ddlTempatKedudukan.SelectedValue = item["TempatKedudukan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            txtKlasifikasiLapanganUsaha.Text = item["KlasifikasiLapanganUsaha"].ToString();
            if (item["StatusPerseroan"] != null)
                ddlStatusPerseroan.SelectedValue = item["StatusPerseroan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
            txtKeterangan.Text = item["Keterangan"] == null ? string.Empty : item["Keterangan"].ToString();
            txtNo.Text = item["No"] == null ? string.Empty : item["No"].ToString();
            if (item["TanggalBerlaku"] != null)
                dtTanggalMulaiBerlaku.SelectedDate = Convert.ToDateTime(item["TanggalBerlaku"]);
            txtKeteranganIzinUsaha.Text = item["KeteranganIzinUsaha"] == null ? string.Empty : item["KeteranganIzinUsaha"].ToString();

            ltrKodePerusahaan.Text = txtKodePerusahaan.Text;
            ltrNamaPerusahaan.Text = txtNamaPerusahaan.Text;
            if (item["TempatKedudukan"] != null)
                ltrTempatKedudukan.Text = ddlTempatKedudukan.SelectedItem.Text;
            ltrKlasifikasi.Text = item["KlasifikasiLapanganUsaha"].ToString();
            if (item["StatusPerseroan"] != null)
                ltrStatusPerseroan.Text = ddlStatusPerseroan.SelectedItem.Text;
            ltrKeterangan.Text = txtKeterangan.Text;
            ltrNo.Text = txtNo.Text;
            if (item["TanggalBerlaku"] != null)
                ltrTanggalMulaiBerlaku.Text = Convert.ToDateTime(item["TanggalBerlaku"]).ToString("dd-MMM-yyyy");
            ltrKeteranganIzinUsaha.Text = txtKeteranganIzinUsaha.Text;

            if (mode == "edit")
                btnSaveUpdate.Text = "Update";
            else if (mode == "display")
                btnSaveUpdate.Visible = false;

            SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "IzinUsahaDokumen"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='IzinUsaha' LookupId='True' />" +
                                 "<Value Type='Lookup'>" + IDP + "</Value>" +
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

                    ltrCS.Text = item["Created By"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                    ltrChiefCorsec.Text = item["ChiefCorsec"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                }
            }

            HiddenControls(mode, item["Status"] == null ? string.Empty : item["Status"].ToString());
        }

        private void HiddenControls(string mode, string status)
        {
            if (mode == "display")
            {
                txtKeterangan.Visible = false;
                txtKeteranganIzinUsaha.Visible = false;
                txtKlasifikasiLapanganUsaha.Visible = false;
                txtKodePerusahaan.Visible = false;
                txtNamaPerusahaan.Visible = false;
                txtNo.Visible = false;
                ddlTempatKedudukan.Visible = false;
                dtTanggalMulaiBerlaku.Visible = false;
                ddlStatusPerseroan.Visible = false;
                fu.Visible = false;
                imgbtnNamaPerusahaan.Visible = false;

                reqddlStatusPerseroan.Visible = false;
                reqfu.Visible = false;
                reqtxtKlasifikasiLapanganUsaha.Visible = false;
                reqtxtKodePerusahaan.Visible = false;
                reqtxtNamaPerusahaan.Visible = false;
                reqtxtNo.Visible = false;
                reqddlTempatKedudukan.Visible = false;
                reqdtTanggalMulaiBerlaku.Visible = false;
            }
            else if (mode == "edit")
            {
                if (status == Roles.PIC_CORSEC)
                {
                    txtKeterangan.Visible = false;
                    txtKlasifikasiLapanganUsaha.Visible = false;
                    txtKodePerusahaan.Visible = false;
                    txtNamaPerusahaan.Visible = false;
                    ddlTempatKedudukan.Visible = false;
                    ddlStatusPerseroan.Visible = false;
                    imgbtnNamaPerusahaan.Visible = false;

                    reqddlStatusPerseroan.Visible = false;
                    reqtxtKlasifikasiLapanganUsaha.Visible = false;
                    reqtxtKodePerusahaan.Visible = false;
                    reqtxtNamaPerusahaan.Visible = false;
                    reqddlTempatKedudukan.Visible = false;
                }
                else
                {
                    ltrKodePerusahaan.Visible = false;
                    ltrKeterangan.Visible = false;
                    ltrKlasifikasi.Visible = false;
                    ltrNamaPerusahaan.Visible = false;
                    ltrStatusPerseroan.Visible = false;
                    ltrTempatKedudukan.Visible = false;
                }

                ltrKeteranganIzinUsaha.Visible = false;
                ltrNo.Visible = false;
                ltrTanggalMulaiBerlaku.Visible = false;

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
            Util.RegisterStartupScript(Page, "Perusahaan", "RegisterDialog('divPerusahaanSearch','divPerusahaanDlgContainer', '630');");

            using (SPSite site = new SPSite(SPContext.Current.Site.Url, SPContext.Current.Site.SystemAccount.UserToken))
            {
                using (web = site.OpenWeb())
                {
                    bool isID = int.TryParse(Request.QueryString["ID"], out IDP);
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

                        ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");
                        BindStatusPerseroan();
                        BindTempatKedudukan();

                        if (isID)
                            Display(Mode);
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
                    Response.Redirect("/Lists/IzinUsaha", true);
            }
            else
                Util.ShowMessage(Page, result);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect("/Lists/IzinUsaha", true);
        }

        #region Search Perusahaan

        private void DisplayPerusahaan(int IDPerusahaan)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
            SPListItem item = list.GetItemById(IDPerusahaan);
            if (item != null)
            {
                txtKodePerusahaan.Text = item["CompanyCodeAPV"].ToString();
                txtNamaPerusahaan.Text = item["NamaPerusahaan"].ToString();
                if (item["TempatKedudukan"] != null)
                    ddlTempatKedudukan.SelectedValue = item["TempatKedudukan"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0];
                else
                    ddlTempatKedudukan.SelectedValue = string.Empty;
            }

            upDataPerusahaan.Update();
        }

        private void BindPerusahaan()
        {
            string query = string.Empty;
            if (txtSearch.Text.Trim() == string.Empty)
            {
                query = "<Where>" +
                            "<And>" +
                              "<And>" +
                                 "<IsNotNull>" +
                                    "<FieldRef Name='NamaPerusahaan' />" +
                                 "</IsNotNull>" +
                                 "<IsNotNull>" +
                                    "<FieldRef Name='CompanyCodeAPV' />" +
                                 "</IsNotNull>" +
                              "</And>" +
                              "<Eq>" +
                                 "<FieldRef Name='ApprovalStatus' />" +
                                 "<Value Type='Text'>Approved</Value>" +
                              "</Eq>" +
                            "</And>" +
                        "</Where>";
            }
            else
            {
                query = "<Where>" +
                            "<And>" +
                              "<And>" +
                                 "<Contains>" +
                                    "<FieldRef Name='NamaPerusahaan' />" +
                                    "<Value Type='Text'>" + txtSearch.Text.Trim() + "</Value>" +
                                 "</Contains>" +
                                 "<IsNotNull>" +
                                    "<FieldRef Name='CompanyCodeAPV' />" +
                                 "</IsNotNull>" +
                              "</And>" +
                              "<Eq>" +
                                 "<FieldRef Name='ApprovalStatus' />" +
                                 "<Value Type='Text'>Approved</Value>" +
                              "</Eq>" +
                           "</And>" +
                        "</Where>";
            }

            grv.Visible = true;
            ods.SelectParameters["ListURL"].DefaultValue = Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru");
            ods.SelectParameters["strQuery"].DefaultValue = query;
            ods.Page.DataBind();
        }

        protected void imgbtnNamaPerusahaan_Click(object sender, ImageClickEventArgs e)
        {
            txtSearch.Text = string.Empty;
            grv.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindPerusahaan();
        }

        protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.DataItemIndex < 0)
                return;

            DataRowView dr = e.Row.DataItem as DataRowView;

            Literal ltrrb = e.Row.FindControl("ltrrb") as Literal;
            ltrrb.Text = string.Format("<input type='radio' name='rbPerusahaan' id='Row{0}' value='{0}' />", dr["ID"].ToString());
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (Request.Form["rbPerusahaan"] != null)
            {
                string IDPerusahaan = Request.Form["rbPerusahaan"].ToString();
                DisplayPerusahaan(Convert.ToInt32(IDPerusahaan));
                Util.RegisterStartupScript(Page, "closePerusahaan", "closeDialog('divPerusahaanSearch');");
            }
            else
                Util.ShowMessage(Page, "Please choose Perusahaan");
        }

        #endregion

        #endregion
    }
}
