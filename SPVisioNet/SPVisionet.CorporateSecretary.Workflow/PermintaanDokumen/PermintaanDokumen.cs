using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;
using System.Collections.Specialized;
using SPVisionet.CorporateSecretary.Common;
using SPVisionet.CorporateSecretary.Workflow.Activity;

namespace SPVisionet.CorporateSecretary.Workflow.PermintaanDokumen
{
    public sealed partial class PermintaanDokumen : SequentialWorkflowActivity
    {
        private string ApproveRejectRemarkContentTypeID = string.Empty;
        private string ToDoTaskContentTypeID = string.Empty;
        private string WFNameID = string.Empty;
        private string ApprovalStatus = string.Empty;
        private string Remarks = string.Empty;
        private string OriginatorEmail = string.Empty;
        private string OriginatorName = string.Empty;
        private string CustodianLoginName = string.Empty;
        private string CustodianName = string.Empty;
        private string ApprovedRejectedMailTemplate = string.Empty;
        private string EmailNotificationTemplate = string.Empty;
        private string EmailNotificationOriginatorTemplate = string.Empty;
        private string Subject = string.Empty;
        private string BodyMessage = string.Empty;
        private string AdministratorGroup = string.Empty;
        private string VisitorGroup = string.Empty;
        private StringCollection scInfo = new StringCollection();
        public StringCollection assignedToColl;
        private string ReplicatorAllUsers = string.Empty;
        public ArrayList ListItemIdCollection = new ArrayList();
        private int taskID = 0;
        private string NApprovalName = string.Empty;
        private int Count = 0;

        public PermintaanDokumen()
        {
            InitializeComponent();
        }

        private void ApprovedCondition(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus == "Approve")
                e.Result = true;
        }

        private void UpdateItem(string Role, string ApprovalStatus)
        {
            SPListItem item = workflowProperties.Item;
            item["Status"] = Role;
            item["ApprovalStatus"] = ApprovalStatus;
            item.Update();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            workflowId = workflowProperties.WorkflowId;
            SPWeb web = workflowProperties.Web;

            ApproveRejectRemarkContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ApproveRejectRemark");
            ToDoTaskContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ToDoTask");
            WFNameID = Util.GetSettingValue(web, "Workflow Name", "Permintaan Dokumen");
            ApprovedRejectedMailTemplate = Util.GetSettingValue(web, "Email", "ApprovedRejectedMail");
            EmailNotificationTemplate = Util.GetSettingValue(web, "Email", "EmailNotifaction");
            EmailNotificationOriginatorTemplate = Util.GetSettingValue(web, "Email", "EmailNotificationOrginator");
            AdministratorGroup = Util.GetSettingValue(web, "SharePoint Group", "Administrator");
            VisitorGroup = Util.GetSettingValue(web, "SharePoint Group", "Visitor");

            OriginatorName = workflowProperties.OriginatorUser.Name;
            OriginatorEmail = workflowProperties.OriginatorUser.Email;

            CustodianLoginName = Util.GetApproval(web, Roles.CUSTODIAN);

            scInfo.Add(string.Format("{0};{1};{2};{3}", "1", OriginatorName, DateTime.Now, "Request"));
        }

        #region Custodian

        public WorkflowContext createCustodianTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createCustodianTask_AssignedTo1 = default(System.String);
        public String createCustodianTask_Body1 = default(System.String);
        public String createCustodianTask_ContentTypeId1 = default(System.String);
        public Int32 createCustodianTask_ListItemId1 = default(System.Int32);
        public String createCustodianTask_Subject1 = default(System.String);
        public String createCustodianTask_TaskTitle1 = default(System.String);
        public String createCustodianTask_WFName1 = default(System.String);
        private void PopulateDataCustodian_ExecuteCode(object sender, EventArgs e)
        {
            createCustodianTask___Context1.Initialize(workflowProperties);
            createCustodianTask_AssignedTo1 = CustodianLoginName;
            createCustodianTask_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createCustodianTask_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createCustodianTask_WFName1 = WFNameID;
            createCustodianTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PERMINTAAN_DOKUMEN, workflowProperties.Item.Title);
            createCustodianTask_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Permintaan Dokumen Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.CUSTODIAN, string.Empty);
        }

        private void UpdatePermissionCustodian_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, CustodianLoginName, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllCustodianTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllCustodianTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllCustodianTasks_TaskProperties1.PercentComplete = 1;
            updateAllCustodianTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetCustodianApprovalStatus_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createCustodianTask_ListItemId1);
            ApprovalStatus = item["ApproveOrReject"].ToString();

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            CustodianName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (item["Remarks"] != null)
                Remarks = item["Remarks"].ToString();
            else
                Remarks = string.Empty;

            scInfo.Add(string.Format("{0};{1};{2};{3}", "2", CustodianName, DateTime.Now, ApprovalStatus));
        }

        #endregion

        #region Replicator

        private void PopulateDataReplicator_ExecuteCode(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(workflowProperties.Web.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        string ChiefLegal = string.Empty;
                        string DivHead = string.Empty;
                        string ChiefLegalDivHead = string.Empty;

                        SPList document = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PermintaanDokumenDokumen"));
                        SPQuery query = new SPQuery();
                        query.Query = "<Where>" +
                                          "<Eq>" +
                                             "<FieldRef Name='PermintaanDokumen' LookupId='True' />" +
                                             "<Value Type='Lookup'>" + workflowProperties.Item.ID + "</Value>" +
                                          "</Eq>" +
                                      "</Where>";

                        SPListItemCollection coll = document.GetItems(query);
                        if (coll.Count > 0)
                        {
                            foreach (SPListItem item in coll)
                            {
                                string TipeDokument = item["TipeDokumen"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                                if (TipeDokument.ToLower() == "sertifikat")
                                {
                                    if (ChiefLegal == string.Empty)
                                        ChiefLegal = Util.GetApproval(web, Roles.CHIEF_LEGAL);
                                }
                                else
                                {
                                    if (DivHead == string.Empty)
                                        DivHead = Util.GetApproval(web, Roles.DIV_HEAD_CORSEC);
                                }
                            }
                        }

                        if (DivHead != string.Empty && ChiefLegal != string.Empty)
                            ChiefLegalDivHead = string.Format("{0};{1}", DivHead, ChiefLegal);
                        else
                        {
                            if (DivHead != string.Empty)
                                ChiefLegalDivHead = DivHead;
                            if (ChiefLegal != string.Empty)
                                ChiefLegalDivHead = ChiefLegal;
                        }

                        assignedToColl = new StringCollection();
                        ReplicatorAllUsers = ChiefLegalDivHead;
                        string[] split = ReplicatorAllUsers.Split(';');
                        Count = split.Count();
                        foreach (string item in split)
                        {
                            if (item != string.Empty)
                                assignedToColl.Add(item);
                        }
                    }
                }
            });
        }

        private void UpdatePermissionReplicator_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, CustodianLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ReplicatorAllUsers, "Read");
        }

        public String logToHistoryListActivity1_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity1_HistoryOutcome1 = default(System.String);
        private void logToHistoryListActivity1_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity1_HistoryDescription1 = string.Format("Prepare create task for {0}", ReplicatorAllUsers);
            logToHistoryListActivity1_HistoryOutcome1 = string.Empty;
        }

        #region Replicate Task

        private void replicatorActivity1_Initialized(object sender, EventArgs e)
        {
            UpdateItem("Chief Legal and Div Head Approval", string.Empty);
        }

        private void replicatorActivity1_ChildInitialized(object sender, ReplicatorChildEventArgs e)
        {
            SPWorkflowTaskProperties childTaskProperties = new SPWorkflowTaskProperties();
            childTaskProperties.Title = "Need Approval for " + workflowProperties.Item.Title;
            childTaskProperties.AssignedTo = (string)e.InstanceData;
            childTaskProperties.PercentComplete = 0;
            childTaskProperties.ExtendedProperties["WF"] = WFNameID;
            childTaskProperties.SendEmailNotification = false;

            CreateSingleTask currentChildActivity = (CreateSingleTask)e.Activity;
            currentChildActivity.__Context = createCustodianTask___Context1;
            currentChildActivity.ContentTypeId = ApproveRejectRemarkContentTypeID;
            currentChildActivity.Subject = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PERMINTAAN_DOKUMEN, workflowProperties.Item.Title);
            currentChildActivity.Body = string.Format(EmailNotificationTemplate, "{0}", "Permintaan Dokumen Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");
            currentChildActivity.TaskProperties = childTaskProperties;
        }

        private void replicatorActivity1_ChildCompleted(object sender, ReplicatorChildEventArgs e)
        {
            try
            {
                CreateSingleTask currentChildActivity = (CreateSingleTask)e.Activity;
                taskID = currentChildActivity.ListItemId;
                ListItemIdCollection.Add(taskID);
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPWeb web = workflowProperties.Item.Web;

                    SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(taskID);
                    ApprovalStatus = item["ApproveOrReject"].ToString();

                    NApprovalName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

                    if (item["Remarks"] != null)
                        Remarks = item["Remarks"].ToString();
                    else
                        Remarks = string.Empty;
                });

                scInfo.Add(string.Format("{0};{1};{2};{3}", (2 + ListItemIdCollection.Count), NApprovalName, DateTime.Now, ApprovalStatus));
            }
            catch
            {
            }
        }

        private void replicatorActivity1_UntilCondition(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus.ToLower() == "reject" || assignedToColl.Count == ListItemIdCollection.Count)
                e.Result = true;
            else
                e.Result = false;
        }

        private void replicatorActivity1_Completed(object sender, EventArgs e)
        {

        }

        #endregion

        public SPWorkflowTaskProperties updateAllReplicatorTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllReplicatorTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllReplicatorTasks_TaskProperties1.PercentComplete = 1;
            updateAllReplicatorTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        #endregion

        #region Custodian 2

        public WorkflowContext createCustodian2Task___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createCustodian2Task_AssignedTo1 = default(System.String);
        public String createCustodian2Task_Body1 = default(System.String);
        public String createCustodian2Task_ContentTypeId1 = default(System.String);
        public Int32 createCustodian2Task_ListItemId1 = default(System.Int32);
        public String createCustodian2Task_Subject1 = default(System.String);
        public String createCustodian2Task_TaskTitle1 = default(System.String);
        public String createCustodian2Task_WFName1 = default(System.String);
        private void PopulateDataCustodian2_ExecuteCode(object sender, EventArgs e)
        {
            createCustodian2Task___Context1.Initialize(workflowProperties);
            createCustodian2Task_AssignedTo1 = CustodianLoginName;
            createCustodian2Task_ContentTypeId1 = ToDoTaskContentTypeID;
            createCustodian2Task_TaskTitle1 = "Need to Update Tanggal Estimasi Pengembalian for " + workflowProperties.Item.Title;
            createCustodian2Task_WFName1 = WFNameID;
            createCustodian2Task_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Update Tanggal Estimasi Pengembalian", RequestCode.PERMINTAAN_DOKUMEN, workflowProperties.Item.Title);
            createCustodian2Task_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Permintaan Dokumen Task", workflowProperties.Item.Title, "need you to update tanggal estimasi pengembalian" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.CUSTODIAN + " Update Tanggal Estimasi Pengembalian", string.Empty);
        }

        private void UpdatePermissionCustodian2_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, CustodianLoginName, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ReplicatorAllUsers, "Read");
        }

        public SPWorkflowTaskProperties updateAllCustodian2Tasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllCustodian2Tasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllCustodian2Tasks_TaskProperties1.PercentComplete = 1;
            updateAllCustodian2Tasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetCustodian2ActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createCustodian2Task_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            CustodianName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", 3 + Count, CustodianName, DateTime.Now, "Update Tanggal Estimasi Pengembalian"));
        }

        #endregion

        private void UpdatePermissionApprove_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, false, workflowProperties.Item, VisitorGroup, "Read");
        }

        public StringDictionary sendEmailApprove_Headers1 = new System.Collections.Specialized.StringDictionary();
        public String sendEmailApprove_Body1 = default(System.String);
        private void sendEmailApprove_MethodInvoking(object sender, EventArgs e)
        {
            UpdateItem(string.Empty, "Approved");

            string URL = string.Format("{0}/Lists/PermintaanDokumen/DispForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] is already Completed", RequestCode.PERMINTAAN_DOKUMEN, workflowProperties.Item.Title);
            BodyMessage = string.Format(ApprovedRejectedMailTemplate, OriginatorName, "Permintaan Dokumen", workflowProperties.Item.Title, "has been completed" + Util.GenerateApprovalInformation(scInfo), URL);

            sendEmailApprove_Headers1.Add("To", OriginatorEmail);
            sendEmailApprove_Headers1.Add("Subject", Subject);
            sendEmailApprove_Body1 = BodyMessage;
        }

        private void UpdatePermissionReject_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public StringDictionary sendEmailReject_Headers1 = new System.Collections.Specialized.StringDictionary();
        public String sendEmailReject_Body1 = default(System.String);
        private void sendEmailReject_MethodInvoking(object sender, EventArgs e)
        {
            UpdateItem(string.Empty, "Rejected");

            string RejectedName = NApprovalName == string.Empty ? CustodianName : NApprovalName;
            string URL = string.Format("{0}/Lists/PermintaanDokumen/EditForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] Rejected", RequestCode.PERMINTAAN_DOKUMEN, workflowProperties.Item.Title);

            BodyMessage = string.Format(ApprovedRejectedMailTemplate, OriginatorName, "Permintaan Dokumen", workflowProperties.Item.Title, "has been rejected by " + RejectedName + Util.GenerateApprovalInformation(scInfo) + "<br/><br/>Remarks: " + Remarks, URL);

            sendEmailReject_Headers1.Add("To", OriginatorEmail);
            sendEmailReject_Headers1.Add("Subject", Subject);
            sendEmailReject_Body1 = BodyMessage;
        }
    }
}
