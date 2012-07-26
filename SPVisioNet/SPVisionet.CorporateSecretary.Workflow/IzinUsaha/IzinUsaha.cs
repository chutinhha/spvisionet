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

namespace SPVisionet.CorporateSecretary.Workflow.IzinUsaha
{
    public sealed partial class IzinUsaha : SequentialWorkflowActivity
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
        private string ApprovedRejectedMailTemplate = string.Empty;
        private string EmailNotificationTemplate = string.Empty;
        private string EmailNotificationOriginatorTemplate = string.Empty;
        private string Subject = string.Empty;
        private string BodyMessage = string.Empty;
        private string AdministratorGroup = string.Empty;
        private string VisitorGroup = string.Empty;
        private StringCollection scInfo = new StringCollection();

        public IzinUsaha()
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

        private void UpdatePerson(int? DivHeadUserID, int? ChiefCorsecID)
        {
            SPListItem item = workflowProperties.Item;
            if (DivHeadUserID == null)
                item["DivHead"] = null;
            else
            {
                if (DivHeadUserID != 0)
                    item["DivHead"] = DivHeadUserID;
            }

            if (ChiefCorsecID == null)
                item["ChiefCorsec"] = null;
            else
            {
                if (ChiefCorsecID != 0)
                    item["ChiefCorsec"] = ChiefCorsecID;
            }
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
            WFNameID = Util.GetSettingValue(web, "Workflow Name", "Izin Usaha");
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

        public WorkflowContext createMultipleTask1___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTask1_AssignedTo1 = default(System.String);
        public String createMultipleTask1_Body1 = default(System.String);
        public String createMultipleTask1_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTask1_ListItemId1 = default(System.Int32);
        public String createMultipleTask1_Subject1 = default(System.String);
        public String createMultipleTask1_TaskTitle1 = default(System.String);
        public String createMultipleTask1_WFName1 = default(System.String);
        private void PopulateData_ExecuteCode(object sender, EventArgs e)
        {
            createMultipleTask1___Context1.Initialize(workflowProperties);
            createMultipleTask1_AssignedTo1 = DivHeadLoginName;
            createMultipleTask1_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createMultipleTask1_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createMultipleTask1_WFName1 = WFNameID;
            createMultipleTask1_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.IZIN_USAHA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createMultipleTask1_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Izin Usaha Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.DIV_HEAD_CORSEC, string.Empty);
        }

        private void UpdatePermission_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, DivHeadLoginName, "Read");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllTasks1_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllTasks1_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasks1_TaskProperties1.PercentComplete = 1;
            updateAllTasks1_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetApprovalStatus_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createMultipleTask1_ListItemId1);
            ApprovalStatus = item["ApproveOrReject"].ToString();

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            DivHeadName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (item["Remarks"] != null)
                Remarks = item["Remarks"].ToString();
            else
                Remarks = string.Empty;

            if (ApprovalStatus == "Approve")
                UpdatePerson(userValue.User.ID, 0);

            scInfo.Add(string.Format("{0};{1};{2};{3}", "2", DivHeadName, DateTime.Now, ApprovalStatus));
        }

        private void ApprovedCondition(object sender, ConditionalEventArgs e)
        {
            if (ApprovalStatus == "Approve")
                e.Result = true;
        }

        public WorkflowContext createMultipleTaskChiefCorsec___Context1 = new Microsoft.SharePoint.WorkflowActions.WorkflowContext();
        public String createMultipleTaskChiefCorsec_AssignedTo1 = default(System.String);
        public String createMultipleTaskChiefCorsec_Body1 = default(System.String);
        public String createMultipleTaskChiefCorsec_ContentTypeId1 = default(System.String);
        public Int32 createMultipleTaskChiefCorsec_ListItemId1 = default(System.Int32);
        public String createMultipleTaskChiefCorsec_Subject1 = default(System.String);
        public String createMultipleTaskChiefCorsec_TaskTitle1 = default(System.String);
        public String createMultipleTaskChiefCorsec_WFName1 = default(System.String);
        private void PopulateDataChiefCoresec_ExecuteCode(object sender, EventArgs e)
        {
            ApprovalStatus = string.Empty;

            SPWeb web = workflowProperties.Web;
            ChiefCorsecLoginName = Util.GetApproval(web, Roles.CHIEF_CORSEC);

            createMultipleTaskChiefCorsec___Context1.Initialize(workflowProperties);
            createMultipleTaskChiefCorsec_AssignedTo1 = ChiefCorsecLoginName;
            createMultipleTaskChiefCorsec_ContentTypeId1 = ApproveRejectRemarkContentTypeID;
            createMultipleTaskChiefCorsec_TaskTitle1 = "Need Approval for " + workflowProperties.Item.Title;
            createMultipleTaskChiefCorsec_WFName1 = WFNameID;
            createMultipleTaskChiefCorsec_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need Approval", RequestCode.IZIN_USAHA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createMultipleTaskChiefCorsec_Body1 = string.Format(EmailNotificationTemplate, "{0}", "Izin Usaha Task", workflowProperties.Item.Title, OriginatorName, "need your approval" + Util.GenerateApprovalInformation(scInfo), "{1}");

            UpdateItem(Roles.CHIEF_CORSEC, string.Empty);
        }

        private void UpdatePermissionCorsec_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, ChiefCorsecLoginName, "Read");
        }

        public SPWorkflowTaskProperties updateAllTasksChiefCorsec_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        private void updateAllTasksChiefCorsec_MethodInvoking(object sender, EventArgs e)
        {
            updateAllTasksChiefCorsec_TaskProperties1.PercentComplete = 1;
            updateAllTasksChiefCorsec_TaskProperties1.ExtendedProperties["Status"] = "Completed";
        }

        private void GetChiefCorsecApprovalStatus_ExecuteCode(object sender, EventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;

            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(createMultipleTaskChiefCorsec_ListItemId1);
            ApprovalStatus = item["ApproveOrReject"].ToString();

            SPFieldUser userField = item.Fields["Assigned To"] as SPFieldUser;
            SPFieldUserValue userValue = (SPFieldUserValue)userField.GetFieldValue(item["AssignedTo"].ToString());
            ChiefCorsecName = item["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];

            if (item["Remarks"] != null)
                Remarks = item["Remarks"].ToString();
            else
                Remarks = string.Empty;

            if (ApprovalStatus == "Approve")
                UpdatePerson(0, userValue.User.ID);

            scInfo.Add(string.Format("{0};{1};{2};{3}", "3", ChiefCorsecName, DateTime.Now, ApprovalStatus));
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
            createMultipleTaskOriginator_Subject1 = string.Format("CorsecSP {0} [ {1} ] Need to Upload Document and Update Data", RequestCode.IZIN_USAHA, workflowProperties.Item["NamaPerusahaan"].ToString());
            createMultipleTaskOriginator_Body1 = string.Format(EmailNotificationOriginatorTemplate, "{0}", "Izin Usaha Task", workflowProperties.Item.Title, "need you to upload document and update data" + Util.GenerateApprovalInformation(scInfo), "{1}");

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

        private void UpdatePermissionApprove_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateGroupPermission(workflowProperties.Web, false, workflowProperties.Item, VisitorGroup, "Read");
        }

        private void SendMailApprove_ExecuteCode(object sender, EventArgs e)
        {
            scInfo.Add(string.Format("{0};{1};{2};{3}", "4", OriginatorName, DateTime.Now, "Complete"));
            UpdateItem(string.Empty, "Approved");

            string URL = string.Format("{0}/Lists/IzinUsaha/DispForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] is already Completed", RequestCode.IZIN_USAHA, workflowProperties.Item["NamaPerusahaan"].ToString());

            string[] splitDivHead = DivHeadLoginName.Split(';');
            foreach (string item in splitDivHead)
            {
                SPUser userDivHead = workflowProperties.Web.Users[item];
                BodyMessage = string.Format(ApprovedRejectedMailTemplate, userDivHead.Name, "Izin Usaha", workflowProperties.Item.Title, "has been uploaded document and updated data by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                SPUtility.SendEmail(workflowProperties.Web, false, false, userDivHead.Email, Subject, BodyMessage);
            }

            string[] splitChiefCorsec = ChiefCorsecLoginName.Split(';');
            foreach (string item in splitChiefCorsec)
            {
                SPUser userCorsec = workflowProperties.Web.Users[item];
                BodyMessage = string.Format(ApprovedRejectedMailTemplate, userCorsec.Name, "Izin Usaha", workflowProperties.Item.Title, "has been uploaded document and updated data by " + OriginatorName + Util.GenerateApprovalInformation(scInfo), URL);
                SPUtility.SendEmail(workflowProperties.Web, false, false, userCorsec.Email, Subject, BodyMessage);
            }
        }

        private void UpdatePermissionReject_ExecuteCode(object sender, EventArgs e)
        {
            Util.UpdateGroupPermission(workflowProperties.Web, true, workflowProperties.Item, AdministratorGroup, "Contribute");
            Util.UpdateUserPermission(workflowProperties.Web, false, workflowProperties.Item, workflowProperties.OriginatorUser.LoginName, "Contribute");
        }

        public String sendEmailReject_Body1 = default(System.String);
        public System.Collections.Specialized.StringDictionary sendEmailReject_Headers1 = new System.Collections.Specialized.StringDictionary();
        private void sendEmailReject_MethodInvoking(object sender, EventArgs e)
        {
            UpdateItem(string.Empty, "Rejected");
            UpdatePerson(null, null);

            string RejectedName = ChiefCorsecName == string.Empty ? DivHeadName : ChiefCorsecName;
            string URL = string.Format("{0}/Lists/IzinUsaha/EditForm.aspx?ID={1}", workflowProperties.WebUrl, workflowProperties.Item.ID);
            Subject = string.Format("CorsecSP {0} [ {1} ] Rejected", RequestCode.IZIN_USAHA, workflowProperties.Item["NamaPerusahaan"].ToString());

            BodyMessage = string.Format(ApprovedRejectedMailTemplate, OriginatorName, "Izin Usaha", workflowProperties.Item.Title, "has been rejected by " + RejectedName + Util.GenerateApprovalInformation(scInfo) + "<br/><br/>Remarks: " + Remarks, URL);

            sendEmailReject_Headers1.Add("To", OriginatorEmail);
            sendEmailReject_Headers1.Add("Subject", Subject);
            sendEmailReject_Body1 = BodyMessage;
        }
    }
}
