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

namespace SPVisionet.CorporateSecretary.Workflow.PendirianPerusahaanBaruForeign
{
    public sealed partial class PendirianPerusahaanBaruForeign : SequentialWorkflowActivity
    {
        private string ApproveRejectRemarkContentTypeID = string.Empty;
        private string ToDoTaskContentTypeID = string.Empty;
        private string WFNameID = string.Empty;
        private string ApprovalStatus = string.Empty;
        private string Remarks = string.Empty;
        private string OriginatorEmail = string.Empty;
        private string OriginatorName = string.Empty;
        private string ChiefCorsecLoginName = string.Empty;
        private string ChiefCorsecName = string.Empty;
        private string ApprovedRejectedMailTemplate = string.Empty;
        private string EmailNotificationTemplate = string.Empty;
        private string EmailNotificationOriginatorTemplate = string.Empty;
        private string Subject = string.Empty;
        private string BodyMessage = string.Empty;
        private string AdministratorGroup = string.Empty;
        private string VisitorGroup = string.Empty;
        private StringCollection scInfo = new StringCollection();

        public PendirianPerusahaanBaruForeign()
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

        private void UpdatePerson(int? ChiefCorsecID)
        {
            SPListItem item = workflowProperties.Item;
            if (ChiefCorsecID == null)
                item["ChiefCorsec"] = null;
            else
            {
                if (ChiefCorsecID != 0)
                    item["ChiefCorsec"] = ChiefCorsecID;
            }
            item.Update();
        }

        private void ApprovedCondition(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus == "Approve")
                e.Result = true;
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            workflowId = workflowProperties.WorkflowId;
            SPWeb web = workflowProperties.Web;

            ApproveRejectRemarkContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ApproveRejectRemark");
            ToDoTaskContentTypeID = Util.GetSettingValue(web, "ContentTypeID", "ToDoTask");
            WFNameID = Util.GetSettingValue(web, "Workflow Name", "Pendirian Perusahaan Baru (Foreign)");
            ApprovedRejectedMailTemplate = Util.GetSettingValue(web, "Email", "ApprovedRejectedMail");
            EmailNotificationTemplate = Util.GetSettingValue(web, "Email", "EmailNotifaction");
            EmailNotificationOriginatorTemplate = Util.GetSettingValue(web, "Email", "EmailNotificationOrginator");
            AdministratorGroup = Util.GetSettingValue(web, "SharePoint Group", "Administrator");
            VisitorGroup = Util.GetSettingValue(web, "SharePoint Group", "Visitor");

            OriginatorName = workflowProperties.OriginatorUser.Name;
            OriginatorEmail = workflowProperties.OriginatorUser.Email;

            ChiefCorsecLoginName = Util.GetApproval(web, Roles.CHIEF_CORSEC);

            scInfo.Add(string.Format("{0};{1};{2};{3}", "1", OriginatorName, DateTime.Now, "Request"));
        }

        #region Chief Corsec

        public WorkflowContext createChiefCorsecTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createChiefCorsecTask_AssignedTo1 = default(System.String);
        public String createChiefCorsecTask_Body1 = default(System.String);
        public String createChiefCorsecTask_ContentTypeId1 = default(System.String);
        public Int32 createChiefCorsecTask_ListItemId1 = default(System.Int32);
        public String createChiefCorsecTask_Subject1 = default(System.String);
        public String createChiefCorsecTask_TaskTitle1 = default(System.String);
        public String createChiefCorsecTask_WFName1 = default(System.String);
        private void PopulateChiefCorsecData_ExecuteCode(object sender, EventArgs e)
        {
            createChiefCorsecTask___Context1.Initialize(workflowProperties);
            createChiefCorsecTask_AssignedTo1 = ChiefCorsecLoginName;
            createChiefCorsecTask_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createChiefCorsecTask_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createChiefCorsecTask_WFName1 = WFNameID;
            createChiefCorsecTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_FOREIGN, workflowProperties.Item["CompanyName"].ToString());
            createChiefCorsecTask_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Pendirian Perusahaan Baru (Foreign) Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.CHIEF_CORSEC, string.Empty);
        }

        private void UpdatePermissionChiefCorsec_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllChiefCorsecTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllChiefCorsecTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllChiefCorsecTasks_TaskProperties1.PercentComplete = 1;
            updateAllChiefCorsecTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetApproval_ExecuteCode(object sender, EventArgs e)
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

            if (ApprovalStatus == "Approve")
                UpdatePerson(userValue.User.ID);

            scInfo.Add(string.Format("{0};{1};{2};{3}", "2", ChiefCorsecName, DateTime.Now, ApprovalStatus));
        }

        #endregion

        #region PIC Corsec

        public WorkflowContext createPICCorsecTask___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createPICCorsecTask_AssignedTo1 = default(System.String);
        public String createPICCorsecTask_Body1 = default(System.String);
        public String createPICCorsecTask_ContentTypeId1 = default(System.String);
        public Int32 createPICCorsecTask_ListItemId1 = default(System.Int32);
        public String createPICCorsecTask_Subject1 = default(System.String);
        public String createPICCorsecTask_TaskTitle1 = default(System.String);
        public String createPICCorsecTask_WFName1 = default(System.String);
        private void PopulatePICCorsecData_ExecuteCode(object sender, EventArgs e)
        {
            createPICCorsecTask___Context1.Initialize(workflowProperties);
            createPICCorsecTask_AssignedTo1 = workflowProperties.Originator;
            createPICCorsecTask_ContentTypeId1 = ToDoTaskContentTypeID;
            createPICCorsecTask_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createPICCorsecTask_WFName1 = WFNameID;
            createPICCorsecTask_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_FOREIGN, workflowProperties.Item["CompanyName"].ToString());
            createPICCorsecTask_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Pendirian Perusahaan Baru (Foreign) Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.PIC_CORSEC, string.Empty);
        }

        private void UpdatePermissionPICCorsec_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllPICCorsecTasks_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllPICCorsecTasks_MethodInvoking(object sender, EventArgs e)
        {
            updateAllPICCorsecTasks_TaskProperties1.PercentComplete = 1;
            updateAllPICCorsecTasks_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        #endregion

        #region Approve

        private void UpdatePermissionApprove_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateGroupPermission(workflowProperties.Web, false, workflowProperties.Item, VisitorGroup, "Read");
        }

        private void SendEmailApprove_ExecuteCode(object sender, EventArgs e)
        {
            scInfo.Add(string.Format("{0};{1};{2};{3}", "3", OriginatorName, DateTime.Now, "Complete"));
            UpdateItem(string.Empty, "Approved");

            string URL = string.Format("{0}/Lists/PendirianPerusahaanBaruForeign/DispForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] is already Completed", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_FOREIGN, workflowProperties.Item["CompanyName"].ToString());

            string[] splitChiefCorsec = ChiefCorsecLoginName.Split(';');
            foreach (string item in splitChiefCorsec)
            {
                SPUser userCorsec = workflowProperties.Web.Users[item];
                BodyMessage = string.Format(ApprovedRejectedMailTemplate, userCorsec.Name, "Pendirian Perusahaan Baru (Foreign)", workflowProperties.Item.Title, "has been uploaded document and updated data by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                SPUtility.SendEmail(workflowProperties.Web, false, false, userCorsec.Email, Subject, BodyMessage);
            }
        }

        #endregion

        #region Reject

        private void UpdatePermissionReject_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public StringDictionary sendEmailRejected_Headers1 = new System.Collections.Specialized.StringDictionary();
        public String sendEmailRejected_Body1 = default(System.String);
        private void sendEmailRejected_MethodInvoking(object sender, EventArgs e)
        {
            UpdateItem(string.Empty, "Rejected");
            UpdatePerson(null);

            string RejectedName = ChiefCorsecName;
            string URL = string.Format("{0}/Lists/PendirianPerusahaanBaruForeign/EditForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] Rejected", RequestCode.PERMOHONAN_PENDIRIAN_PERUSAHAAN_FOREIGN, workflowProperties.Item["CompanyName"].ToString());

            BodyMessage = string.Format(ApprovedRejectedMailTemplate, OriginatorName, "Pendirian Perusahaan Baru (Foreign)", workflowProperties.Item.Title, "has been rejected by " + RejectedName + Util.GenerateApprovalInformation(scInfo) + "<br/><br/>Remarks: " + Remarks, URL);

            sendEmailRejected_Headers1.Add("To", OriginatorEmail);
            sendEmailRejected_Headers1.Add("Subject", Subject);
            sendEmailRejected_Body1 = BodyMessage;
        }

        #endregion
    }
}
