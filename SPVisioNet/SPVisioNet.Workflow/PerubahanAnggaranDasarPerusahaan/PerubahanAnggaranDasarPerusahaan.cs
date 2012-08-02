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
using SPVisionet.CorporateSecretary.Common;
using Microsoft.SharePoint.Utilities;

namespace SPVisionet.Workflow.PerubahanAnggaranDasarPerusahaan
{
    public sealed partial class PerubahanAnggaranDasarPerusahaan : SequentialWorkflowActivity
    {
        public PerubahanAnggaranDasarPerusahaan()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();
        private string CodeName = "ADP"; //PERUBAHAN_ANGGARAN_DASAR_DAN_DATA_PERUSAHAAN
        private string module = string.Empty;
        private string[] StepWF = { "Entry Perubahan Anggaran Dasar", "Approve oleh Authorized Person", "PIC Update Akta", "PIC Upload SKDP", "PIC Upload NPWP dan SKT", "PIC Upload APV", "PIC Upload Setoran Modal","PIC Upload SK Persetujuan" };
        private string PicCorsec = string.Empty;

        private string PicCorsecEmail = string.Empty;
        private string PicCorsecFullName = string.Empty;
        private string PicDivHeadCorsec = string.Empty;
        private string PicDivHeadEmail = string.Empty;
        private string PicDivHeadFullName = string.Empty;
        private string PicTax = string.Empty;
        private string PicTaxEmail = string.Empty;
        private string PicTaxFullName = string.Empty;
        private string PicAcc = string.Empty;
        private string PicAccEmail = string.Empty;
        private string PicAccFullName = string.Empty;
        private string PicFinance = string.Empty;
        private string PicFinanceEmail = string.Empty;
        private string PicFinanceFullName = string.Empty;
        private string ApproveRejectRemarkContentTypeID = string.Empty;
        private string ToDoTaskContentTypeID = string.Empty;
        private string WFNameID = string.Empty;
        private string ApprovalStatus = string.Empty;
        private string ApprovedRejectedMailTemplate;
        private string EmailNotificationTemplate = string.Empty;
        private string EmailNotificationOriginatorTemplate = string.Empty;
        private string AdministratorGroup = string.Empty;
        private string VisitorGroup = string.Empty;
        private string Remarks = string.Empty;
        private string Subject = string.Empty;
        private string BodyMessage = string.Empty;
        private bool IsPerubahanNama = false;
        private bool IsPerubahanModal = false;

        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            module = "Perubahan Anggaran Dasar Dan Data Perseroan";
            workflowId = workflowProperties.WorkflowId;
            SPWeb web = workflowProperties.Web;

            ApproveRejectRemarkContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ApproveRejectRemark");
            ToDoTaskContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ToDoTask");
            WFNameID = Util.GetSettingValue(web, "Workflow Name", "Perubahan Anggaran Dasar Dan Data Perseroan");
            ApprovedRejectedMailTemplate = Util.GetSettingValue(web, "Email", "ApprovedRejectedMail");
            EmailNotificationTemplate = Util.GetSettingValue(web, "Email", "EmailNotifaction");
            EmailNotificationOriginatorTemplate = Util.GetSettingValue(web, "Email", "EmailNotificationOrginator");
            AdministratorGroup = Util.GetSettingValue(web, "SharePoint Group", "Administrator");
            VisitorGroup = Util.GetSettingValue(web, "SharePoint Group", "Visitor");

            /*PicCorsec*/
            PicCorsec =  new SPFieldUserValue(workflowProperties.Web,workflowProperties.Item["Author"].ToString()).User.LoginName; 
            PicCorsecEmail = workflowProperties.OriginatorEmail;
            PicCorsecFullName = workflowProperties.OriginatorUser.Name;

            /*PicChief*/
            PicDivHeadCorsec = Util.GetApproval(web, Roles.DIV_HEAD_CORSEC);
            PicDivHeadEmail = string.Empty;
            PicDivHeadFullName = string.Empty;

            IsPerubahanNama = false;
            IsPerubahanModal = false;
        }

        private void CollectedApproval_ExecuteCode(object sender, EventArgs e)
        {
            createMultipleTask1___Context1.Initialize(workflowProperties);
            createMultipleTask1_AssignedTo1 = PicDivHeadCorsec;
            createMultipleTask1_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createMultipleTask1_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createMultipleTask1_WFName1 = WFNameID;
            createMultipleTask1_Subject1 = string.Format("{0} [ {1} ] Need Approval", CodeName, workflowProperties.Item["Title"].ToString());
            createMultipleTask1_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Perubahan Anggaran Dasar Dan Data Perseroan Task", workflowProperties.Item.Title, PicCorsec, "need your approval", "{1}");

            UpdateItem(Roles.DIV_HEAD_CORSEC, string.Empty, StepWF[1], 2);
        }

        private void SetPermissionToChiefCorsec_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicDivHeadCorsec, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicCorsec, "Read");
        }

        public WorkflowContext createMultipleTask1___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTask1_AssignedTo1 = default(System.String);
        public String createMultipleTask1_Body1 = default(System.String);
        public String createMultipleTask1_ContentTypeId1 = default(System.String);
        public String createMultipleTask1_Subject1 = default(System.String);
        public Int32 createMultipleTask1_ListItemId1 = default(System.Int32);
        public String createMultipleTask1_TaskTitle1 = default(System.String);
        public String createMultipleTask1_WFName1 = default(System.String);

        private void UpdateItem(string Role, string ApprovalStatus)
        {
            SPListItem item = workflowProperties.Item;
            item["Status"] = Role;
            item["ApprovalStatus"] = ApprovalStatus;
            item.Update();
        }

        private void UpdateItem(string Role, string ApprovalStatus, string Step, int StepNumber)
        {
            SPListItem item = workflowProperties.Item;
            item["Status"] = Role + " " + Step;
            item["Step"] = Step;
            item["StepNumber"] = StepNumber;
            item["ApprovalStatus"] = ApprovalStatus;
            item.Update();
        }

        private string GetNamaPerusahaan(int id)
        {
            SPWeb web = workflowProperties.Web;
            SPList list = web.GetList(web.Url + "/Lists/PerusahaanBaru");
            SPListItem item = list.GetItemById(id);
            return (item["NamaPerusahaan"] != null ? item["NamaPerusahaan"].ToString() : string.Empty);
        }

        public SPWorkflowTaskProperties updateAllTasksChiefCorsec_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void updateAllTasksChiefCorsec_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasksChiefCorsec_TaskProperties1.PercentComplete = 1;
            updateAllTasksChiefCorsec_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetChiefCorsecStatus_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createMultipleTask1_ListItemId1);
            ApprovalStatus = item["ApproveOrReject"].ToString();
            PicDivHeadCorsec = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());

            if (item["Remarks"] != null)
                Remarks = item["Remarks"].ToString();
            else
                Remarks = string.Empty;

            if (ApprovalStatus == "Approve")
                UpdateDeptHead(userValue.User.ID);
        }

        private void UpdateDeptHead(int UserID)
        {
            SPListItem item = workflowProperties.Item;
            if (UserID == 0)
                item["DivHead"] = null;
            else
                item["DivHead"] = UserID;
            item.Update();
        }

        private void ApprovedCondition(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus == "Approve")
                e.Result = true;
        }

        private void UpdatePermissionRejected_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicCorsec, "Contribute");
        }

        public String sendEmailToOriginator_Body1 = default(System.String);
        public System.Collections.Specialized.StringDictionary sendEmailToOriginator_Headers1 = new System.Collections.Specialized.StringDictionary();

        private void sendEmailToOriginator_MethodInvoking(object sender, EventArgs e)
        {
            UpdateItem(string.Empty, "Rejected");
            UpdateDeptHead(0);

            string URL = string.Format("{0}/Lists/PerubahanAnggaranDasarDanDataPerseroan/EditForm.aspx?ID={1}", workflowProperties.SiteUrl, workflowProperties.Item.ID);
            Subject = string.Format("{0} [ {1} ] Rejected", CodeName, workflowProperties.Item["Title"].ToString());

            BodyMessage = string.Format(ApprovedRejectedMailTemplate, PicCorsecFullName, "Perubahan Anggaran Dasar Dan Data Perseroan", workflowProperties.Item.Title, "has been rejected by " + PicDivHeadFullName + "<br/><br/>Remarks: " + Remarks, URL);

            sendEmailToOriginator_Headers1.Add("To", PicCorsecEmail);
            sendEmailToOriginator_Headers1.Add("Subject", Subject);
            sendEmailToOriginator_Body1 = BodyMessage;
        }

        private void PopulateDataOriginator_ExecuteCode(object sender, EventArgs e)
        {
            createMultipleTask_PicCorsec___Context1.Initialize(workflowProperties);
            createMultipleTask_PicCorsec_AssignedTo1 = PicCorsec;
            createMultipleTask_PicCorsec_ContentTypeId1 = ToDoTaskContentTypeID;
            createMultipleTask_PicCorsec_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createMultipleTask_PicCorsec_WFName1 = WFNameID;
            createMultipleTask_PicCorsec_Subject1 = string.Format("{0} [ {1} ] Need to Upload Document and Update Data", CodeName, workflowProperties.Item["Title"].ToString());
            createMultipleTask_PicCorsec_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", module + " Task", workflowProperties.Item.Title, "need you to upload document and update data", "{1}");

            UpdateItem(Roles.PIC_CORSEC, string.Empty, StepWF[2], 3);
        }

        private void UpdatePermissionOriginator_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicCorsec, "Contribute");
        }

        public WorkflowContext createMultipleTask_PicCorsec___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTask_PicCorsec_AssignedTo1 = default(System.String);
        public String createMultipleTask_PicCorsec_Body1 = default(System.String);
        public String createMultipleTask_PicCorsec_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTask_PicCorsec_ListItemId1 = default(System.Int32);
        public String createMultipleTask_PicCorsec_Subject1 = default(System.String);
        public String createMultipleTask_PicCorsec_TaskTitle1 = default(System.String);
        public String createMultipleTask_PicCorsec_WFName1 = default(System.String);

        private void updateAllTasks1_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasks_PicCorsec_TaskProperties1.PercentComplete = 1;
            updateAllTasks_PicCorsec_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        public SPWorkflowTaskProperties updateAllTasks_PicCorsec_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void ApprovedCondition1(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus == "Approve")
                e.Result = true;
        }

        private void PopulateDataTax_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            createMultipleTask_Tax___Context1.Initialize(workflowProperties);
            createMultipleTask_Tax_AssignedTo1 = PicCorsec;
            createMultipleTask_Tax_ContentTypeId1 = ToDoTaskContentTypeID;
            createMultipleTask_Tax_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createMultipleTask_Tax_WFName1 = WFNameID;
            createMultipleTask_Tax_Subject1 = string.Format("{0} [ {1} ] Need to Upload Document and Update Data", CodeName, workflowProperties.Item["Title"].ToString());
            createMultipleTask_Tax_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", module + " Task", workflowProperties.Item.Title, "need you to upload document and update data", "{1}");

            UpdateItem(Roles.PIC_CORSEC, string.Empty, StepWF[3], 4);
        }

        private void UpdatePermissionTax_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicCorsec, "Contribute");
        }

        public WorkflowContext createMultipleTask_Tax___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTask_Tax_AssignedTo1 = default(System.String);
        public String createMultipleTask_Tax_Body1 = default(System.String);
        public String createMultipleTask_Tax_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTask_Tax_ListItemId1 = default(System.Int32);
        public String createMultipleTask_Tax_Subject1 = default(System.String);
        public String createMultipleTask_Tax_TaskTitle1 = default(System.String);
        public String createMultipleTask_Tax_WFName1 = default(System.String);
        public SPWorkflowTaskProperties updateAllTasks_Tax_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void updateAllTasks_Tax_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasks_Tax_TaskProperties1.PercentComplete = 1;
            updateAllTasks_Tax_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void PopulateDataOriginator1_ExecuteCode(object sender, EventArgs e)
        {
            /*PicTax*/
            PicTax = Util.GetApproval(workflowProperties.Web, Roles.TAX);
            PicTaxEmail = string.Empty;
            PicTaxFullName = string.Empty;

            createMultipleTask_PicCorsec1___Context1.Initialize(workflowProperties);
            createMultipleTask_PicCorsec1_AssignedTo1 = PicTax;
            createMultipleTask_PicCorsec1_ContentTypeId1 = ToDoTaskContentTypeID;
            createMultipleTask_PicCorsec1_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createMultipleTask_PicCorsec1_WFName1 = WFNameID;
            createMultipleTask_PicCorsec1_Subject1 = string.Format("{0} [ {1} ] Need to Upload Document and Update Data", CodeName, workflowProperties.Item["Title"].ToString());
            createMultipleTask_PicCorsec1_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", module + " Task", workflowProperties.Item.Title, "need you to upload document and update data", "{1}");

            UpdateItem(Roles.TAX, string.Empty, StepWF[4], 5);
        }

        private void UpdatePermissionOriginator1_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicTax, "Contribute");
        }

        public WorkflowContext createMultipleTask_PicCorsec1___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTask_PicCorsec1_AssignedTo1 = default(System.String);
        public String createMultipleTask_PicCorsec1_Body1 = default(System.String);
        public String createMultipleTask_PicCorsec1_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTask_PicCorsec1_ListItemId1 = default(System.Int32);
        public String createMultipleTask_PicCorsec1_Subject1 = default(System.String);
        public String createMultipleTask_PicCorsec1_TaskTitle1 = default(System.String);
        public String createMultipleTask_PicCorsec1_WFName1 = default(System.String);
        public SPWorkflowTaskProperties updateAllTasks_PicCorsec1_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void updateAllTasks_PicCorsec1_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasks_PicCorsec1_TaskProperties1.PercentComplete = 1;
            updateAllTasks_PicCorsec1_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        public WorkflowContext createMultipleTask_PicCorsec3___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTask_PicCorsec3_AssignedTo1 = default(System.String);
        public String createMultipleTask_PicCorsec3_Body1 = default(System.String);
        public String createMultipleTask_PicCorsec3_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTask_PicCorsec3_ListItemId1 = default(System.Int32);
        public String createMultipleTask_PicCorsec3_Subject1 = default(System.String);
        public String createMultipleTask_PicCorsec3_TaskTitle1 = default(System.String);
        public String createMultipleTask_PicCorsec3_WFName1 = default(System.String);

        private void PopulateData_PicCorsec3_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;
            PicAcc = Util.GetApproval(web, Roles.ACCOUNTING);
            PicAccEmail = string.Empty;
            PicAccFullName = string.Empty;

            createMultipleTask_PicCorsec3___Context1.Initialize(workflowProperties);
            createMultipleTask_PicCorsec3_AssignedTo1 = PicAcc;
            createMultipleTask_PicCorsec3_ContentTypeId1 = ToDoTaskContentTypeID;
            createMultipleTask_PicCorsec3_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createMultipleTask_PicCorsec3_WFName1 = WFNameID;
            createMultipleTask_PicCorsec3_Subject1 = string.Format("{0} [ {1} ] Need to Upload Document and Update Data", CodeName, workflowProperties.Item["Title"].ToString());
            createMultipleTask_PicCorsec3_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", module + " Task", workflowProperties.Item.Title, "need you to upload document and update data", "{1}");

            UpdateItem(Roles.ACCOUNTING, string.Empty, StepWF[5], 6);
        }

        private void SetPermissionPicCorsec3_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicAcc, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllTasksPicCorsec3_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void updateAllTasksPicCorsec3_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasksPicCorsec3_TaskProperties1.PercentComplete = 1;
            updateAllTasksPicCorsec3_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void UpdatePermissionCompleted_ExecuteCode(object sender, EventArgs e)
        {
            UpdateItem(string.Empty,"Approved");
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicCorsec, "Contribute");
            Util.UpdateGroupPermission(workflowProperties.Web, false, workflowProperties.Item, VisitorGroup, "Read");

        }

        public String logToHistoryListActivity2_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity2_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity2_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity2_HistoryOutcome1 = workflowProperties.Item["Title"].ToString();
            logToHistoryListActivity2_HistoryOutcome1 = IsPerubahanNama.ToString();
        }

        public String logToHistoryListActivity1_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity1_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity1_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity1_HistoryDescription1 = workflowProperties.Item["Title"].ToString();
            logToHistoryListActivity1_HistoryOutcome1 = IsPerubahanNama.ToString();
        }

        public String logToHistoryListActivity4_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity4_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity4_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity4_HistoryDescription1 = workflowProperties.Item["Title"].ToString();
            logToHistoryListActivity4_HistoryOutcome1 = IsPerubahanModal.ToString();
        }

        public String logToHistoryListActivity3_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity3_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity3_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity3_HistoryDescription1 = workflowProperties.Item["Title"].ToString();
            logToHistoryListActivity3_HistoryOutcome1 = IsPerubahanModal.ToString();
        }

        private void PopulateDataPicFinance_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;
            PicFinance = Util.GetApproval(web, Roles.FINANCE);
            PicFinanceEmail = string.Empty;
            PicFinanceFullName = string.Empty;

            createMultipleTask_PicFinance___Context1.Initialize(workflowProperties);
            createMultipleTask_PicFinance_AssignedTo1 = PicFinance;
            createMultipleTask_PicFinance_ContentTypeId1 = ToDoTaskContentTypeID;
            createMultipleTask_PicFinance_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createMultipleTask_PicFinance_WFName1 = WFNameID;
            createMultipleTask_PicFinance_Subject1 = string.Format("{0} [ {1} ] Need to Upload Document and Update Data", CodeName, workflowProperties.Item["Title"].ToString());
            createMultipleTask_PicFinance_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", module + " Task", workflowProperties.Item.Title, "need you to upload document and update data", "{1}");

            UpdateItem(Roles.FINANCE, string.Empty, StepWF[6], 7);
        }

        public String createMultipleTask_PicFinance_AssignedTo1 = default(System.String);
        public String createMultipleTask_PicFinance_Body1 = default(System.String);
        public String createMultipleTask_PicFinance_ContentTypeId1 = default(System.String);
        public String createMultipleTask_PicFinance_Subject1 = default(System.String);
        public String createMultipleTask_PicFinance_TaskTitle1 = default(System.String);
        public String createMultipleTask_PicFinance_WFName1 = default(System.String);
        public Int32 createMultipleTask_PicFinance_ListItemId1 = default(System.Int32);
        public WorkflowContext createMultipleTask_PicFinance___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();

        private void SetPermissionPicFinance_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicFinance, "Contribute");
        }

        private void PopulateDataPicCorsecLast_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Web;
            createMultipleTask_PicCorsec4___Context1.Initialize(workflowProperties);
            createMultipleTask_PicCorsec4_AssignedTo1 = PicCorsec;
            createMultipleTask_PicCorsec4_ContentTypeId1 = ToDoTaskContentTypeID;
            createMultipleTask_PicCorsec4_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createMultipleTask_PicCorsec4_WFName1 = WFNameID;
            createMultipleTask_PicCorsec4_Subject1 = string.Format("{0} [ {1} ] Need to Upload Document and Update Data", CodeName, workflowProperties.Item["Title"].ToString());
            createMultipleTask_PicCorsec4_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", module + " Task", workflowProperties.Item.Title, "need you to upload document and update data", "{1}");

            UpdateItem(Roles.PIC_CORSEC, string.Empty, StepWF[7], 8);
        }

        private void SetPermissionPicCorsecLast_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, PicCorsec, "Contribute");
        }

        public WorkflowContext createMultipleTask_PicCorsec4___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTask_PicCorsec4_AssignedTo1 = default(System.String);
        public String createMultipleTask_PicCorsec4_Body1 = default(System.String);
        public String createMultipleTask_PicCorsec4_ContentTypeId1 = default(System.String);
        public String createMultipleTask_PicCorsec4_Subject1 = default(System.String);
        public String createMultipleTask_PicCorsec4_TaskTitle1 = default(System.String);
        public String createMultipleTask_PicCorsec4_WFName1 = default(System.String);
        public SPWorkflowTaskProperties updateAllTasksPicFinance_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void updateAllTasksPicFinance_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasksPicFinance_TaskProperties1.PercentComplete = 1;
            updateAllTasksPicFinance_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        public SPWorkflowTaskProperties updateAllTasksPicCorsec4_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void updateAllTasksPicCorsec4_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasksPicCorsec4_TaskProperties1.PercentComplete = 1;
            updateAllTasksPicCorsec4_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetPerubahanNamaDanModal_ExecuteCode(object sender, EventArgs e)
        {
            IsPerubahanNama = Convert.ToBoolean(workflowProperties.Item["PerubahanNamaDanTempat"]);
            IsPerubahanModal = Convert.ToBoolean(workflowProperties.Item["PerubahanModal"]); ;
        }

    }
}
