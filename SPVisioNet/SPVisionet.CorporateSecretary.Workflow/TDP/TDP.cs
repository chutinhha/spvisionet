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
using System.Collections.Specialized;

namespace SPVisionet.CorporateSecretary.Workflow.TDP
{
    public sealed partial class TDP : SequentialWorkflowActivity
    {
        private string ApproveRejectRemarkContentTypeID = string.Empty;
        private string ToDoTaskContentTypeID = string.Empty;
        private string WFNameID = string.Empty;
        private string ApprovalStatus = string.Empty;
        private string Remarks = string.Empty;
        private string OriginatorEmail = string.Empty;
        private string OriginatorName = string.Empty;
        private string DivHeadLoginName = string.Empty;
        //private string DivHeadEmail = string.Empty;
        private string DivHeadName = string.Empty;
        private string ApprovedRejectedMailTemplate = string.Empty;
        private string EmailNotificationTemplate = string.Empty;
        private string EmailNotificationOriginatorTemplate = string.Empty;
        private string Subject = string.Empty;
        private string BodyMessage = string.Empty;
        private string AdministratorGroup = string.Empty;
        private string VisitorGroup = string.Empty;
        private StringCollection scInfo = new StringCollection();

        public TDP()
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

        private void UpdateDeptHead(int UserID)
        {
            SPListItem item = workflowProperties.Item;
            if (UserID == 0)
                item["DivHead"] = null;
            else
                item["DivHead"] = UserID;
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
            WFNameID = Util.GetSettingValue(web, "Workflow Name", "TDP");
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

        public WorkflowContext createMultipleTaskDeptHead___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTaskDeptHead_AssignedTo1 = default(System.String);
        public String createMultipleTaskDeptHead_Body1 = default(System.String);
        public String createMultipleTaskDeptHead_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTaskDeptHead_ListItemId1 = default(System.Int32);
        public String createMultipleTaskDeptHead_Subject1 = default(System.String);
        public String createMultipleTaskDeptHead_TaskTitle1 = default(System.String);
        public String createMultipleTaskDeptHead_WFName1 = default(System.String);
        private void PopulateDeptHead_ExecuteCode(object sender, EventArgs e)
        {
            createMultipleTaskDeptHead___Context1.Initialize(workflowProperties);
            createMultipleTaskDeptHead_AssignedTo1 = DivHeadLoginName;
            createMultipleTaskDeptHead_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createMultipleTaskDeptHead_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createMultipleTaskDeptHead_WFName1 = WFNameID;
            createMultipleTaskDeptHead_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.TDP, workflowProperties.Item["NamaPerusahaan"].ToString());
            createMultipleTaskDeptHead_Body1 = string.Format(EmailNotificationTemplate, "{0}", "TDP Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.DIV_HEAD_CORSEC, string.Empty);
        }

        private void UpdatePermissionDeptHead_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllTasksDeptHead_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllTasksDeptHead_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasksDeptHead_TaskProperties1.PercentComplete = 1;
            updateAllTasksDeptHead_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetDeptHeadApprovalStatus_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createMultipleTaskDeptHead_ListItemId1);
            ApprovalStatus = item["ApproveOrReject"].ToString();
            DivHeadName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            //DivHeadEmail = userValue.User.Email;

            if (item["Remarks"] != null)
                Remarks = item["Remarks"].ToString();
            else
                Remarks = string.Empty;

            if (ApprovalStatus == "Approve")
                UpdateDeptHead(userValue.User.ID);

            scInfo.Add(string.Format("{0};{1};{2};{3}", "2", DivHeadName, DateTime.Now, ApprovalStatus));
        }

        private void ApprovedCondition(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus == "Approve")
                e.Result = true;
        }

        public System.Collections.Specialized.StringDictionary sendEmailOriginator_Headers1 = new System.Collections.Specialized.StringDictionary();
        public String sendEmailOriginator_Body1 = default(System.String);
        private void sendEmailOriginator_MethodInvoking(object sender, EventArgs e)
        {
            UpdateItem(string.Empty, "Rejected");
            UpdateDeptHead(0);

            string URL = string.Format("{0}/Lists/TDP/EditForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] Rejected", RequestCode.TDP, workflowProperties.Item["NamaPerusahaan"].ToString());

            BodyMessage = string.Format(ApprovedRejectedMailTemplate, OriginatorName, "TDP", workflowProperties.Item.Title, "has been rejected by " + DivHeadName + Util.GenerateApprovalInformation(scInfo) + "<br/><br/>Remarks: " + Remarks, URL);

            sendEmailOriginator_Headers1.Add("To", OriginatorEmail);
            sendEmailOriginator_Headers1.Add("Subject", Subject);
            sendEmailOriginator_Body1 = BodyMessage;
        }

        private void UpdatePermissionRejected_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public WorkflowContext createMultipleTaskOriginator___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTaskOriginator_AssignedTo1 = default(System.String);
        public String createMultipleTaskOriginator_Body1 = default(System.String);
        public String createMultipleTaskOriginator_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTaskOriginator_ListItemId1 = default(System.Int32);
        public String createMultipleTaskOriginator_Subject1 = default(System.String);
        public String createMultipleTaskOriginator_TaskTitle1 = default(System.String);
        public String createMultipleTaskOriginator_WFName1 = default(System.String);
        private void PopulateDataOriginator_ExecuteCode(object sender, EventArgs e)
        {
            createMultipleTaskOriginator___Context1.Initialize(workflowProperties);
            createMultipleTaskOriginator_AssignedTo1 = workflowProperties.Originator;
            createMultipleTaskOriginator_ContentTypeId1 = ToDoTaskContentTypeID;
            createMultipleTaskOriginator_TaskTitle1 = "Need to Upload Document and Update Data for " + workflowProperties.Item.Title;
            createMultipleTaskOriginator_WFName1 = WFNameID;
            createMultipleTaskOriginator_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data", RequestCode.TDP, workflowProperties.Item["NamaPerusahaan"].ToString());
            createMultipleTaskOriginator_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "TDP Task", workflowProperties.Item.Title, "need you to upload document and update data" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.PIC_CORSEC, string.Empty);
        }

        private void UpdatePermissionOriginator_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public SPWorkflowTaskProperties updateAllTasksOriginator_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllTasksOriginator_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasksOriginator_TaskProperties1.PercentComplete = 1;
            updateAllTasksOriginator_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void UpdatePermissionApproved_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateGroupPermission(workflowProperties.Web, false, workflowProperties.Item, VisitorGroup, "Read");
        }

        private void SendMailDeptHead_ExecuteCode(object sender, EventArgs e)
        {
            scInfo.Add(string.Format("{0};{1};{2};{3}", "4", OriginatorName, DateTime.Now, "Complete"));
            UpdateItem(string.Empty, "Approved");

            string URL = string.Format("{0}/Lists/TDP/DispForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] is already Completed", RequestCode.TDP, workflowProperties.Item["NamaPerusahaan"].ToString());

            string[] splitDivHead = DivHeadLoginName.Split(';');
            foreach (string item in splitDivHead)
            {
                SPUser userDivHead = workflowProperties.Web.Users[item];
                BodyMessage = string.Format(ApprovedRejectedMailTemplate, userDivHead.Name, "TDP", workflowProperties.Item.Title, "has been uploaded document and updated data by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                SPUtility.SendEmail(workflowProperties.Web, false, false, userDivHead.Email, Subject, BodyMessage);
            }
        }
    }
}
