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
using Microsoft.SharePoint.Utilities;

namespace SPVisionet.CorporateSecretary.Workflow.PendirianPerusahaanBaruIndonesia
{
    public sealed partial class PendirianPerusahaanBaruIndonesia : SequentialWorkflowActivity
    {
        private string ApproveRejectRemarkContentTypeID = string.Empty;
        private string ToDoTaskContentTypeID = string.Empty;
        private string WFNameID = string.Empty;
        private string ApprovalStatus = string.Empty;
        private string Remarks = string.Empty;
        private string OriginatorEmail = string.Empty;
        private string OriginatorName = string.Empty;
        private string DivHeadLoginName = string.Empty;
        private string DivHeadName = string.Empty;
        private string ChiefCorsecLoginName = string.Empty;
        private string ChiefCorsecName = string.Empty;
        private string AccountingHeadLoginName = string.Empty;
        private string AccountingHeadName = string.Empty;
        private string AccountingLoginName = string.Empty;
        private string AccountingName = string.Empty;
        private string TaxLoginName = string.Empty;
        private string TaxName = string.Empty;
        private string FinanceLoginName = string.Empty;
        private string FinanceName = string.Empty;
        private string ApprovedRejectedMailTemplate = string.Empty;
        private string EmailNotificationTemplate = string.Empty;
        private string EmailNotificationOriginatorTemplate = string.Empty;
        private string Subject = string.Empty;
        private string BodyMessage = string.Empty;
        private string AdministratorGroup = string.Empty;
        private string VisitorGroup = string.Empty;
        private StringCollection scInfo = new StringCollection();
        private string Type = string.Empty;

        private const string PENDIRIAN_PERUSAHAAN_BARU = "Pendirian Perusahaan Baru";

        public PendirianPerusahaanBaruIndonesia()
        {
            InitializeComponent();
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

            Type = workflowProperties.Item["Tipe"].ToString();

            ApproveRejectRemarkContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ApproveRejectRemark");
            ToDoTaskContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ToDoTask");

            if (Type == PENDIRIAN_PERUSAHAAN_BARU)
                WFNameID = Util.GetSettingValue(web, "Workflow Name", "Pendirian Perusahaan Baru (Indonesia)");
            else
                WFNameID = Util.GetSettingValue(web, "Workflow Name", "Pembelian Perusahan Baru (Indonesia)");

            ApprovedRejectedMailTemplate = Util.GetSettingValue(web, "Email", "ApprovedRejectedMail");
            EmailNotificationTemplate = Util.GetSettingValue(web, "Email", "EmailNotifaction");
            EmailNotificationOriginatorTemplate = Util.GetSettingValue(web, "Email", "EmailNotificationOrginator");
            AdministratorGroup = Util.GetSettingValue(web, "SharePoint Group", "Administrator");
            VisitorGroup = Util.GetSettingValue(web, "SharePoint Group", "Visitor");

            OriginatorName = workflowProperties.OriginatorUser.Name;
            OriginatorEmail = workflowProperties.OriginatorUser.Email;

            DivHeadLoginName = Util.GetApproval(web, Roles.DIV_HEAD_CORSEC);

            scInfo.Add(string.Format("{0};{1};{2};{3}", "1", OriginatorName, DateTime.Now, "Request"));
        }

        private void ApprovedCondition(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus == "Approve")
                e.Result = true;
        }

        private void TypeCondition(object sender, ConditionalEventArgs e)
        {
            if (Type == PENDIRIAN_PERUSAHAAN_BARU)
                e.Result = true;
        }

        #region Dept Head

        public WorkflowContext createDeptHeadTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createDeptHeadTask_AssignedTo1 = default(System.String);
        public String createDeptHeadTask_Body1 = default(System.String);
        public String createDeptHeadTask_ContentTypeId1 = default(System.String);
        public Int32 createDeptHeadTask_ListItemId1 = default(System.Int32);
        public String createDeptHeadTask_Subject1 = default(System.String);
        public String createDeptHeadTask_TaskTitle1 = default(System.String);
        public String createDeptHeadTask_WFName1 = default(System.String);
        private void PopulateDataDeptHead_ExecuteCode(object sender, EventArgs e)
        {
            createDeptHeadTask___Context1.Initialize(workflowProperties);
            createDeptHeadTask_AssignedTo1 = DivHeadLoginName;
            createDeptHeadTask_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createDeptHeadTask_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createDeptHeadTask_WFName1 = WFNameID;

            if (Type == PENDIRIAN_PERUSAHAAN_BARU)
            {
                createDeptHeadTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
                createDeptHeadTask_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");
            }
            else
            {
                createDeptHeadTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PEMBELIAN_PERUSAHAAN_BARU_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
                createDeptHeadTask_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Pembelian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");
            }

            UpdateItem(Roles.DIV_HEAD_CORSEC, string.Empty);
        }

        private void UpdatePermissionDeptHead_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllDeptHeadTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllDeptHeadTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllDeptHeadTasks_TaskProperties1.PercentComplete = 1;
            updateAllDeptHeadTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetDeptHeadApprovalStatus_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createDeptHeadTask_ListItemId1);
            ApprovalStatus = item["ApproveOrReject"].ToString();

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            DivHeadName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (item["Remarks"] != null)
                Remarks = item["Remarks"].ToString();
            else
                Remarks = string.Empty;

            scInfo.Add(string.Format("{0};{1};{2};{3}", "2", DivHeadName, DateTime.Now, ApprovalStatus));
        }

        #endregion

        #region Chief Corsec

        public WorkflowContext createChiefCorsecTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createChiefCorsecTask_AssignedTo1 = default(System.String);
        public String createChiefCorsecTask_Body1 = default(System.String);
        public String createChiefCorsecTask_ContentTypeId1 = default(System.String);
        public Int32 createChiefCorsecTask_ListItemId1 = default(System.Int32);
        public String createChiefCorsecTask_Subject1 = default(System.String);
        public String createChiefCorsecTask_TaskTitle1 = default(System.String);
        public String createChiefCorsecTask_WFName1 = default(System.String);
        private void PopulateDataChiefCorsec_ExecuteCode(object sender, EventArgs e)
        {
            ApprovalStatus = string.Empty;

            SPWeb web = workflowProperties.Web;
            ChiefCorsecLoginName = Util.GetApproval(web, Roles.CHIEF_CORSEC);

            createChiefCorsecTask___Context1.Initialize(workflowProperties);
            createChiefCorsecTask_AssignedTo1 = ChiefCorsecLoginName;
            createChiefCorsecTask_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createChiefCorsecTask_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createChiefCorsecTask_WFName1 = WFNameID;

            if (Type == PENDIRIAN_PERUSAHAAN_BARU)
            {
                createChiefCorsecTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
                createChiefCorsecTask_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");
            }
            else
            {
                createChiefCorsecTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PEMBELIAN_PERUSAHAAN_BARU_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
                createChiefCorsecTask_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Pembelian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");
            }

            UpdateItem(Roles.CHIEF_CORSEC, string.Empty);
        }

        private void UpdatePermissionChiefCorsec_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllChiefCorsecTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllChiefCorsecTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllChiefCorsecTasks_TaskProperties1.PercentComplete = 1;
            updateAllChiefCorsecTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetChiefCorsecApprovalStatus_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createChiefCorsecTask_ListItemId1);
            ApprovalStatus = item["ApproveOrReject"].ToString();

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            ChiefCorsecName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (item["Remarks"] != null)
                Remarks = item["Remarks"].ToString();
            else
                Remarks = string.Empty;

            scInfo.Add(string.Format("{0};{1};{2};{3}", "3", ChiefCorsecName, DateTime.Now, ApprovalStatus));
        }

        #endregion

        #region Pendirian Perusahaan Baru

        #region PIC Corsec Upload Akta

        public WorkflowContext createPICCorsec1Task___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createPICCorsec1Task_AssignedTo1 = default(System.String);
        public String createPICCorsec1Task_Body1 = default(System.String);
        public String createPICCorsec1Task_ContentTypeId1 = default(System.String);
        public Int32 createPICCorsec1Task_ListItemId1 = default(System.Int32);
        public String createPICCorsec1Task_Subject1 = default(System.String);
        public String createPICCorsec1Task_TaskTitle1 = default(System.String);
        public String createPICCorsec1Task_WFName1 = default(System.String);
        private void PopulateDataPICCorsec1_ExecuteCode(object sender, EventArgs e)
        {
            createPICCorsec1Task___Context1.Initialize(workflowProperties);
            createPICCorsec1Task_AssignedTo1 = workflowProperties.Originator;
            createPICCorsec1Task_ContentTypeId1 = ToDoTaskContentTypeID;
            createPICCorsec1Task_TaskTitle1 = "Need to Upload Document and Update Data Akta for " + workflowProperties.Item.Title;
            createPICCorsec1Task_WFName1 = WFNameID;
            createPICCorsec1Task_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data Akta", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createPICCorsec1Task_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data Akta" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.PIC_CORSEC + " Upload Akta", string.Empty);
        }

        private void UpdatePermissionPICCorsec1_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllPICCorsec1Tasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllPICCorsec1Tasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllPICCorsec1Tasks_TaskProperties1.PercentComplete = 1;
            updateAllPICCorsec1Tasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";

            scInfo.Add(string.Format("{0};{1};{2};{3}", "4", OriginatorName, DateTime.Now, "Upload Document and Update Data Akta"));
        }

        #endregion

        #region PIC Corsec Upload SKDP

        public WorkflowContext createPICCorsec2Task___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createPICCorsec2Task_AssignedTo1 = default(System.String);
        public String createPICCorsec2Task_Body1 = default(System.String);
        public String createPICCorsec2Task_ContentTypeId1 = default(System.String);
        public Int32 createPICCorsec2Task_ListItemId1 = default(System.Int32);
        public String createPICCorsec2Task_Subject1 = default(System.String);
        public String createPICCorsec2Task_TaskTitle1 = default(System.String);
        public String createPICCorsec2Task_WFName1 = default(System.String);
        private void PopulateDataPICCorsec2_ExecuteCode(object sender, EventArgs e)
        {
            createPICCorsec2Task___Context1.Initialize(workflowProperties);
            createPICCorsec2Task_AssignedTo1 = workflowProperties.Originator;
            createPICCorsec2Task_ContentTypeId1 = ToDoTaskContentTypeID;
            createPICCorsec2Task_TaskTitle1 = "Need to Upload Document and Update Data SKDP for " + workflowProperties.Item.Title;
            createPICCorsec2Task_WFName1 = WFNameID;
            createPICCorsec2Task_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data SKDP", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createPICCorsec2Task_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data SKDP" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.PIC_CORSEC + " Upload SKDP", string.Empty);
        }

        private void UpdatePermissionPICCorsec2_ExecuteCode(object sender, EventArgs e)
        {

        }

        public SPWorkflowTaskProperties updateAllPICCorsec2Tasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllPICCorsec2Tasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllPICCorsec2Tasks_TaskProperties1.PercentComplete = 1;
            updateAllPICCorsec2Tasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";

            scInfo.Add(string.Format("{0};{1};{2};{3}", "5", OriginatorName, DateTime.Now, "Upload Document and Update Data SKDP"));
        }

        #endregion

        #region Accounting Head

        public WorkflowContext createAccountingHeadTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createAccountingHeadTask_AssignedTo1 = default(System.String);
        public String createAccountingHeadTask_Body1 = default(System.String);
        public String createAccountingHeadTask_ContentTypeId1 = default(System.String);
        public Int32 createAccountingHeadTask_ListItemId1 = default(System.Int32);
        public String createAccountingHeadTask_Subject1 = default(System.String);
        public String createAccountingHeadTask_TaskTitle1 = default(System.String);
        public String createAccountingHeadTask_WFName1 = default(System.String);
        private void PopulateDataAccountingHead_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            AccountingHeadLoginName = Util.GetApproval(web, Roles.ACCOUNTING_HEAD);

            createAccountingHeadTask___Context1.Initialize(workflowProperties);
            createAccountingHeadTask_AssignedTo1 = AccountingHeadLoginName;
            createAccountingHeadTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createAccountingHeadTask_TaskTitle1 = "Need to Input Company Code for " + workflowProperties.Item.Title;
            createAccountingHeadTask_WFName1 = WFNameID;
            createAccountingHeadTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Input Company Code", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createAccountingHeadTask_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to input company code" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.ACCOUNTING_HEAD + " Input Company Code", string.Empty);
        }

        private void UpdatePermissionAccountingHead_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingHeadLoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllAccountingHeadTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllAccountingHeadTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllAccountingHeadTasks_TaskProperties1.PercentComplete = 1;
            updateAllAccountingHeadTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetAccountingHeadActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createAccountingHeadTask_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            AccountingHeadName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", "6", AccountingHeadName, DateTime.Now, "Input Company Code"));
        }

        #endregion

        #region Accounting

        public WorkflowContext createAccountingTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createAccountingTask_AssignedTo1 = default(System.String);
        public String createAccountingTask_Body1 = default(System.String);
        public String createAccountingTask_ContentTypeId1 = default(System.String);
        public Int32 createAccountingTask_ListItemId1 = default(System.Int32);
        public String createAccountingTask_Subject1 = default(System.String);
        public String createAccountingTask_TaskTitle1 = default(System.String);
        public String createAccountingTask_WFName1 = default(System.String);
        private void PopulateDataAccounting_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            AccountingLoginName = Util.GetApproval(web, Roles.ACCOUNTING);

            createAccountingTask___Context1.Initialize(workflowProperties);
            createAccountingTask_AssignedTo1 = AccountingLoginName;
            createAccountingTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createAccountingTask_TaskTitle1 = "Need to Upload Document and Update Data APV for " + workflowProperties.Item.Title;
            createAccountingTask_WFName1 = WFNameID;
            createAccountingTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data APV", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createAccountingTask_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data APV" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.ACCOUNTING + " Upload APV", string.Empty);
        }

        private void UpdatePermissionAccounting_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingLoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllAccountingTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllAccountingTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllAccountingTasks_TaskProperties1.PercentComplete = 1;
            updateAllAccountingTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetAccountingStaffActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createAccountingHeadTask_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            AccountingName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", "7", AccountingName, DateTime.Now, "Upload Document and Update Data APV"));
        }

        #endregion

        #region Finance

        public WorkflowContext createFinanceTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createFinanceTask_AssignedTo1 = default(System.String);
        public String createFinanceTask_Body1 = default(System.String);
        public String createFinanceTask_ContentTypeId1 = default(System.String);
        public Int32 createFinanceTask_ListItemId1 = default(System.Int32);
        public String createFinanceTask_Subject1 = default(System.String);
        public String createFinanceTask_TaskTitle1 = default(System.String);
        public String createFinanceTask_WFName1 = default(System.String);
        private void PopulateDataFinance_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            FinanceLoginName = Util.GetApproval(web, Roles.FINANCE);

            createFinanceTask___Context1.Initialize(workflowProperties);
            createFinanceTask_AssignedTo1 = FinanceLoginName;
            createFinanceTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createFinanceTask_TaskTitle1 = "Need to Upload Document and Update Data Setoran Modal for " + workflowProperties.Item.Title;
            createFinanceTask_WFName1 = WFNameID;
            createFinanceTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data Setoran Modal", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createFinanceTask_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data Setoran Modal" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.FINANCE + " Upload Setoran Modal", string.Empty);
        }

        private void UpdatePermissionFinance_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, FinanceLoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllFinancTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllFinancTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllFinancTasks_TaskProperties1.PercentComplete = 1;
            updateAllFinancTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetFinanceActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createFinanceTask_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            FinanceName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", "8", FinanceName, DateTime.Now, "Upload Document and Update Data Setoran Modal"));
        }

        #endregion

        #region PIC Corsec Upload SK Pengesahan

        public WorkflowContext createPICCorsec3Task___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createPICCorsec3Task_AssignedTo1 = default(System.String);
        public String createPICCorsec3Task_Body1 = default(System.String);
        public String createPICCorsec3Task_ContentTypeId1 = default(System.String);
        public Int32 createPICCorsec3Task_ListItemId1 = default(System.Int32);
        public String createPICCorsec3Task_Subject1 = default(System.String);
        public String createPICCorsec3Task_TaskTitle1 = default(System.String);
        public String createPICCorsec3Task_WFName1 = default(System.String);
        private void PopulateDataPICCorsec3_ExecuteCode(object sender, EventArgs e)
        {
            createPICCorsec3Task___Context1.Initialize(workflowProperties);
            createPICCorsec3Task_AssignedTo1 = workflowProperties.Originator;
            createPICCorsec3Task_ContentTypeId1 = ToDoTaskContentTypeID;
            createPICCorsec3Task_TaskTitle1 = "Need to Upload Document and Update Data SK Pengesahan for " + workflowProperties.Item.Title;
            createPICCorsec3Task_WFName1 = WFNameID;
            createPICCorsec3Task_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data SK Pengesahan", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createPICCorsec3Task_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data SK Pengesahan" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.PIC_CORSEC + " Upload SK Pengesahan", string.Empty);
        }

        private void UpdatePermissionPICCorsec3_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, FinanceLoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllPICCorsec3Tasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllPICCorsec3Tasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllPICCorsec3Tasks_TaskProperties1.PercentComplete = 1;
            updateAllPICCorsec3Tasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";

            scInfo.Add(string.Format("{0};{1};{2};{3}", "9", OriginatorName, DateTime.Now, "Upload Document and Update Data SK Pengesahan"));
        }

        #endregion

        #region Tax Upload NPWP

        public WorkflowContext createTaxTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createTaxTask_AssignedTo1 = default(System.String);
        public String createTaxTask_Body1 = default(System.String);
        public String createTaxTask_ContentTypeId1 = default(System.String);
        public Int32 createTaxTask_ListItemId1 = default(System.Int32);
        public String createTaxTask_Subject1 = default(System.String);
        public String createTaxTask_TaskTitle1 = default(System.String);
        public String createTaxTask_WFName1 = default(System.String);
        private void PopulateDataTax_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            TaxLoginName = Util.GetApproval(web, Roles.TAX);

            createTaxTask___Context1.Initialize(workflowProperties);
            createTaxTask_AssignedTo1 = TaxLoginName;
            createTaxTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createTaxTask_TaskTitle1 = "Need to Upload Document and Update Data NPWP for " + workflowProperties.Item.Title;
            createTaxTask_WFName1 = WFNameID;
            createTaxTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data NPWP", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createTaxTask_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data NPWP" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.TAX + " Upload NPWP", string.Empty);
        }

        private void UpdatePermissionTax_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, FinanceLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, TaxLoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllTaxTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllTaxTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTaxTasks_TaskProperties1.PercentComplete = 1;
            updateAllTaxTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetTaxActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createTaxTask_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            TaxName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", "10", TaxName, DateTime.Now, "Upload Document and Update Data NPWP"));
        }

        #endregion

        #region Tax Upload PKP

        public WorkflowContext createTax2Task___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createTax2Task_AssignedTo1 = default(System.String);
        public String createTax2Task_Body1 = default(System.String);
        public String createTax2Task_ContentTypeId1 = default(System.String);
        public Int32 createTax2Task_ListItemId1 = default(System.Int32);
        public String createTax2Task_Subject1 = default(System.String);
        public String createTax2Task_TaskTitle1 = default(System.String);
        public String createTax2Task_WFName1 = default(System.String);
        private void PopulateDataTax2_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            TaxLoginName = Util.GetApproval(web, Roles.TAX);

            createTax2Task___Context1.Initialize(workflowProperties);
            createTax2Task_AssignedTo1 = TaxLoginName;
            createTax2Task_ContentTypeId1 = ToDoTaskContentTypeID;
            createTax2Task_TaskTitle1 = "Need to Upload Document and Update Data PKP for " + workflowProperties.Item.Title;
            createTax2Task_WFName1 = WFNameID;
            createTax2Task_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data PKP", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createTax2Task_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pendirian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data PKP" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.TAX + " Upload PKP", string.Empty);
        }

        private void UpdatePermissionTax2_ExecuteCode(object sender, EventArgs e)
        {

        }

        public SPWorkflowTaskProperties UpdateAllTax2Tasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void UpdateAllTax2Tasks_MethodInvoking(object sender, EventArgs e)
        {
            UpdateAllTax2Tasks_TaskProperties1.PercentComplete = 1;
            UpdateAllTax2Tasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetTax2ActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createTax2Task_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            TaxName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", "11", TaxName, DateTime.Now, "Upload Document and Update Data PKP"));
        }

        #endregion

        #endregion

        #region Pembelian Perusahaan Baru

        #region PIC Corsec

        public WorkflowContext createPICCorsecTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createPICCorsecTask_AssignedTo1 = default(System.String);
        public String createPICCorsecTask_Body1 = default(System.String);
        public String createPICCorsecTask_ContentTypeId1 = default(System.String);
        public Int32 createPICCorsecTask_ListItemId1 = default(System.Int32);
        public String createPICCorsecTask_Subject1 = default(System.String);
        public String createPICCorsecTask_TaskTitle1 = default(System.String);
        public String createPICCorsecTask_WFName1 = default(System.String);
        private void PopulateDataPICCorsec_ExecuteCode(object sender, EventArgs e)
        {
            createPICCorsecTask___Context1.Initialize(workflowProperties);
            createPICCorsecTask_AssignedTo1 = workflowProperties.Originator;
            createPICCorsecTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createPICCorsecTask_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createPICCorsecTask_WFName1 = WFNameID;
            createPICCorsecTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data", RequestCode.PEMBELIAN_PERUSAHAAN_BARU_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createPICCorsecTask_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pembelian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.PIC_CORSEC, string.Empty);
        }

        private void UpdatePermissionPICCorsec_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllPICCorsecTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllPICCorsecTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllPICCorsecTasks_TaskProperties1.PercentComplete = 1;
            updateAllPICCorsecTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";

            scInfo.Add(string.Format("{0};{1};{2};{3}", "4", OriginatorName, DateTime.Now, "Upload Document and Update Data"));
        }

        #endregion

        #region Acc Head

        public WorkflowContext createAccHeadTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createAccHeadTask_AssignedTo1 = default(System.String);
        public String createAccHeadTask_Body1 = default(System.String);
        public String createAccHeadTask_ContentTypeId1 = default(System.String);
        public Int32 createAccHeadTask_ListItemId1 = default(System.Int32);
        public String createAccHeadTask_Subject1 = default(System.String);
        public String createAccHeadTask_TaskTitle1 = default(System.String);
        public String createAccHeadTask_WFName1 = default(System.String);
        private void PopulateDataAccHead_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            AccountingHeadLoginName = Util.GetApproval(web, Roles.ACCOUNTING_HEAD);

            createAccHeadTask___Context1.Initialize(workflowProperties);
            createAccHeadTask_AssignedTo1 = AccountingHeadLoginName;
            createAccHeadTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createAccHeadTask_TaskTitle1 = "Need to Input Company Code for " + workflowProperties.Item.Title;
            createAccHeadTask_WFName1 = WFNameID;
            createAccHeadTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Input Company Code", RequestCode.PEMBELIAN_PERUSAHAAN_BARU_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createAccHeadTask_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pembelian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to input company code" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.ACCOUNTING_HEAD + " Input Company Code", string.Empty);
        }

        private void UpdatePermissionAccHead_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingHeadLoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllAccHeadTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllAccHeadTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllAccHeadTasks_TaskProperties1.PercentComplete = 1;
            updateAllAccHeadTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetAccHeadActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createAccHeadTask_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            AccountingHeadName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", "5", AccountingHeadName, DateTime.Now, "Input Company Code"));
        }

        #endregion

        #region Acct

        public WorkflowContext createAccTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createAccTask_AssignedTo1 = default(System.String);
        public String createAccTask_Body1 = default(System.String);
        public String createAccTask_ContentTypeId1 = default(System.String);
        public Int32 createAccTask_ListItemId1 = default(System.Int32);
        public String createAccTask_Subject1 = default(System.String);
        public String createAccTask_TaskTitle1 = default(System.String);
        public String createAccTask_WFName1 = default(System.String);
        private void PopulateDataAcc_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            AccountingLoginName = Util.GetApproval(web, Roles.ACCOUNTING);

            createAccTask___Context1.Initialize(workflowProperties);
            createAccTask_AssignedTo1 = AccountingLoginName;
            createAccTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createAccTask_TaskTitle1 = "Need to Upload Document and Update Data APV for " + workflowProperties.Item.Title;
            createAccTask_WFName1 = WFNameID;
            createAccTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data APV", RequestCode.PEMBELIAN_PERUSAHAAN_BARU_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createAccTask_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Pembelian Perusahaan Baru (Indonesia) Task", workflowProperties.Item.Title, "need you to upload document and update data APV" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.ACCOUNTING + " Upload APV", string.Empty);
        }

        private void UpdatePermissionAcc_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, AccountingLoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAccAllTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAccAllTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAccAllTasks_TaskProperties1.PercentComplete = 1;
            updateAccAllTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetAccActionData_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createAccTask_ListItemId1);

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            AccountingName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            scInfo.Add(string.Format("{0};{1};{2};{3}", "6", AccountingName, DateTime.Now, "Upload Document and Update Data APV"));
        }

        #endregion

        #endregion

        private void UpdatePermissionApprove_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
            Util.UpdateGroupPermission(workflowProperties.Web, false, workflowProperties.Item, VisitorGroup, "Read");
        }

        private void SendMailApprove_ExecuteCode(object sender, EventArgs e)
        {
            UpdateItem(string.Empty, "Approved");

            string Title = string.Empty;
            string URL = string.Format("{0}/Lists/PerusahaanBaru/DispForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);

            if (Type == PENDIRIAN_PERUSAHAAN_BARU)
            {
                Title = "Pendirian Perusahaan Baru (Indonesia)";
                Subject = string.Format("CorsecSP {0} [ {1} ] is already Completed", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            }
            else
            {
                Title = "Pembelian Perusahaan Baru (Indonesia)";
                Subject = string.Format("CorsecSP {0} [ {1} ] is already Completed", RequestCode.PEMBELIAN_PERUSAHAAN_BARU_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            }

            BodyMessage = string.Format(ApprovedRejectedMailTemplate, OriginatorName, Title, workflowProperties.Item.Title, "has been completed" + Util.GenerateApprovalInformation(scInfo), URL);
            SPUtility.SendEmail(workflowProperties.Web, false, false, OriginatorEmail, Subject, BodyMessage);

            string[] splitDivHead = DivHeadLoginName.Split(';');
            foreach (string item in splitDivHead)
            {
                SPUser userDivHead = workflowProperties.Web.Users[item];
                BodyMessage = string.Format(ApprovedRejectedMailTemplate, userDivHead.Name, Title, workflowProperties.Item.Title, "has been completed by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                SPUtility.SendEmail(workflowProperties.Web, false, false, userDivHead.Email, Subject, BodyMessage);
            }

            string[] splitChiefCorsec = ChiefCorsecLoginName.Split(';');
            foreach (string item in splitChiefCorsec)
            {
                SPUser userCorsec = workflowProperties.Web.Users[item];
                BodyMessage = string.Format(ApprovedRejectedMailTemplate, userCorsec.Name, Title, workflowProperties.Item.Title, "has been completed by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                SPUtility.SendEmail(workflowProperties.Web, false, false, userCorsec.Email, Subject, BodyMessage);
            }

            if (Type == PENDIRIAN_PERUSAHAAN_BARU)
            {
                string[] splitTax = TaxLoginName.Split(';');
                foreach (string item in splitTax)
                {
                    SPUser userTax = workflowProperties.Web.Users[item];
                    BodyMessage = string.Format(ApprovedRejectedMailTemplate, userTax.Name, Title, workflowProperties.Item.Title, "has been completed by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                    SPUtility.SendEmail(workflowProperties.Web, false, false, userTax.Email, Subject, BodyMessage);
                }

                string[] splitFinance = FinanceLoginName.Split(';');
                foreach (string item in splitFinance)
                {
                    SPUser userFinance = workflowProperties.Web.Users[item];
                    BodyMessage = string.Format(ApprovedRejectedMailTemplate, userFinance.Name, Title, workflowProperties.Item.Title, "has been completed by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                    SPUtility.SendEmail(workflowProperties.Web, false, false, userFinance.Email, Subject, BodyMessage);
                }
            }

            string[] splitAccounting = AccountingLoginName.Split(';');
            foreach (string item in splitAccounting)
            {
                SPUser userAccounting = workflowProperties.Web.Users[item];
                BodyMessage = string.Format(ApprovedRejectedMailTemplate, userAccounting.Name, Title, workflowProperties.Item.Title, "has been completed by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                SPUtility.SendEmail(workflowProperties.Web, false, false, userAccounting.Email, Subject, BodyMessage);
            }
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
            //UpdatePerson(null, null);

            string Title = string.Empty;
            string RejectedName = ChiefCorsecName == string.Empty ? DivHeadName : ChiefCorsecName;
            string URL = string.Format("{0}/Lists/PerusahaanBaru/EditForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);

            if (Type == PENDIRIAN_PERUSAHAAN_BARU)
            {
                Title = "Pendirian Perusahaan Baru (Indonesia)";
                Subject = string.Format("CorsecSP {0} [ {1} ] Rejected", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            }
            else
            {
                Title = "Pembelian Perusahaan Baru (Indonesia)";
                Subject = string.Format("CorsecSP {0} [ {1} ] Rejected", RequestCode.PEMBELIAN_PERUSAHAAN_BARU_INDONESIA, workflowProperties.Item["NamaPerusahaan"].ToString());
            }

            BodyMessage = string.Format(ApprovedRejectedMailTemplate, OriginatorName, Title, workflowProperties.Item.Title, "has been rejected by " + RejectedName + Util.GenerateApprovalInformation(scInfo) + "<br/><br/>Remarks: " + Remarks, URL);

            sendEmailReject_Headers1.Add("To", OriginatorEmail);
            sendEmailReject_Headers1.Add("Subject", Subject);
            sendEmailReject_Body1 = BodyMessage;
        }
    }
}
