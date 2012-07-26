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

namespace SPVisionet.CorporateSecretary.Workflow.Layouts.SPVisionet.CorporateSecretary.Workflow.ApproveRejectRemarkCT
{
    public partial class ApproveRejectRemarkCT : LayoutsPageBase
    {
        #region Fields

        private Guid taskListId = Guid.Empty;
        private int taskItemId = 0;
        private string source = string.Empty;
        private const string CHIEF_LEGAL_AND_DIV_HEAD_APPROVAL = "Chief Legal and Div Head Approval";

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
            if (ddlApprovalStatus.SelectedValue == string.Empty)
            {
                Util.ShowMessage(Page, SR.FieldCanNotEmpty("Approval Status"));
                return;
            }

            SPWeb web = SPControl.GetContextWeb(this.Context);
            using (SPSite site = new SPSite(web.Url, web.Site.SystemAccount.UserToken))
            {
                using (SPWeb webSA = site.OpenWeb())
                {
                    webSA.AllowUnsafeUpdates = true;
                    SPList taskList = webSA.Lists[taskListId];
                    SPListItem taskItem = taskList.GetItemById(taskItemId);

                    Hashtable taskData = new Hashtable();
                    taskData.Add("PercentComplete", 1);
                    taskData.Add("Completed", true);
                    taskData.Add("ApproveOrReject", ddlApprovalStatus.SelectedValue);
                    taskData.Add("Status", "Completed");
                    taskData.Add("Remarks", txtRemarks.Text);
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
                    if (taskItem["Remarks"] != null)
                        txtRemarks.Text = Convert.ToString(taskItem["Remarks"]);

                    if (Convert.ToString(taskItem["ApproveOrReject"]) == "Reject" || Convert.ToString(taskItem["ApproveOrReject"]) == "Approve")
                        ddlApprovalStatus.SelectedValue = Convert.ToString(taskItem["ApproveOrReject"]);

                    if (taskItem["WorkflowLink"].ToString().Contains("Lists/SIUP"))
                        GenerateSIUPLink(taskItem["WorkflowLink"].ToString());
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/TDP"))
                        GenerateTDPLink(taskItem["WorkflowLink"].ToString());
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/IzinUsaha"))
                        GenerateIzinUsahaLink(taskItem["WorkflowLink"].ToString());
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PendaftaranPMAPMDN"))
                        GeneratePendaftaranPMAPMDNLink(taskItem["WorkflowLink"].ToString());
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PerubahanPTBiasaMenjadiPMAPMDN"))
                        GeneratePerubahanPTBiasaMenjadiPMAPMDNLink(taskItem["WorkflowLink"].ToString());
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PermintaanDokumen"))
                        GeneratePermintaanDokumenLink(taskItem["WorkflowLink"].ToString());
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PerusahaanBaru"))
                        GeneratePendirianPerusahaanBaruIndonesiaLink(taskItem["WorkflowLink"].ToString());
                    else if (taskItem["WorkflowLink"].ToString().Contains("Lists/PendirianPerusahaanBaruForeign"))
                        GeneratePendirianPerusahaanBaruForeignLink(taskItem["WorkflowLink"].ToString());
                    else
                    {
                        string[] relatedItemLink = Convert.ToString(taskItem["WorkflowLink"]).Split(',');
                        linkRelatedItem.Target = "_blank";
                        linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
                        linkRelatedItem.Text = relatedItemLink[1].Trim();
                    }
                });
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        #region SIUP

        private void GenerateSIUPLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "SIUP"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == Common.Roles.DIV_HEAD_CORSEC)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #region TDP

        private void GenerateTDPLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "TDP"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == Common.Roles.DIV_HEAD_CORSEC)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #region Izin Usaha

        private void GenerateIzinUsahaLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "IzinUsaha"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == Common.Roles.DIV_HEAD_CORSEC || item["Status"].ToString() == Common.Roles.CHIEF_CORSEC)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #region Pendaftaran PMA/PMDN

        private void GeneratePendaftaranPMAPMDNLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendaftaranPMAPMDN"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == Common.Roles.DIV_HEAD_CORSEC || item["Status"].ToString() == Common.Roles.CHIEF_CORSEC)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #region Pendaftaran PMA/PMDN

        private void GeneratePerubahanPTBiasaMenjadiPMAPMDNLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerubahanPTBiasaMenjadiPMAPMDN"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == Common.Roles.DIV_HEAD_CORSEC || item["Status"].ToString() == Common.Roles.CHIEF_CORSEC)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #region Permintaan Dokumen

        private void GeneratePermintaanDokumenLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumen"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == CHIEF_LEGAL_AND_DIV_HEAD_APPROVAL)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #region Pendirian Perusahaan Baru (Indonesia)

        private void GeneratePendirianPerusahaanBaruIndonesiaLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PerusahaanBaru"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == Common.Roles.CHIEF_CORSEC)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #region Pendirian Perusahaan Baru (Foreign)

        private void GeneratePendirianPerusahaanBaruForeignLink(string wfLink)
        {
            string[] relatedItemLink = wfLink.Split(',');
            linkRelatedItem.Target = "_blank";

            string link = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            Uri tempUri = new Uri(link);
            string sQuery = tempUri.Query;
            ViewState["ID"] = HttpUtility.ParseQueryString(sQuery).Get("ID");

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendirianPerusahaanBaruForeign"));
                SPListItem item = list.GetItemById(Convert.ToInt32(ViewState["ID"]));
                if (item["Status"].ToString() == Common.Roles.CHIEF_CORSEC)
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim());
                else
                    linkRelatedItem.NavigateUrl = string.Format("{0}", relatedItemLink[0].Trim().Replace("DispForm", "EditForm"));
            });
            linkRelatedItem.Text = relatedItemLink[1].Trim();
        }

        #endregion

        #endregion
    }
}