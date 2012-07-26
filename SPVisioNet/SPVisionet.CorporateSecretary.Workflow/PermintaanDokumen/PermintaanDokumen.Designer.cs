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

namespace SPVisionet.CorporateSecretary.Workflow.PermintaanDokumen
{
    public sealed partial class PermintaanDokumen
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
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind25 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind26 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind28 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind27 = new System.Workflow.ComponentModel.ActivityBind();
            this.createSingleTask1 = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateSingleTask();
            this.sendEmailReject = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.UpdatePermissionReject = new System.Workflow.Activities.CodeActivity();
            this.sendEmailApprove = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.UpdatePermissionApprove = new System.Workflow.Activities.CodeActivity();
            this.GetCustodian2ActionData = new System.Workflow.Activities.CodeActivity();
            this.updateAllCustodian2Tasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createCustodian2Task = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionCustodian2 = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataCustodian2 = new System.Workflow.Activities.CodeActivity();
            this.updateAllReplicatorTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.replicatorActivity1 = new System.Workflow.Activities.ReplicatorActivity();
            this.logToHistoryListActivity1 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.UpdatePermissionReplicator = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataReplicator = new System.Workflow.Activities.CodeActivity();
            this.ReplicatorReject = new System.Workflow.Activities.IfElseBranchActivity();
            this.ReplicatorApprove = new System.Workflow.Activities.IfElseBranchActivity();
            this.CustodianReject = new System.Workflow.Activities.IfElseBranchActivity();
            this.CustodianApprove = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.GetCustodianApprovalStatus = new System.Workflow.Activities.CodeActivity();
            this.updateAllCustodianTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createCustodianTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionCustodian = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataCustodian = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // createSingleTask1
            // 
            this.createSingleTask1.@__Context = null;
            this.createSingleTask1.Body = null;
            this.createSingleTask1.ContentTypeId = null;
            this.createSingleTask1.ListItemId = 0;
            this.createSingleTask1.Name = "createSingleTask1";
            this.createSingleTask1.Subject = null;
            this.createSingleTask1.TaskProperties = null;
            this.createSingleTask1.WFName = null;
            // 
            // sendEmailReject
            // 
            this.sendEmailReject.BCC = null;
            activitybind1.Name = "PermintaanDokumen";
            activitybind1.Path = "sendEmailReject_Body1";
            this.sendEmailReject.CC = null;
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "PermintaanDokumen";
            this.sendEmailReject.CorrelationToken = correlationtoken1;
            this.sendEmailReject.From = null;
            activitybind2.Name = "PermintaanDokumen";
            activitybind2.Path = "sendEmailReject_Headers1";
            this.sendEmailReject.IncludeStatus = false;
            this.sendEmailReject.Name = "sendEmailReject";
            this.sendEmailReject.Subject = null;
            this.sendEmailReject.To = null;
            this.sendEmailReject.MethodInvoking += new System.EventHandler(this.sendEmailReject_MethodInvoking);
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // UpdatePermissionReject
            // 
            this.UpdatePermissionReject.Name = "UpdatePermissionReject";
            this.UpdatePermissionReject.ExecuteCode += new System.EventHandler(this.UpdatePermissionReject_ExecuteCode);
            // 
            // sendEmailApprove
            // 
            this.sendEmailApprove.BCC = null;
            activitybind3.Name = "PermintaanDokumen";
            activitybind3.Path = "sendEmailApprove_Body1";
            this.sendEmailApprove.CC = null;
            this.sendEmailApprove.CorrelationToken = correlationtoken1;
            this.sendEmailApprove.From = null;
            activitybind4.Name = "PermintaanDokumen";
            activitybind4.Path = "sendEmailApprove_Headers1";
            this.sendEmailApprove.IncludeStatus = false;
            this.sendEmailApprove.Name = "sendEmailApprove";
            this.sendEmailApprove.Subject = null;
            this.sendEmailApprove.To = null;
            this.sendEmailApprove.MethodInvoking += new System.EventHandler(this.sendEmailApprove_MethodInvoking);
            this.sendEmailApprove.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.sendEmailApprove.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // UpdatePermissionApprove
            // 
            this.UpdatePermissionApprove.Name = "UpdatePermissionApprove";
            this.UpdatePermissionApprove.ExecuteCode += new System.EventHandler(this.UpdatePermissionApprove_ExecuteCode);
            // 
            // GetCustodian2ActionData
            // 
            this.GetCustodian2ActionData.Name = "GetCustodian2ActionData";
            this.GetCustodian2ActionData.ExecuteCode += new System.EventHandler(this.GetCustodian2ActionData_ExecuteCode);
            // 
            // updateAllCustodian2Tasks
            // 
            this.updateAllCustodian2Tasks.CorrelationToken = correlationtoken1;
            this.updateAllCustodian2Tasks.Name = "updateAllCustodian2Tasks";
            activitybind5.Name = "PermintaanDokumen";
            activitybind5.Path = "updateAllCustodian2Tasks_TaskProperties1";
            this.updateAllCustodian2Tasks.MethodInvoking += new System.EventHandler(this.updateAllCustodian2Tasks_MethodInvoking);
            this.updateAllCustodian2Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // createCustodian2Task
            // 
            activitybind6.Name = "PermintaanDokumen";
            activitybind6.Path = "createCustodian2Task___Context1";
            activitybind7.Name = "PermintaanDokumen";
            activitybind7.Path = "createCustodian2Task_AssignedTo1";
            activitybind8.Name = "PermintaanDokumen";
            activitybind8.Path = "createCustodian2Task_Body1";
            activitybind9.Name = "PermintaanDokumen";
            activitybind9.Path = "createCustodian2Task_ContentTypeId1";
            activitybind10.Name = "PermintaanDokumen";
            activitybind10.Path = "createCustodian2Task_ListItemId1";
            this.createCustodian2Task.Name = "createCustodian2Task";
            activitybind11.Name = "PermintaanDokumen";
            activitybind11.Path = "createCustodian2Task_Subject1";
            activitybind12.Name = "PermintaanDokumen";
            activitybind12.Path = "createCustodian2Task_TaskTitle1";
            activitybind13.Name = "PermintaanDokumen";
            activitybind13.Path = "createCustodian2Task_WFName1";
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.createCustodian2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            // 
            // UpdatePermissionCustodian2
            // 
            this.UpdatePermissionCustodian2.Name = "UpdatePermissionCustodian2";
            this.UpdatePermissionCustodian2.ExecuteCode += new System.EventHandler(this.UpdatePermissionCustodian2_ExecuteCode);
            // 
            // PopulateDataCustodian2
            // 
            this.PopulateDataCustodian2.Name = "PopulateDataCustodian2";
            this.PopulateDataCustodian2.ExecuteCode += new System.EventHandler(this.PopulateDataCustodian2_ExecuteCode);
            // 
            // updateAllReplicatorTasks
            // 
            this.updateAllReplicatorTasks.CorrelationToken = correlationtoken1;
            this.updateAllReplicatorTasks.Name = "updateAllReplicatorTasks";
            activitybind14.Name = "PermintaanDokumen";
            activitybind14.Path = "updateAllReplicatorTasks_TaskProperties1";
            this.updateAllReplicatorTasks.MethodInvoking += new System.EventHandler(this.updateAllReplicatorTasks_MethodInvoking);
            this.updateAllReplicatorTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            activitybind15.Name = "PermintaanDokumen";
            activitybind15.Path = "assignedToColl";
            // 
            // replicatorActivity1
            // 
            this.replicatorActivity1.Activities.Add(this.createSingleTask1);
            this.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Parallel;
            this.replicatorActivity1.Name = "replicatorActivity1";
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.replicatorActivity1_UntilCondition);
            this.replicatorActivity1.UntilCondition = codecondition1;
            this.replicatorActivity1.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.replicatorActivity1_ChildInitialized);
            this.replicatorActivity1.ChildCompleted += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.replicatorActivity1_ChildCompleted);
            this.replicatorActivity1.Completed += new System.EventHandler(this.replicatorActivity1_Completed);
            this.replicatorActivity1.Initialized += new System.EventHandler(this.replicatorActivity1_Initialized);
            this.replicatorActivity1.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            // 
            // logToHistoryListActivity1
            // 
            this.logToHistoryListActivity1.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity1.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind16.Name = "PermintaanDokumen";
            activitybind16.Path = "logToHistoryListActivity1_HistoryDescription1";
            activitybind17.Name = "PermintaanDokumen";
            activitybind17.Path = "logToHistoryListActivity1_HistoryOutcome1";
            this.logToHistoryListActivity1.Name = "logToHistoryListActivity1";
            this.logToHistoryListActivity1.OtherData = "";
            this.logToHistoryListActivity1.UserId = -1;
            this.logToHistoryListActivity1.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity1_MethodInvoking);
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // UpdatePermissionReplicator
            // 
            this.UpdatePermissionReplicator.Name = "UpdatePermissionReplicator";
            this.UpdatePermissionReplicator.ExecuteCode += new System.EventHandler(this.UpdatePermissionReplicator_ExecuteCode);
            // 
            // PopulateDataReplicator
            // 
            this.PopulateDataReplicator.Name = "PopulateDataReplicator";
            this.PopulateDataReplicator.ExecuteCode += new System.EventHandler(this.PopulateDataReplicator_ExecuteCode);
            // 
            // ReplicatorReject
            // 
            this.ReplicatorReject.Activities.Add(this.UpdatePermissionReject);
            this.ReplicatorReject.Activities.Add(this.sendEmailReject);
            this.ReplicatorReject.Name = "ReplicatorReject";
            // 
            // ReplicatorApprove
            // 
            this.ReplicatorApprove.Activities.Add(this.PopulateDataCustodian2);
            this.ReplicatorApprove.Activities.Add(this.UpdatePermissionCustodian2);
            this.ReplicatorApprove.Activities.Add(this.createCustodian2Task);
            this.ReplicatorApprove.Activities.Add(this.updateAllCustodian2Tasks);
            this.ReplicatorApprove.Activities.Add(this.GetCustodian2ActionData);
            this.ReplicatorApprove.Activities.Add(this.UpdatePermissionApprove);
            this.ReplicatorApprove.Activities.Add(this.sendEmailApprove);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.ReplicatorApprove.Condition = codecondition2;
            this.ReplicatorApprove.Name = "ReplicatorApprove";
            // 
            // CustodianReject
            // 
            this.CustodianReject.Name = "CustodianReject";
            // 
            // CustodianApprove
            // 
            this.CustodianApprove.Activities.Add(this.PopulateDataReplicator);
            this.CustodianApprove.Activities.Add(this.UpdatePermissionReplicator);
            this.CustodianApprove.Activities.Add(this.logToHistoryListActivity1);
            this.CustodianApprove.Activities.Add(this.replicatorActivity1);
            this.CustodianApprove.Activities.Add(this.updateAllReplicatorTasks);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.CustodianApprove.Condition = codecondition3;
            this.CustodianApprove.Name = "CustodianApprove";
            // 
            // ifElseActivity2
            // 
            this.ifElseActivity2.Activities.Add(this.ReplicatorApprove);
            this.ifElseActivity2.Activities.Add(this.ReplicatorReject);
            this.ifElseActivity2.Name = "ifElseActivity2";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.CustodianApprove);
            this.ifElseActivity1.Activities.Add(this.CustodianReject);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // GetCustodianApprovalStatus
            // 
            this.GetCustodianApprovalStatus.Name = "GetCustodianApprovalStatus";
            this.GetCustodianApprovalStatus.ExecuteCode += new System.EventHandler(this.GetCustodianApprovalStatus_ExecuteCode);
            // 
            // updateAllCustodianTasks
            // 
            this.updateAllCustodianTasks.CorrelationToken = correlationtoken1;
            this.updateAllCustodianTasks.Name = "updateAllCustodianTasks";
            activitybind18.Name = "PermintaanDokumen";
            activitybind18.Path = "updateAllCustodianTasks_TaskProperties1";
            this.updateAllCustodianTasks.MethodInvoking += new System.EventHandler(this.updateAllCustodianTasks_MethodInvoking);
            this.updateAllCustodianTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            // 
            // createCustodianTask
            // 
            activitybind19.Name = "PermintaanDokumen";
            activitybind19.Path = "createCustodianTask___Context1";
            activitybind20.Name = "PermintaanDokumen";
            activitybind20.Path = "createCustodianTask_AssignedTo1";
            activitybind21.Name = "PermintaanDokumen";
            activitybind21.Path = "createCustodianTask_Body1";
            activitybind22.Name = "PermintaanDokumen";
            activitybind22.Path = "createCustodianTask_ContentTypeId1";
            activitybind23.Name = "PermintaanDokumen";
            activitybind23.Path = "createCustodianTask_ListItemId1";
            this.createCustodianTask.Name = "createCustodianTask";
            activitybind24.Name = "PermintaanDokumen";
            activitybind24.Path = "createCustodianTask_Subject1";
            activitybind25.Name = "PermintaanDokumen";
            activitybind25.Path = "createCustodianTask_TaskTitle1";
            activitybind26.Name = "PermintaanDokumen";
            activitybind26.Path = "createCustodianTask_WFName1";
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            this.createCustodianTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            // 
            // UpdatePermissionCustodian
            // 
            this.UpdatePermissionCustodian.Name = "UpdatePermissionCustodian";
            this.UpdatePermissionCustodian.ExecuteCode += new System.EventHandler(this.UpdatePermissionCustodian_ExecuteCode);
            // 
            // PopulateDataCustodian
            // 
            this.PopulateDataCustodian.Name = "PopulateDataCustodian";
            this.PopulateDataCustodian.ExecuteCode += new System.EventHandler(this.PopulateDataCustodian_ExecuteCode);
            activitybind28.Name = "PermintaanDokumen";
            activitybind28.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind27.Name = "PermintaanDokumen";
            activitybind27.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            // 
            // PermintaanDokumen
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.PopulateDataCustodian);
            this.Activities.Add(this.UpdatePermissionCustodian);
            this.Activities.Add(this.createCustodianTask);
            this.Activities.Add(this.updateAllCustodianTasks);
            this.Activities.Add(this.GetCustodianApprovalStatus);
            this.Activities.Add(this.ifElseActivity1);
            this.Activities.Add(this.ifElseActivity2);
            this.Name = "PermintaanDokumen";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailReject;

        private CodeActivity UpdatePermissionReject;

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailApprove;

        private CodeActivity UpdatePermissionApprove;

        private CodeActivity GetCustodian2ActionData;

        private IfElseBranchActivity ReplicatorReject;

        private IfElseBranchActivity ReplicatorApprove;

        private IfElseActivity ifElseActivity2;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllCustodian2Tasks;

        private Activity.CreateMultipleTask createCustodian2Task;

        private CodeActivity UpdatePermissionCustodian2;

        private CodeActivity PopulateDataCustodian2;

        private Activity.CreateSingleTask createSingleTask1;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllReplicatorTasks;

        private ReplicatorActivity replicatorActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity1;

        private CodeActivity UpdatePermissionReplicator;

        private CodeActivity PopulateDataReplicator;

        private CodeActivity GetCustodianApprovalStatus;

        private IfElseBranchActivity CustodianReject;

        private IfElseBranchActivity CustodianApprove;

        private IfElseActivity ifElseActivity1;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllCustodianTasks;

        private Activity.CreateMultipleTask createCustodianTask;

        private CodeActivity UpdatePermissionCustodian;

        private CodeActivity PopulateDataCustodian;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;










































































    }
}
