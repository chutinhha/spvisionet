using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SPVisionet.CorporateSecretary.Workflow.SIUP
{
    public sealed partial class SIUP
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            this.sendEmailOriginator = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.UpdatePermissionRejected = new System.Workflow.Activities.CodeActivity();
            this.SendMailDeptHead = new System.Workflow.Activities.CodeActivity();
            this.UpdatePermissionApproved = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasksOriginator = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTaskOriginator = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionOriginator = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataOriginator = new System.Workflow.Activities.CodeActivity();
            this.Reject = new System.Workflow.Activities.IfElseBranchActivity();
            this.Approve = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.GetDeptHeadApprovalStatus = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasksDeptHead = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTaskDeptHead = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionDeptHead = new System.Workflow.Activities.CodeActivity();
            this.PopulateDeptHead = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // sendEmailOriginator
            // 
            this.sendEmailOriginator.BCC = null;
            activitybind1.Name = "SIUP";
            activitybind1.Path = "sendEmailOriginator_Body1";
            this.sendEmailOriginator.CC = null;
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "SIUP";
            this.sendEmailOriginator.CorrelationToken = correlationtoken1;
            this.sendEmailOriginator.From = null;
            activitybind2.Name = "SIUP";
            activitybind2.Path = "sendEmailOriginator_Headers1";
            this.sendEmailOriginator.IncludeStatus = false;
            this.sendEmailOriginator.Name = "sendEmailOriginator";
            this.sendEmailOriginator.Subject = null;
            this.sendEmailOriginator.To = null;
            this.sendEmailOriginator.MethodInvoking += new System.EventHandler(this.sendEmailOriginator_MethodInvoking);
            this.sendEmailOriginator.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.sendEmailOriginator.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // UpdatePermissionRejected
            // 
            this.UpdatePermissionRejected.Name = "UpdatePermissionRejected";
            this.UpdatePermissionRejected.ExecuteCode += new System.EventHandler(this.UpdatePermissionRejected_ExecuteCode);
            // 
            // SendMailDeptHead
            // 
            this.SendMailDeptHead.Name = "SendMailDeptHead";
            this.SendMailDeptHead.ExecuteCode += new System.EventHandler(this.SendMailDeptHead_ExecuteCode);
            // 
            // UpdatePermissionApproved
            // 
            this.UpdatePermissionApproved.Name = "UpdatePermissionApproved";
            this.UpdatePermissionApproved.ExecuteCode += new System.EventHandler(this.UpdatePermissionApproved_ExecuteCode);
            // 
            // updateAllTasksOriginator
            // 
            this.updateAllTasksOriginator.CorrelationToken = correlationtoken1;
            this.updateAllTasksOriginator.Name = "updateAllTasksOriginator";
            activitybind3.Name = "SIUP";
            activitybind3.Path = "updateAllTasksOriginator_TaskProperties1";
            this.updateAllTasksOriginator.MethodInvoking += new System.EventHandler(this.updateAllTasksOriginator_MethodInvoking);
            this.updateAllTasksOriginator.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // createMultipleTaskOriginator
            // 
            activitybind4.Name = "SIUP";
            activitybind4.Path = "createMultipleTaskOriginator___Context1";
            activitybind5.Name = "SIUP";
            activitybind5.Path = "createMultipleTaskOriginator_AssignedTo1";
            activitybind6.Name = "SIUP";
            activitybind6.Path = "createMultipleTaskOriginator_Body1";
            activitybind7.Name = "SIUP";
            activitybind7.Path = "createMultipleTaskOriginator_ContentTypeId1";
            activitybind8.Name = "SIUP";
            activitybind8.Path = "createMultipleTaskOriginator_ListItemId1";
            this.createMultipleTaskOriginator.Name = "createMultipleTaskOriginator";
            activitybind9.Name = "SIUP";
            activitybind9.Path = "createMultipleTaskOriginator_Subject1";
            activitybind10.Name = "SIUP";
            activitybind10.Path = "createMultipleTaskOriginator_TaskTitle1";
            activitybind11.Name = "SIUP";
            activitybind11.Path = "createMultipleTaskOriginator_WFName1";
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // UpdatePermissionOriginator
            // 
            this.UpdatePermissionOriginator.Name = "UpdatePermissionOriginator";
            this.UpdatePermissionOriginator.ExecuteCode += new System.EventHandler(this.UpdatePermissionOriginator_ExecuteCode);
            // 
            // PopulateDataOriginator
            // 
            this.PopulateDataOriginator.Name = "PopulateDataOriginator";
            this.PopulateDataOriginator.ExecuteCode += new System.EventHandler(this.PopulateDataOriginator_ExecuteCode);
            // 
            // Reject
            // 
            this.Reject.Activities.Add(this.UpdatePermissionRejected);
            this.Reject.Activities.Add(this.sendEmailOriginator);
            this.Reject.Name = "Reject";
            // 
            // Approve
            // 
            this.Approve.Activities.Add(this.PopulateDataOriginator);
            this.Approve.Activities.Add(this.UpdatePermissionOriginator);
            this.Approve.Activities.Add(this.createMultipleTaskOriginator);
            this.Approve.Activities.Add(this.updateAllTasksOriginator);
            this.Approve.Activities.Add(this.UpdatePermissionApproved);
            this.Approve.Activities.Add(this.SendMailDeptHead);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.Approve.Condition = codecondition1;
            this.Approve.Name = "Approve";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.Approve);
            this.ifElseActivity1.Activities.Add(this.Reject);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // GetDeptHeadApprovalStatus
            // 
            this.GetDeptHeadApprovalStatus.Name = "GetDeptHeadApprovalStatus";
            this.GetDeptHeadApprovalStatus.ExecuteCode += new System.EventHandler(this.GetDeptHeadApprovalStatus_ExecuteCode);
            // 
            // updateAllTasksDeptHead
            // 
            this.updateAllTasksDeptHead.CorrelationToken = correlationtoken1;
            this.updateAllTasksDeptHead.Name = "updateAllTasksDeptHead";
            activitybind12.Name = "SIUP";
            activitybind12.Path = "updateAllTasksDeptHead_TaskProperties1";
            this.updateAllTasksDeptHead.MethodInvoking += new System.EventHandler(this.updateAllTasksDeptHead_MethodInvoking);
            this.updateAllTasksDeptHead.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // createMultipleTaskDeptHead
            // 
            activitybind13.Name = "SIUP";
            activitybind13.Path = "createMultipleTaskDeptHead___Context1";
            activitybind14.Name = "SIUP";
            activitybind14.Path = "createMultipleTaskDeptHead_AssignedTo1";
            activitybind15.Name = "SIUP";
            activitybind15.Path = "createMultipleTaskDeptHead_Body1";
            activitybind16.Name = "SIUP";
            activitybind16.Path = "createMultipleTaskDeptHead_ContentTypeId1";
            activitybind17.Name = "SIUP";
            activitybind17.Path = "createMultipleTaskDeptHead_ListItemId1";
            this.createMultipleTaskDeptHead.Name = "createMultipleTaskDeptHead";
            activitybind18.Name = "SIUP";
            activitybind18.Path = "createMultipleTaskDeptHead_Subject1";
            activitybind19.Name = "SIUP";
            activitybind19.Path = "createMultipleTaskDeptHead_TaskTitle1";
            activitybind20.Name = "SIUP";
            activitybind20.Path = "createMultipleTaskDeptHead_WFName1";
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.createMultipleTaskDeptHead.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            // 
            // UpdatePermissionDeptHead
            // 
            this.UpdatePermissionDeptHead.Name = "UpdatePermissionDeptHead";
            this.UpdatePermissionDeptHead.ExecuteCode += new System.EventHandler(this.UpdatePermissionDeptHead_ExecuteCode);
            // 
            // PopulateDeptHead
            // 
            this.PopulateDeptHead.Name = "PopulateDeptHead";
            this.PopulateDeptHead.ExecuteCode += new System.EventHandler(this.PopulateDeptHead_ExecuteCode);
            activitybind22.Name = "SIUP";
            activitybind22.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind21.Name = "SIUP";
            activitybind21.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            // 
            // SIUP
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.PopulateDeptHead);
            this.Activities.Add(this.UpdatePermissionDeptHead);
            this.Activities.Add(this.createMultipleTaskDeptHead);
            this.Activities.Add(this.updateAllTasksDeptHead);
            this.Activities.Add(this.GetDeptHeadApprovalStatus);
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "SIUP";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity SendMailDeptHead;

        private CodeActivity UpdatePermissionRejected;

        private CodeActivity UpdatePermissionApproved;

        private CodeActivity UpdatePermissionOriginator;

        private CodeActivity UpdatePermissionDeptHead;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksOriginator;

        private CodeActivity PopulateDataOriginator;

        private Activity.CreateMultipleTask createMultipleTaskOriginator;

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailOriginator;

        private CodeActivity GetDeptHeadApprovalStatus;

        private IfElseBranchActivity Reject;

        private IfElseBranchActivity Approve;

        private IfElseActivity ifElseActivity1;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksDeptHead;

        private Activity.CreateMultipleTask createMultipleTaskDeptHead;

        private CodeActivity PopulateDeptHead;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;









































    }
}
