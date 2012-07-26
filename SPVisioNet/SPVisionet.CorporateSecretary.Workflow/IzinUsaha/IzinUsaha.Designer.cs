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

namespace SPVisionet.CorporateSecretary.Workflow.IzinUsaha
{
    public sealed partial class IzinUsaha
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
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind25 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind26 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind27 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind28 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind29 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind31 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind30 = new System.Workflow.ComponentModel.ActivityBind();
            this.updateAllTasksOriginator = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTaskOriginator = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionOriginator = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataOriginator = new System.Workflow.Activities.CodeActivity();
            this.RejectChiefCorsec = new System.Workflow.Activities.IfElseBranchActivity();
            this.ApproveChiefCorsec = new System.Workflow.Activities.IfElseBranchActivity();
            this.sendEmailReject = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.UpdatePermissionReject = new System.Workflow.Activities.CodeActivity();
            this.SendMailApprove = new System.Workflow.Activities.CodeActivity();
            this.UpdatePermissionApprove = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.GetChiefCorsecApprovalStatus = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasksChiefCorsec = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTaskChiefCorsec = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionCorsec = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataChiefCoresec = new System.Workflow.Activities.CodeActivity();
            this.Reject = new System.Workflow.Activities.IfElseBranchActivity();
            this.Approve = new System.Workflow.Activities.IfElseBranchActivity();
            this.RejectDeptHead = new System.Workflow.Activities.IfElseBranchActivity();
            this.ApproveDeptHead = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity3 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.GetApprovalStatus = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasks1 = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTask1 = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermission = new System.Workflow.Activities.CodeActivity();
            this.PopulateData = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // updateAllTasksOriginator
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "IzinUsaha";
            this.updateAllTasksOriginator.CorrelationToken = correlationtoken1;
            this.updateAllTasksOriginator.Name = "updateAllTasksOriginator";
            activitybind1.Name = "IzinUsaha";
            activitybind1.Path = "updateAllTasksOriginator_TaskProperties1";
            this.updateAllTasksOriginator.MethodInvoking += new System.EventHandler(this.updateAllTasksOriginator_MethodInvoking);
            this.updateAllTasksOriginator.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // createMultipleTaskOriginator
            // 
            activitybind2.Name = "IzinUsaha";
            activitybind2.Path = "createMultipleTaskOriginator___Context1";
            activitybind3.Name = "IzinUsaha";
            activitybind3.Path = "createMultipleTaskOriginator_AssignedTo1";
            activitybind4.Name = "IzinUsaha";
            activitybind4.Path = "createMultipleTaskOriginator_Body1";
            activitybind5.Name = "IzinUsaha";
            activitybind5.Path = "createMultipleTaskOriginator_ContentTypeId1";
            activitybind6.Name = "IzinUsaha";
            activitybind6.Path = "createMultipleTaskOriginator_ListItemId1";
            this.createMultipleTaskOriginator.Name = "createMultipleTaskOriginator";
            activitybind7.Name = "IzinUsaha";
            activitybind7.Path = "createMultipleTaskOriginator_Subject1";
            activitybind8.Name = "IzinUsaha";
            activitybind8.Path = "createMultipleTaskOriginator_TaskTitle1";
            activitybind9.Name = "IzinUsaha";
            activitybind9.Path = "createMultipleTaskOriginator_WFName1";
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.createMultipleTaskOriginator.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
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
            // RejectChiefCorsec
            // 
            this.RejectChiefCorsec.Name = "RejectChiefCorsec";
            // 
            // ApproveChiefCorsec
            // 
            this.ApproveChiefCorsec.Activities.Add(this.PopulateDataOriginator);
            this.ApproveChiefCorsec.Activities.Add(this.UpdatePermissionOriginator);
            this.ApproveChiefCorsec.Activities.Add(this.createMultipleTaskOriginator);
            this.ApproveChiefCorsec.Activities.Add(this.updateAllTasksOriginator);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.ApproveChiefCorsec.Condition = codecondition1;
            this.ApproveChiefCorsec.Name = "ApproveChiefCorsec";
            // 
            // sendEmailReject
            // 
            this.sendEmailReject.BCC = null;
            activitybind10.Name = "IzinUsaha";
            activitybind10.Path = "sendEmailReject_Body1";
            this.sendEmailReject.CC = null;
            this.sendEmailReject.CorrelationToken = correlationtoken1;
            this.sendEmailReject.From = null;
            activitybind11.Name = "IzinUsaha";
            activitybind11.Path = "sendEmailReject_Headers1";
            this.sendEmailReject.IncludeStatus = false;
            this.sendEmailReject.Name = "sendEmailReject";
            this.sendEmailReject.Subject = null;
            this.sendEmailReject.To = null;
            this.sendEmailReject.MethodInvoking += new System.EventHandler(this.sendEmailReject_MethodInvoking);
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // UpdatePermissionReject
            // 
            this.UpdatePermissionReject.Name = "UpdatePermissionReject";
            this.UpdatePermissionReject.ExecuteCode += new System.EventHandler(this.UpdatePermissionReject_ExecuteCode);
            // 
            // SendMailApprove
            // 
            this.SendMailApprove.Name = "SendMailApprove";
            this.SendMailApprove.ExecuteCode += new System.EventHandler(this.SendMailApprove_ExecuteCode);
            // 
            // UpdatePermissionApprove
            // 
            this.UpdatePermissionApprove.Name = "UpdatePermissionApprove";
            this.UpdatePermissionApprove.ExecuteCode += new System.EventHandler(this.UpdatePermissionApprove_ExecuteCode);
            // 
            // ifElseActivity2
            // 
            this.ifElseActivity2.Activities.Add(this.ApproveChiefCorsec);
            this.ifElseActivity2.Activities.Add(this.RejectChiefCorsec);
            this.ifElseActivity2.Name = "ifElseActivity2";
            // 
            // GetChiefCorsecApprovalStatus
            // 
            this.GetChiefCorsecApprovalStatus.Name = "GetChiefCorsecApprovalStatus";
            this.GetChiefCorsecApprovalStatus.ExecuteCode += new System.EventHandler(this.GetChiefCorsecApprovalStatus_ExecuteCode);
            // 
            // updateAllTasksChiefCorsec
            // 
            this.updateAllTasksChiefCorsec.CorrelationToken = correlationtoken1;
            this.updateAllTasksChiefCorsec.Name = "updateAllTasksChiefCorsec";
            activitybind12.Name = "IzinUsaha";
            activitybind12.Path = "updateAllTasksChiefCorsec_TaskProperties1";
            this.updateAllTasksChiefCorsec.MethodInvoking += new System.EventHandler(this.updateAllTasksChiefCorsec_MethodInvoking);
            this.updateAllTasksChiefCorsec.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // createMultipleTaskChiefCorsec
            // 
            activitybind13.Name = "IzinUsaha";
            activitybind13.Path = "createMultipleTaskChiefCorsec___Context1";
            activitybind14.Name = "IzinUsaha";
            activitybind14.Path = "createMultipleTaskChiefCorsec_AssignedTo1";
            activitybind15.Name = "IzinUsaha";
            activitybind15.Path = "createMultipleTaskChiefCorsec_Body1";
            activitybind16.Name = "IzinUsaha";
            activitybind16.Path = "createMultipleTaskChiefCorsec_ContentTypeId1";
            activitybind17.Name = "IzinUsaha";
            activitybind17.Path = "createMultipleTaskChiefCorsec_ListItemId1";
            this.createMultipleTaskChiefCorsec.Name = "createMultipleTaskChiefCorsec";
            activitybind18.Name = "IzinUsaha";
            activitybind18.Path = "createMultipleTaskChiefCorsec_Subject1";
            activitybind19.Name = "IzinUsaha";
            activitybind19.Path = "createMultipleTaskChiefCorsec_TaskTitle1";
            activitybind20.Name = "IzinUsaha";
            activitybind20.Path = "createMultipleTaskChiefCorsec_WFName1";
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.createMultipleTaskChiefCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            // 
            // UpdatePermissionCorsec
            // 
            this.UpdatePermissionCorsec.Name = "UpdatePermissionCorsec";
            this.UpdatePermissionCorsec.ExecuteCode += new System.EventHandler(this.UpdatePermissionCorsec_ExecuteCode);
            // 
            // PopulateDataChiefCoresec
            // 
            this.PopulateDataChiefCoresec.Name = "PopulateDataChiefCoresec";
            this.PopulateDataChiefCoresec.ExecuteCode += new System.EventHandler(this.PopulateDataChiefCoresec_ExecuteCode);
            // 
            // Reject
            // 
            this.Reject.Activities.Add(this.UpdatePermissionReject);
            this.Reject.Activities.Add(this.sendEmailReject);
            this.Reject.Name = "Reject";
            // 
            // Approve
            // 
            this.Approve.Activities.Add(this.UpdatePermissionApprove);
            this.Approve.Activities.Add(this.SendMailApprove);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.Approve.Condition = codecondition2;
            this.Approve.Name = "Approve";
            // 
            // RejectDeptHead
            // 
            this.RejectDeptHead.Name = "RejectDeptHead";
            // 
            // ApproveDeptHead
            // 
            this.ApproveDeptHead.Activities.Add(this.PopulateDataChiefCoresec);
            this.ApproveDeptHead.Activities.Add(this.UpdatePermissionCorsec);
            this.ApproveDeptHead.Activities.Add(this.createMultipleTaskChiefCorsec);
            this.ApproveDeptHead.Activities.Add(this.updateAllTasksChiefCorsec);
            this.ApproveDeptHead.Activities.Add(this.GetChiefCorsecApprovalStatus);
            this.ApproveDeptHead.Activities.Add(this.ifElseActivity2);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.ApproveDeptHead.Condition = codecondition3;
            this.ApproveDeptHead.Name = "ApproveDeptHead";
            // 
            // ifElseActivity3
            // 
            this.ifElseActivity3.Activities.Add(this.Approve);
            this.ifElseActivity3.Activities.Add(this.Reject);
            this.ifElseActivity3.Name = "ifElseActivity3";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ApproveDeptHead);
            this.ifElseActivity1.Activities.Add(this.RejectDeptHead);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // GetApprovalStatus
            // 
            this.GetApprovalStatus.Name = "GetApprovalStatus";
            this.GetApprovalStatus.ExecuteCode += new System.EventHandler(this.GetApprovalStatus_ExecuteCode);
            // 
            // updateAllTasks1
            // 
            this.updateAllTasks1.CorrelationToken = correlationtoken1;
            this.updateAllTasks1.Name = "updateAllTasks1";
            activitybind21.Name = "IzinUsaha";
            activitybind21.Path = "updateAllTasks1_TaskProperties1";
            this.updateAllTasks1.MethodInvoking += new System.EventHandler(this.updateAllTasks1_MethodInvoking);
            this.updateAllTasks1.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            // 
            // createMultipleTask1
            // 
            activitybind22.Name = "IzinUsaha";
            activitybind22.Path = "createMultipleTask1___Context1";
            activitybind23.Name = "IzinUsaha";
            activitybind23.Path = "createMultipleTask1_AssignedTo1";
            activitybind24.Name = "IzinUsaha";
            activitybind24.Path = "createMultipleTask1_Body1";
            activitybind25.Name = "IzinUsaha";
            activitybind25.Path = "createMultipleTask1_ContentTypeId1";
            activitybind26.Name = "IzinUsaha";
            activitybind26.Path = "createMultipleTask1_ListItemId1";
            this.createMultipleTask1.Name = "createMultipleTask1";
            activitybind27.Name = "IzinUsaha";
            activitybind27.Path = "createMultipleTask1_Subject1";
            activitybind28.Name = "IzinUsaha";
            activitybind28.Path = "createMultipleTask1_TaskTitle1";
            activitybind29.Name = "IzinUsaha";
            activitybind29.Path = "createMultipleTask1_WFName1";
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            this.createMultipleTask1.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind29)));
            // 
            // UpdatePermission
            // 
            this.UpdatePermission.Name = "UpdatePermission";
            this.UpdatePermission.ExecuteCode += new System.EventHandler(this.UpdatePermission_ExecuteCode);
            // 
            // PopulateData
            // 
            this.PopulateData.Name = "PopulateData";
            this.PopulateData.ExecuteCode += new System.EventHandler(this.PopulateData_ExecuteCode);
            activitybind31.Name = "IzinUsaha";
            activitybind31.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind30.Name = "IzinUsaha";
            activitybind30.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind31)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind30)));
            // 
            // IzinUsaha
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.PopulateData);
            this.Activities.Add(this.UpdatePermission);
            this.Activities.Add(this.createMultipleTask1);
            this.Activities.Add(this.updateAllTasks1);
            this.Activities.Add(this.GetApprovalStatus);
            this.Activities.Add(this.ifElseActivity1);
            this.Activities.Add(this.ifElseActivity3);
            this.Name = "IzinUsaha";
            this.CanModifyActivities = false;

        }

        #endregion

        private CodeActivity SendMailApprove;

        private IfElseBranchActivity Reject;

        private IfElseBranchActivity Approve;

        private IfElseActivity ifElseActivity3;

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailReject;

        private CodeActivity UpdatePermissionReject;

        private CodeActivity UpdatePermissionApprove;

        private CodeActivity UpdatePermissionOriginator;

        private CodeActivity UpdatePermissionCorsec;

        private CodeActivity UpdatePermission;

        private CodeActivity GetChiefCorsecApprovalStatus;

        private Activity.CreateMultipleTask createMultipleTaskOriginator;

        private CodeActivity PopulateDataOriginator;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksOriginator;

        private IfElseBranchActivity RejectChiefCorsec;

        private IfElseBranchActivity ApproveChiefCorsec;

        private IfElseActivity ifElseActivity2;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksChiefCorsec;

        private Activity.CreateMultipleTask createMultipleTaskChiefCorsec;

        private CodeActivity PopulateDataChiefCoresec;

        private IfElseBranchActivity RejectDeptHead;

        private IfElseBranchActivity ApproveDeptHead;

        private IfElseActivity ifElseActivity1;

        private CodeActivity GetApprovalStatus;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasks1;

        private Activity.CreateMultipleTask createMultipleTask1;

        private CodeActivity PopulateData;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;























































    }
}
