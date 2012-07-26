using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Utilities;
using SPVisionet.CorporateSecretary.Common;
using System.Text;

namespace SPVisionet.CorporateSecretary.Workflow.Layouts.SPVisionet.CorporateSecretary.Workflow.ToDoTaskCT
{
    public partial class ToDoTaskCT : LayoutsPageBase
    {
        #region Fields

        private Guid taskListId = Guid.Empty;
        private int taskItemId = 0;
        private string source = string.Empty;

        private const string PIC_CORSEC_UPLOAD_AKTA = Common.Roles.PIC_CORSEC + " Upload Akta";
        private const string PIC_CORSEC_UPLOAD_SKDP = Common.Roles.PIC_CORSEC + " Upload SKDP";
        private const string ACCOUNTING_HEAD_INPUT_COMPANY_CODE = Common.Roles.ACCOUNTING_HEAD + " Input Company Code";
        private const string ACCOUNTING_UPLOAD_APV = Common.Roles.ACCOUNTING + " Upload APV";
        private const string FINANCE_UPLOAD_SETORAN_MODAL = Common.Roles.FINANCE + " Upload Setoran Modal";
        private const string PIC_CORSEC_UPLOAD_SK_PENGESAHAN = Common.Roles.PIC_CORSEC + " Upload SK Pengesahan";
        private const string TAX_UPLOAD_NPWP = Common.Roles.TAX + " Upload NPWP";
        private const string TAX_UPLOAD_PKP = Common.Roles.TAX + " Upload PKP";

        private const string PIC_CORSEC = Common.Roles.PIC_CORSEC;

        private const string CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN = Common.Roles.CUSTODIAN + " Update Tanggal Estimasi Pengembalian";

        #endregion

        #region Event Handlers

        /// <summary>
        /// Raises the init event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Request.QueryString["List"] != null)
                taskListId = new Guid(HttpUtility.UrlDecode(Request.QueryString["List"]));

            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    taskItemId = Convert.ToInt32(Request.QueryString["ID"]);
                }
                catch (Exception)
                {
                    taskItemId = 0;
                }
            }

            if (Request.QueryString["Source"] != null)
            {
                source = HttpUtility.UrlDecode(Request.QueryString["Source"]);
            }
        }

        /// <summary>
        /// Raises the load event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
                LoadFormData();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            SPWeb web = SPControl.GetContextWeb(this.Context);
            using (SPSite site = new SPSite(web.Url, web.Site.SystemAccount.UserToken))
            {
                using (SPWeb webSA = site.OpenWeb())
                {
                    webSA.AllowUnsafeUpdates = true;
                    SPList taskList = webSA.Lists[taskListId];
                    SPListItem taskItem = taskList.GetItemById(taskItemId);

                    if (taskItem["WorkflowLink"].ToString().Contains("Lists/SIUP"))
                    {
                        string msg = ValidationSIUP(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/TDP"))
                    {
                        string msg = ValidationTDP(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/IzinUsaha"))
                    {
                        string msg = ValidationIzinUsaha(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PendaftaranPMAPMDN"))
                    {
                        string msg = ValidationPendaftaranPMAPMDN(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PerubahanPTBiasaMenjadiPMAPMDN"))
                    {
                        string msg = ValidationPerubahanPTBiasaMenjadiPMAPMDN(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PermintaanDokumen"))
                    {
                        string msg = ValidationPermintaanDokumen(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PerusahaanBaru"))
                    {
                        string msg = ValidationPendirianPerusahaanBaruIndonesia(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PendirianPerusahaanBaruForeign"))
                    {
                        string msg = ValidationPendirianPerusahaanBaruForeign(taskItem["WorkflowLink"].ToString());
                        if (msg != string.Empty)
                        {
                            Util.ShowMessage(Page, msg);
                            return;
                        }
                    }

                    Hashtable taskData = new Hashtable();
                    taskData.Add("PercentComplete", 1);
                    taskData.Add("Completed", true);
                    taskData.Add("Status", "Completed");
                    SPWorkflowTask.AlterTask(taskItem, taskData, true);

                    if (taskItem["ParentID"] != null)
                    {
                        SPListItem taskItemParent = taskList.GetItemById(Convert.ToInt32(taskItem["ParentID"].ToString()));
                        SPWorkflowTask.AlterTask(taskItemParent, taskData, true);
                    }
                    webSA.AllowUnsafeUpdates = false;
                }
            }
            if (source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect(web.Url, true);
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SPWeb web = SPControl.GetContextWeb(this.Context);
            if (source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect(web.Url, true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the form data.
        /// </summary>
        private void LoadFormData()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPWeb web = SPControl.GetContextWeb(this.Context);
                    SPList taskList = web.Lists[taskListId];
                    SPListItem taskItem = taskList.GetItemById(taskItemId);

                    ltlTitle.Text = Convert.ToString(taskItem["Title"]);

                    string[] relatedItemLink = Convert.ToString(taskItem["WorkflowLink"]).Split(',');
                    linkRelatedItem.Target = "_blank";
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
                    linkRelatedItem.Text = relatedItemLink[1].Trim();
                });
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        #region SIUP

        private string ValidationSIUP(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "SIUP"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                if (item["Status"].ToString().ToLower() == Common.Roles.PIC_CORSEC.ToLower())
                {
                    SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "SIUPDokumen"));
                    SPQuery query = new SPQuery();
                    query.Query = "<Where>" +
                                      "<Eq>" +
                                         "<FieldRef Name='SIUP' LookupId='True' />" +
                                         "<Value Type='Lookup'>" + ID + "</Value>" +
                                      "</Eq>" +
                                  "</Where>" +
                                  "<OrderBy>" +
                                    "<FieldRef Name='Created' Ascending='False' />" +
                                  "</OrderBy>";
                    SPListItemCollection coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload SIUP") + " \\n");

                    if (item["No"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
                    if (item["TanggalMulaiBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku") + " \\n");
                    if (item["TanggalAkhirBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Berlaku") + " \\n");
                }
            });
            return sb.ToString();
        }

        #endregion

        #region TDP

        private string ValidationTDP(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "TDP"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                if (item["Status"].ToString().ToLower() == Common.Roles.PIC_CORSEC.ToLower())
                {
                    SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "TDPDokumen"));
                    SPQuery query = new SPQuery();
                    query.Query = "<Where>" +
                                      "<Eq>" +
                                         "<FieldRef Name='TDP' LookupId='True' />" +
                                         "<Value Type='Lookup'>" + ID + "</Value>" +
                                      "</Eq>" +
                                  "</Where>" +
                                  "<OrderBy>" +
                                    "<FieldRef Name='Created' Ascending='False' />" +
                                  "</OrderBy>";
                    SPListItemCollection coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload TDP") + " \\n");

                    if (item["No"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
                    if (item["TanggalMulaiBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku") + " \\n");
                    if (item["TanggalAkhirBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Berlaku") + " \\n");
                }
            });
            return sb.ToString();
        }

        #endregion

        #region Izin Usaha

        private string ValidationIzinUsaha(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                if (item["Status"].ToString().ToLower() == Common.Roles.PIC_CORSEC.ToLower())
                {
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
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Izin Usaha") + " \\n");

                    if (item["No"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
                    if (item["TanggalBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Berlaku") + " \\n");
                }
            });
            return sb.ToString();
        }

        #endregion

        #region Pendaftaran PMA/PMDN

        private string ValidationPendaftaranPMAPMDN(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendaftaranPMAPMDN"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                if (item["Status"].ToString().ToLower() == Common.Roles.PIC_CORSEC.ToLower())
                {
                    SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PendaftaranPMAPMDNDokumen"));
                    SPQuery query = new SPQuery();
                    query.Query = "<Where>" +
                                      "<Eq>" +
                                         "<FieldRef Name='PendaftaranPMAPMDN' LookupId='True' />" +
                                         "<Value Type='Lookup'>" + ID + "</Value>" +
                                      "</Eq>" +
                                  "</Where>" +
                                  "<OrderBy>" +
                                    "<FieldRef Name='Created' Ascending='False' />" +
                                  "</OrderBy>";
                    SPListItemCollection coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Surat Persetujuan PMA / PMDN Baru") + " \\n");

                    if (item["No"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
                    if (item["TanggalMulaiBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku") + " \\n");
                    if (item["TanggalAkhirBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Berlaku") + " \\n");
                }
            });
            return sb.ToString();
        }

        #endregion

        #region Perubahan PT Biasa Menjadi PMA/PMDN

        private string ValidationPerubahanPTBiasaMenjadiPMAPMDN(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDN"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                if (item["Status"].ToString().ToLower() == Common.Roles.PIC_CORSEC.ToLower())
                {
                    SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDNDokumen"));
                    SPQuery query = new SPQuery();
                    query.Query = "<Where>" +
                                      "<Eq>" +
                                         "<FieldRef Name='PerubahanPTBiasaMenjadiPMAPMDN' LookupId='True' />" +
                                         "<Value Type='Lookup'>" + ID + "</Value>" +
                                      "</Eq>" +
                                  "</Where>" +
                                  "<OrderBy>" +
                                    "<FieldRef Name='Created' Ascending='False' />" +
                                  "</OrderBy>";
                    SPListItemCollection coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Surat Persetujuan PMA / PMDN Baru") + " \\n");

                    if (item["No"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No") + " \\n");
                    if (item["TanggalMulaiBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku") + " \\n");
                    if (item["TanggalAkhirBerlaku"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Berlaku") + " \\n");
                }
            });
            return sb.ToString();
        }

        #endregion

        #region Permintaan Dokumen

        private string ValidationPermintaanDokumen(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumen"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                if (item["Status"] != null)
                {
                    if (item["Status"].ToString() == CUSTODIAN_UPDATE_TANGGAL_ESTIMASI_PENGEMBALIAN)
                    {
                        SPList listDocument = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumenDokumen"));
                        SPQuery query = new SPQuery();
                        query.Query = "<Where>" +
                                          "<Eq>" +
                                             "<FieldRef Name='PermintaanDokumen' LookupId='True' />" +
                                             "<Value Type='Lookup'>" + ID + "</Value>" +
                                          "</Eq>" +
                                      "</Where>";

                        SPListItemCollection coll = listDocument.GetItems(query);
                        foreach (SPListItem i in coll)
                        {
                            if (i["SoftcopyOriginal"].ToString().ToLower() == "original")
                            {
                                if (i["TanggalEstimasiPengembalian"] == null)
                                    sb.Append(SR.FieldCanNotEmpty("Tanggal Estimasi Pengembalian for " + i["Title"].ToString()));
                            }
                        }
                    }
                }
            });
            return sb.ToString();
        }

        #endregion

        #region Pendirian Perusahaan Baru Indonesia

        private string ValidationPendirianPerusahaanBaruIndonesia(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            string qry = "<Where>" +
                             "<And>" +
                                "<Eq>" +
                                    "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                    "<Value Type='Lookup'>" + ID + "</Value>" +
                                "</Eq>" +
                                "<Eq>" +
                                    "<FieldRef Name='DocumentType' />" +
                                    "<Value Type='Text'>{0}</Value>" +
                                "</Eq>" +
                            "</And>" +
                         "</Where>" +
                         "<OrderBy>" +
                             "<FieldRef Name='Created' Ascending='False' />" +
                         "</OrderBy>";

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
                if (item["Status"].ToString() == PIC_CORSEC_UPLOAD_AKTA)
                {
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(qry, "Akta");
                    query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                    SPListItemCollection coll = null;
                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Akta") + " \\n");

                    if (item["NoAkte"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No Akta") + " \\n");
                    if (item["TanggalAkte"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akta") + " \\n");
                    if (item["NotarisAkte"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Notaris") + " \\n");

                    string qry2 = "<Where>" +
                                    "<Eq>" +
                                        "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                        "<Value Type='Lookup'>" + ID + "</Value>" +
                                    "</Eq>" +
                                  "</Where>";

                    SPList pemegangsaham = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PemegangSaham"));
                    SPQuery query2 = new SPQuery();
                    query2.Query = qry2;

                    SPListItemCollection coll2 = null;
                    coll2 = pemegangsaham.GetItems(query2);
                    foreach (SPListItem i in coll2)
                    {
                        if (i["TanggalMulaiMenjabat"] == null || i["TanggalAkhirMenjabat"] == null)
                            sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai dan Akhir Menjabat Pemegang Saham for " + i.Title + "") + " \\n");
                    }

                    SPList komisarisdireksi = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "KomisarisDireksi"));
                    query2 = new SPQuery();
                    query2.Query = qry2;

                    coll2 = komisarisdireksi.GetItems(query2);
                    foreach (SPListItem i in coll2)
                    {
                        if (i["TanggalMulaiMenjabat"] == null || i["TanggalAkhirMenjabat"] == null)
                            sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai dan Akhir Menjabat Komisaris and Direksi for " + i.Title + "") + " \\n");
                    }
                }
                else if (item["Status"].ToString() == PIC_CORSEC_UPLOAD_SKDP)
                {
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(qry, "SKDP");
                    query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                    SPListItemCollection coll = null;
                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload SKDP") + " \\n");

                    if (item["NoSKDP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No SKDP") + " \\n");
                    if (item["TanggalMulaiBerlakuSKDP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Mulai Berlaku SKDP") + " \\n");
                    if (item["TanggalAkhirBerlakuSKDP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Akhir Berlaku SKDP") + " \\n");
                    if (item["AlamatSKDP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Alamat") + " \\n");
                }
                else if (item["Status"].ToString() == ACCOUNTING_HEAD_INPUT_COMPANY_CODE)
                {
                    if (item["CompanyCodeAPV"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Kode Perusahaan") + " \\n");
                }
                else if (item["Status"].ToString() == ACCOUNTING_UPLOAD_APV)
                {
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(qry, "APV");
                    query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                    SPListItemCollection coll = null;
                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload APV") + " \\n");

                    if (item["NoAPV"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No APV") + " \\n");
                    if (item["TanggalAPV"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal APV") + " \\n");
                }
                else if (item["Status"].ToString() == FINANCE_UPLOAD_SETORAN_MODAL)
                {
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(qry, "Setoran Modal");
                    query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                    SPListItemCollection coll = null;
                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Setoran Modal") + " \\n");

                    if (item["TanggalSetoran"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Setoran") + " \\n");
                }
                else if (item["Status"].ToString() == PIC_CORSEC_UPLOAD_SK_PENGESAHAN)
                {
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(qry, "Akta and SK Pengesahan Pendirian");
                    query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                    SPListItemCollection coll = null;
                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Akta + SK Pengesahan") + " \\n");

                    if (item["NoSK"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No SK") + " \\n");
                    if (item["TanggalDiterbitkanSK"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Diterbitkan SK") + " \\n");

                    //query = new SPQuery();
                    //query.Query = string.Format(qry, "BNRI");
                    //query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                    //coll = document.GetItems(query);
                    //if (coll.Count == 0)
                    //    sb.Append(SR.FieldCanNotEmpty("File Upload BNRI") + " \\n");

                    //if (item["NoBNRI"] == null)
                    //    sb.Append(SR.FieldCanNotEmpty("No BNRI") + " \\n");
                    //if (item["TanggalBNRI"] == null)
                    //    sb.Append(SR.FieldCanNotEmpty("Tanggal BNRI") + " \\n");
                }
                else if (item["Status"].ToString() == TAX_UPLOAD_NPWP)
                {
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(qry, "NPWP");
                    query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                    SPListItemCollection coll = null;
                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload NPWP") + " \\n");

                    if (item["NoSKTNPWP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No SKT") + " \\n");
                    if (item["TanggalSKTNPWP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal SKT") + " \\n");
                    if (item["NoNPWP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No NPWP") + " \\n");
                    if (item["TanggalTerdaftarNPWP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Tanggal Terdaftar") + " \\n");
                    if (item["NamaKPPNPWP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Nama KPP") + " \\n");
                }
                else if (item["Status"].ToString() == TAX_UPLOAD_PKP)
                {
                    if (Convert.ToBoolean(item["StatusPKP"]))
                    {
                        SPQuery query = new SPQuery();
                        query.Query = string.Format(qry, "PKP");
                        query.Folder = web.Folders["PerusahaanBaruDokumen"].SubFolders[item.Title];

                        SPListItemCollection coll = null;
                        coll = document.GetItems(query);
                        if (coll.Count == 0)
                            sb.Append(SR.FieldCanNotEmpty("File Upload PKP") + " \\n");

                        if (item["NoPKP"] == null)
                            sb.Append(SR.FieldCanNotEmpty("No PKP") + " \\n");
                        if (item["TanggalTerdaftarPKP"] == null)
                            sb.Append(SR.FieldCanNotEmpty("Tanggal Terdaftar PKP") + " \\n");
                        if (item["NamaPKP"] == null)
                            sb.Append(SR.FieldCanNotEmpty("Nama PKP") + " \\n");
                    }
                }
            });
            return sb.ToString();
        }

        #endregion

        #region Pendirian Perusahaan Baru Foreign

        private string ValidationPendirianPerusahaanBaruForeign(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            string link = string.Format("{0}", relatedItemLink[0].Trim());
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            string ID = HttpUtility.ParseQueryString(sQuery).Get("ID");

            string qry = "<Where>" +
                             "<And>" +
                                "<Eq>" +
                                    "<FieldRef Name='PendirianPerusahaanBaruForeign' LookupId='True' />" +
                                    "<Value Type='Lookup'>" + ID + "</Value>" +
                                "</Eq>" +
                                "<Eq>" +
                                    "<FieldRef Name='DocumentType' />" +
                                    "<Value Type='Text'>{0}</Value>" +
                                "</Eq>" +
                            "</And>" +
                         "</Where>" +
                         "<OrderBy>" +
                             "<FieldRef Name='Created' Ascending='False' />" +
                         "</OrderBy>";

            StringBuilder sb = new StringBuilder();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendirianPerusahaanBaruForeign"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ID));

                SPList document = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PendirianPerusahaanBaruForeignDokumen"));
                if (item["Status"].ToString() == PIC_CORSEC)
                {
                    SPQuery query = new SPQuery();
                    query.Query = string.Format(qry, "Akta");
                    query.Folder = web.Folders["PendirianPerusahaanBaruForeignDokumen"].SubFolders[item.Title];

                    SPListItemCollection coll = null;
                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Akta") + " \\n");

                    if (item["NoAkta"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No Akta") + " \\n");
                    if (item["DateOfEntryAkta"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Date Of Entry for Akta") + " \\n");

                    query = new SPQuery();
                    query.Query = string.Format(qry, "Certification of Incorporation");
                    query.Folder = web.Folders["PendirianPerusahaanBaruForeignDokumen"].SubFolders[item.Title];

                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Certification of Incorporation") + " \\n");

                    if (item["NoCI"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Company Registration Number") + " \\n");
                    if (item["DateOfEntryCI"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Date Of Entry for Certification of Incorporation") + " \\n");

                    query = new SPQuery();
                    query.Query = string.Format(qry, "Business Profile");
                    query.Folder = web.Folders["PendirianPerusahaanBaruForeignDokumen"].SubFolders[item.Title];

                    coll = document.GetItems(query);
                    if (coll.Count == 0)
                        sb.Append(SR.FieldCanNotEmpty("File Upload Business Profile") + " \\n");

                    if (item["NoBP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("No Business Profile") + " \\n");
                    if (item["DateOfEntryBP"] == null)
                        sb.Append(SR.FieldCanNotEmpty("Date Of Entry for Business Profile") + " \\n");
                }
            });
            return sb.ToString();
        }

        #endregion

        #endregion
    }
}