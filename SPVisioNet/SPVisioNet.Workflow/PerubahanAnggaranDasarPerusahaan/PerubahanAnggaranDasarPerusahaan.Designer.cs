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

namespace SPVisionet.Workflow.PerubahanAnggaranDasarPerusahaan
{
    public sealed partial class PerubahanAnggaranDasarPerusahaan
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
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
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
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind18 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind19 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind20 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind21 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind22 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind23 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind24 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind25 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind26 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind27 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind28 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind29 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind30 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind31 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind32 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind33 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind34 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind35 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind36 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind37 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind38 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind39 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind40 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind41 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind42 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind43 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind44 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind45 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind46 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind47 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind48 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind49 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind50 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind51 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind52 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference2 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference3 = new System.Workflow.Activities.Rules.RuleConditionReference();
            System.Workflow.ComponentModel.ActivityBind activitybind53 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind54 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind55 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind56 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind57 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind58 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind59 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind60 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind61 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind62 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind63 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind64 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind65 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind66 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind67 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind68 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind69 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind70 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind71 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind72 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind73 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind74 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind75 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind76 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind77 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind78 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind79 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind80 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind82 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind81 = new System.Workflow.ComponentModel.ActivityBind();
            this.logToHistoryListActivity3 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.updateAllTasksPicFinance = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTask_PicFinance = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.SetPermissionPicFinance = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPicFinance = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasksPicAcc = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTask_PicTax = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.SetPermissionPicAcc = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPicAcc = new System.Workflow.Activities.CodeActivity();
            this.logToHistoryListActivity4 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.logToHistoryListActivity1 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.updateAllTasksTax = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTask_PicCorsec3 = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionTax = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataTax = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasksPicCorsec2 = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTask_PicCorsec2 = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionPicCorsec2 = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPicCorsec2 = new System.Workflow.Activities.CodeActivity();
            this.logToHistoryListActivity2 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.updateAllTasksPicCorsecPMAPMDN = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTaskPMAPMDN = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.PopulatePicCorsec = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranchActivity4 = new System.Workflow.Activities.IfElseBranchActivity();
            this.IsPerubahanModalTrue = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.IsPerubahanNamaTrue = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity3 = new System.Workflow.Activities.IfElseBranchActivity();
            this.IfPMDN = new System.Workflow.Activities.IfElseBranchActivity();
            this.sendEmailToOriginator = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.UpdatePermissionRejected = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasksPicCorsec4 = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTask_PicCorsec4 = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.SetPermissionPicCorsec4 = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPicCorsec4 = new System.Workflow.Activities.CodeActivity();
            this.IfCheckPerubahanModal = new System.Workflow.Activities.IfElseActivity();
            this.IFCheckPerubahanNama = new System.Workflow.Activities.IfElseActivity();
            this.GetPerubahanNamaDanModal = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasks_PicCorsec = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createMultipleTask_PicCorsec = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.PopulatePicCorsec1 = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.UpdatePermissionPicCorsec = new System.Workflow.Activities.CodeActivity();
            this.GetPMAPMDN = new System.Workflow.Activities.CodeActivity();
            this.Rejected = new System.Workflow.Activities.IfElseBranchActivity();
            this.Approve = new System.Workflow.Activities.IfElseBranchActivity();
            this.UpdatePermissionCompleted = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.GetCorsecStatus = new System.Workflow.Activities.CodeActivity();
            this.updateAllTasksDivHead = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.PerubahanAnggaran = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.SetPermissionToDivHead = new System.Workflow.Activities.CodeActivity();
            this.PopulatedDivHead = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // logToHistoryListActivity3
            // 
            this.logToHistoryListActivity3.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity3.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind1.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind1.Path = "logToHistoryListActivity3_HistoryDescription1";
            activitybind2.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind2.Path = "logToHistoryListActivity3_HistoryOutcome1";
            this.logToHistoryListActivity3.Name = "logToHistoryListActivity3";
            this.logToHistoryListActivity3.OtherData = "";
            this.logToHistoryListActivity3.UserId = -1;
            this.logToHistoryListActivity3.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity3_MethodInvoking);
            this.logToHistoryListActivity3.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.logToHistoryListActivity3.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // updateAllTasksPicFinance
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "PerubahanAnggaranDasarPerusahaan";
            this.updateAllTasksPicFinance.CorrelationToken = correlationtoken1;
            this.updateAllTasksPicFinance.Name = "updateAllTasksPicFinance";
            activitybind3.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind3.Path = "updateAllTasksPicFinance_TaskProperties1";
            this.updateAllTasksPicFinance.MethodInvoking += new System.EventHandler(this.updateAllTasksPicFinance_MethodInvoking);
            this.updateAllTasksPicFinance.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // createMultipleTask_PicFinance
            // 
            activitybind4.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind4.Path = "createMultipleTask_PicFinance___Context1";
            activitybind5.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind5.Path = "createMultipleTask_PicFinance_AssignedTo1";
            activitybind6.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind6.Path = "createMultipleTask_PicFinance_Body1";
            activitybind7.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind7.Path = "createMultipleTask_PicFinance_ContentTypeId1";
            activitybind8.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind8.Path = "createMultipleTask_PicFinance_ListItemId1";
            this.createMultipleTask_PicFinance.Name = "createMultipleTask_PicFinance";
            activitybind9.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind9.Path = "createMultipleTask_PicFinance_Subject1";
            activitybind10.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind10.Path = "createMultipleTask_PicFinance_TaskTitle1";
            activitybind11.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind11.Path = "createMultipleTask_PicFinance_WFName1";
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.createMultipleTask_PicFinance.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            // 
            // SetPermissionPicFinance
            // 
            this.SetPermissionPicFinance.Name = "SetPermissionPicFinance";
            this.SetPermissionPicFinance.ExecuteCode += new System.EventHandler(this.SetPermissionPicFinance_ExecuteCode);
            // 
            // PopulateDataPicFinance
            // 
            this.PopulateDataPicFinance.Name = "PopulateDataPicFinance";
            this.PopulateDataPicFinance.ExecuteCode += new System.EventHandler(this.PopulateDataPicFinance_ExecuteCode);
            // 
            // updateAllTasksPicAcc
            // 
            this.updateAllTasksPicAcc.CorrelationToken = correlationtoken1;
            this.updateAllTasksPicAcc.Name = "updateAllTasksPicAcc";
            activitybind12.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind12.Path = "updateAllTasksPicCorsec3_TaskProperties1";
            this.updateAllTasksPicAcc.MethodInvoking += new System.EventHandler(this.updateAllTasksPicCorsec3_MethodInvoking);
            this.updateAllTasksPicAcc.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // createMultipleTask_PicTax
            // 
            activitybind13.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind13.Path = "createMultipleTask_PicCorsec3___Context1";
            activitybind14.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind14.Path = "createMultipleTask_PicCorsec3_AssignedTo1";
            activitybind15.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind15.Path = "createMultipleTask_PicCorsec3_Body1";
            activitybind16.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind16.Path = "createMultipleTask_PicCorsec3_ContentTypeId1";
            activitybind17.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind17.Path = "createMultipleTask_PicCorsec3_ListItemId1";
            this.createMultipleTask_PicTax.Name = "createMultipleTask_PicTax";
            activitybind18.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind18.Path = "createMultipleTask_PicCorsec3_Subject1";
            activitybind19.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind19.Path = "createMultipleTask_PicCorsec3_TaskTitle1";
            activitybind20.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind20.Path = "createMultipleTask_PicCorsec3_WFName1";
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.createMultipleTask_PicTax.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            // 
            // SetPermissionPicAcc
            // 
            this.SetPermissionPicAcc.Name = "SetPermissionPicAcc";
            this.SetPermissionPicAcc.ExecuteCode += new System.EventHandler(this.SetPermissionPicCorsec3_ExecuteCode);
            // 
            // PopulateDataPicAcc
            // 
            this.PopulateDataPicAcc.Name = "PopulateDataPicAcc";
            this.PopulateDataPicAcc.ExecuteCode += new System.EventHandler(this.PopulateData_PicCorsec3_ExecuteCode);
            // 
            // logToHistoryListActivity4
            // 
            this.logToHistoryListActivity4.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity4.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind21.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind21.Path = "logToHistoryListActivity4_HistoryDescription1";
            activitybind22.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind22.Path = "logToHistoryListActivity4_HistoryOutcome1";
            this.logToHistoryListActivity4.Name = "logToHistoryListActivity4";
            this.logToHistoryListActivity4.OtherData = "";
            this.logToHistoryListActivity4.UserId = -1;
            this.logToHistoryListActivity4.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity4_MethodInvoking);
            this.logToHistoryListActivity4.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            this.logToHistoryListActivity4.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            // 
            // logToHistoryListActivity1
            // 
            this.logToHistoryListActivity1.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity1.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind23.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind23.Path = "logToHistoryListActivity1_HistoryDescription1";
            activitybind24.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind24.Path = "logToHistoryListActivity1_HistoryOutcome1";
            this.logToHistoryListActivity1.Name = "logToHistoryListActivity1";
            this.logToHistoryListActivity1.OtherData = "";
            this.logToHistoryListActivity1.UserId = -1;
            this.logToHistoryListActivity1.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity1_MethodInvoking);
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            // 
            // updateAllTasksTax
            // 
            this.updateAllTasksTax.CorrelationToken = correlationtoken1;
            this.updateAllTasksTax.Name = "updateAllTasksTax";
            activitybind25.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind25.Path = "updateAllTasks_PicCorsec1_TaskProperties1";
            this.updateAllTasksTax.MethodInvoking += new System.EventHandler(this.updateAllTasks_PicCorsec1_MethodInvoking);
            this.updateAllTasksTax.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            // 
            // createMultipleTask_PicCorsec3
            // 
            activitybind26.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind26.Path = "createMultipleTask_PicCorsec1___Context1";
            activitybind27.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind27.Path = "createMultipleTask_PicCorsec1_AssignedTo1";
            activitybind28.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind28.Path = "createMultipleTask_PicCorsec1_Body1";
            activitybind29.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind29.Path = "createMultipleTask_PicCorsec1_ContentTypeId1";
            activitybind30.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind30.Path = "createMultipleTask_PicCorsec1_ListItemId1";
            this.createMultipleTask_PicCorsec3.Name = "createMultipleTask_PicCorsec3";
            activitybind31.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind31.Path = "createMultipleTask_PicCorsec1_Subject1";
            activitybind32.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind32.Path = "createMultipleTask_PicCorsec1_TaskTitle1";
            activitybind33.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind33.Path = "createMultipleTask_PicCorsec1_WFName1";
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind29)));
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind30)));
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind31)));
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind32)));
            this.createMultipleTask_PicCorsec3.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind33)));
            // 
            // UpdatePermissionTax
            // 
            this.UpdatePermissionTax.Name = "UpdatePermissionTax";
            this.UpdatePermissionTax.ExecuteCode += new System.EventHandler(this.UpdatePermissionOriginator1_ExecuteCode);
            // 
            // PopulateDataTax
            // 
            this.PopulateDataTax.Name = "PopulateDataTax";
            this.PopulateDataTax.ExecuteCode += new System.EventHandler(this.PopulateDataOriginator1_ExecuteCode);
            // 
            // updateAllTasksPicCorsec2
            // 
            this.updateAllTasksPicCorsec2.CorrelationToken = correlationtoken1;
            this.updateAllTasksPicCorsec2.Name = "updateAllTasksPicCorsec2";
            activitybind34.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind34.Path = "updateAllTasks_Tax_TaskProperties1";
            this.updateAllTasksPicCorsec2.MethodInvoking += new System.EventHandler(this.updateAllTasks_Tax_MethodInvoking);
            this.updateAllTasksPicCorsec2.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind34)));
            // 
            // createMultipleTask_PicCorsec2
            // 
            activitybind35.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind35.Path = "createMultipleTask_Tax___Context1";
            activitybind36.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind36.Path = "createMultipleTask_Tax_AssignedTo1";
            activitybind37.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind37.Path = "createMultipleTask_Tax_Body1";
            activitybind38.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind38.Path = "createMultipleTask_Tax_ContentTypeId1";
            activitybind39.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind39.Path = "createMultipleTask_Tax_ListItemId1";
            this.createMultipleTask_PicCorsec2.Name = "createMultipleTask_PicCorsec2";
            activitybind40.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind40.Path = "createMultipleTask_Tax_Subject1";
            activitybind41.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind41.Path = "createMultipleTask_Tax_TaskTitle1";
            activitybind42.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind42.Path = "createMultipleTask_Tax_WFName1";
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind35)));
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind36)));
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind37)));
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind38)));
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind39)));
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind40)));
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind41)));
            this.createMultipleTask_PicCorsec2.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind42)));
            // 
            // UpdatePermissionPicCorsec2
            // 
            this.UpdatePermissionPicCorsec2.Name = "UpdatePermissionPicCorsec2";
            this.UpdatePermissionPicCorsec2.ExecuteCode += new System.EventHandler(this.UpdatePermissionTax_ExecuteCode);
            // 
            // PopulateDataPicCorsec2
            // 
            this.PopulateDataPicCorsec2.Name = "PopulateDataPicCorsec2";
            this.PopulateDataPicCorsec2.ExecuteCode += new System.EventHandler(this.PopulateDataTax_ExecuteCode);
            // 
            // logToHistoryListActivity2
            // 
            this.logToHistoryListActivity2.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity2.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind43.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind43.Path = "logToHistoryListActivity2_HistoryDescription1";
            activitybind44.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind44.Path = "logToHistoryListActivity2_HistoryOutcome1";
            this.logToHistoryListActivity2.Name = "logToHistoryListActivity2";
            this.logToHistoryListActivity2.OtherData = "";
            this.logToHistoryListActivity2.UserId = -1;
            this.logToHistoryListActivity2.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity2_MethodInvoking);
            this.logToHistoryListActivity2.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind43)));
            this.logToHistoryListActivity2.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind44)));
            // 
            // updateAllTasksPicCorsecPMAPMDN
            // 
            this.updateAllTasksPicCorsecPMAPMDN.CorrelationToken = correlationtoken1;
            this.updateAllTasksPicCorsecPMAPMDN.Name = "updateAllTasksPicCorsecPMAPMDN";
            activitybind45.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind45.Path = "updateAllTasksPicCorsecPMAPMDN_TaskProperties1";
            this.updateAllTasksPicCorsecPMAPMDN.MethodInvoking += new System.EventHandler(this.updateAllTasksPicCorsecPMAPMDN_MethodInvoking);
            this.updateAllTasksPicCorsecPMAPMDN.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind45)));
            // 
            // createMultipleTaskPMAPMDN
            // 
            activitybind46.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind46.Path = "createMultipleTaskPMAPMDN___Context1";
            activitybind47.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind47.Path = "createMultipleTaskPMAPMDN_AssignedTo1";
            activitybind48.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind48.Path = "createMultipleTaskPMAPMDN_Body1";
            activitybind49.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind49.Path = "createMultipleTaskPMAPMDN_ContentTypeId1";
            this.createMultipleTaskPMAPMDN.ListItemId = 0;
            this.createMultipleTaskPMAPMDN.Name = "createMultipleTaskPMAPMDN";
            activitybind50.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind50.Path = "createMultipleTaskPMAPMDN_Subject1";
            activitybind51.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind51.Path = "createMultipleTaskPMAPMDN_TaskTitle1";
            activitybind52.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind52.Path = "createMultipleTaskPMAPMDN_WFName1";
            this.createMultipleTaskPMAPMDN.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind46)));
            this.createMultipleTaskPMAPMDN.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind47)));
            this.createMultipleTaskPMAPMDN.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind48)));
            this.createMultipleTaskPMAPMDN.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind49)));
            this.createMultipleTaskPMAPMDN.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind50)));
            this.createMultipleTaskPMAPMDN.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind51)));
            this.createMultipleTaskPMAPMDN.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind52)));
            // 
            // PopulatePicCorsec
            // 
            this.PopulatePicCorsec.Name = "PopulatePicCorsec";
            this.PopulatePicCorsec.ExecuteCode += new System.EventHandler(this.PopulateDataOriginator_ExecuteCode);
            // 
            // ifElseBranchActivity4
            // 
            this.ifElseBranchActivity4.Activities.Add(this.logToHistoryListActivity3);
            this.ifElseBranchActivity4.Name = "ifElseBranchActivity4";
            // 
            // IsPerubahanModalTrue
            // 
            this.IsPerubahanModalTrue.Activities.Add(this.logToHistoryListActivity4);
            this.IsPerubahanModalTrue.Activities.Add(this.PopulateDataPicAcc);
            this.IsPerubahanModalTrue.Activities.Add(this.SetPermissionPicAcc);
            this.IsPerubahanModalTrue.Activities.Add(this.createMultipleTask_PicTax);
            this.IsPerubahanModalTrue.Activities.Add(this.updateAllTasksPicAcc);
            this.IsPerubahanModalTrue.Activities.Add(this.PopulateDataPicFinance);
            this.IsPerubahanModalTrue.Activities.Add(this.SetPermissionPicFinance);
            this.IsPerubahanModalTrue.Activities.Add(this.createMultipleTask_PicFinance);
            this.IsPerubahanModalTrue.Activities.Add(this.updateAllTasksPicFinance);
            ruleconditionreference1.ConditionName = "IsPerubahanModal==True";
            this.IsPerubahanModalTrue.Condition = ruleconditionreference1;
            this.IsPerubahanModalTrue.Name = "IsPerubahanModalTrue";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Activities.Add(this.logToHistoryListActivity1);
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // IsPerubahanNamaTrue
            // 
            this.IsPerubahanNamaTrue.Activities.Add(this.logToHistoryListActivity2);
            this.IsPerubahanNamaTrue.Activities.Add(this.PopulateDataPicCorsec2);
            this.IsPerubahanNamaTrue.Activities.Add(this.UpdatePermissionPicCorsec2);
            this.IsPerubahanNamaTrue.Activities.Add(this.createMultipleTask_PicCorsec2);
            this.IsPerubahanNamaTrue.Activities.Add(this.updateAllTasksPicCorsec2);
            this.IsPerubahanNamaTrue.Activities.Add(this.PopulateDataTax);
            this.IsPerubahanNamaTrue.Activities.Add(this.UpdatePermissionTax);
            this.IsPerubahanNamaTrue.Activities.Add(this.createMultipleTask_PicCorsec3);
            this.IsPerubahanNamaTrue.Activities.Add(this.updateAllTasksTax);
            ruleconditionreference2.ConditionName = "IsPerubahanNama==True";
            this.IsPerubahanNamaTrue.Condition = ruleconditionreference2;
            this.IsPerubahanNamaTrue.Name = "IsPerubahanNamaTrue";
            // 
            // ifElseBranchActivity3
            // 
            this.ifElseBranchActivity3.Name = "ifElseBranchActivity3";
            // 
            // IfPMDN
            // 
            this.IfPMDN.Activities.Add(this.PopulatePicCorsec);
            this.IfPMDN.Activities.Add(this.createMultipleTaskPMAPMDN);
            this.IfPMDN.Activities.Add(this.updateAllTasksPicCorsecPMAPMDN);
            ruleconditionreference3.ConditionName = "IsPMADN==True";
            this.IfPMDN.Condition = ruleconditionreference3;
            this.IfPMDN.Description = "PMDN = True";
            this.IfPMDN.Name = "IfPMDN";
            // 
            // sendEmailToOriginator
            // 
            this.sendEmailToOriginator.BCC = null;
            activitybind53.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind53.Path = "sendEmailToOriginator_Body1";
            this.sendEmailToOriginator.CC = null;
            this.sendEmailToOriginator.CorrelationToken = correlationtoken1;
            this.sendEmailToOriginator.From = null;
            activitybind54.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind54.Path = "sendEmailToOriginator_Headers1";
            this.sendEmailToOriginator.IncludeStatus = false;
            this.sendEmailToOriginator.Name = "sendEmailToOriginator";
            this.sendEmailToOriginator.Subject = null;
            this.sendEmailToOriginator.To = null;
            this.sendEmailToOriginator.MethodInvoking += new System.EventHandler(this.sendEmailToOriginator_MethodInvoking);
            this.sendEmailToOriginator.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind53)));
            this.sendEmailToOriginator.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind54)));
            // 
            // UpdatePermissionRejected
            // 
            this.UpdatePermissionRejected.Name = "UpdatePermissionRejected";
            this.UpdatePermissionRejected.ExecuteCode += new System.EventHandler(this.UpdatePermissionRejected_ExecuteCode);
            // 
            // updateAllTasksPicCorsec4
            // 
            this.updateAllTasksPicCorsec4.CorrelationToken = correlationtoken1;
            this.updateAllTasksPicCorsec4.Name = "updateAllTasksPicCorsec4";
            activitybind55.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind55.Path = "updateAllTasksPicCorsec4_TaskProperties1";
            this.updateAllTasksPicCorsec4.MethodInvoking += new System.EventHandler(this.updateAllTasksPicCorsec4_MethodInvoking);
            this.updateAllTasksPicCorsec4.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind55)));
            // 
            // createMultipleTask_PicCorsec4
            // 
            activitybind56.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind56.Path = "createMultipleTask_PicCorsec4___Context1";
            activitybind57.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind57.Path = "createMultipleTask_PicCorsec4_AssignedTo1";
            activitybind58.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind58.Path = "createMultipleTask_PicCorsec4_Body1";
            activitybind59.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind59.Path = "createMultipleTask_PicCorsec4_ContentTypeId1";
            this.createMultipleTask_PicCorsec4.ListItemId = 0;
            this.createMultipleTask_PicCorsec4.Name = "createMultipleTask_PicCorsec4";
            activitybind60.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind60.Path = "createMultipleTask_PicCorsec4_Subject1";
            activitybind61.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind61.Path = "createMultipleTask_PicCorsec4_TaskTitle1";
            activitybind62.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind62.Path = "createMultipleTask_PicCorsec4_WFName1";
            this.createMultipleTask_PicCorsec4.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind56)));
            this.createMultipleTask_PicCorsec4.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind57)));
            this.createMultipleTask_PicCorsec4.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind58)));
            this.createMultipleTask_PicCorsec4.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind59)));
            this.createMultipleTask_PicCorsec4.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind60)));
            this.createMultipleTask_PicCorsec4.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind61)));
            this.createMultipleTask_PicCorsec4.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind62)));
            // 
            // SetPermissionPicCorsec4
            // 
            this.SetPermissionPicCorsec4.Name = "SetPermissionPicCorsec4";
            this.SetPermissionPicCorsec4.ExecuteCode += new System.EventHandler(this.SetPermissionPicCorsecLast_ExecuteCode);
            // 
            // PopulateDataPicCorsec4
            // 
            this.PopulateDataPicCorsec4.Name = "PopulateDataPicCorsec4";
            this.PopulateDataPicCorsec4.ExecuteCode += new System.EventHandler(this.PopulateDataPicCorsecLast_ExecuteCode);
            // 
            // IfCheckPerubahanModal
            // 
            this.IfCheckPerubahanModal.Activities.Add(this.IsPerubahanModalTrue);
            this.IfCheckPerubahanModal.Activities.Add(this.ifElseBranchActivity4);
            this.IfCheckPerubahanModal.Name = "IfCheckPerubahanModal";
            // 
            // IFCheckPerubahanNama
            // 
            this.IFCheckPerubahanNama.Activities.Add(this.IsPerubahanNamaTrue);
            this.IFCheckPerubahanNama.Activities.Add(this.ifElseBranchActivity2);
            this.IFCheckPerubahanNama.Name = "IFCheckPerubahanNama";
            // 
            // GetPerubahanNamaDanModal
            // 
            this.GetPerubahanNamaDanModal.Name = "GetPerubahanNamaDanModal";
            this.GetPerubahanNamaDanModal.ExecuteCode += new System.EventHandler(this.GetPerubahanNamaDanModal_ExecuteCode);
            // 
            // updateAllTasks_PicCorsec
            // 
            this.updateAllTasks_PicCorsec.CorrelationToken = correlationtoken1;
            this.updateAllTasks_PicCorsec.Name = "updateAllTasks_PicCorsec";
            activitybind63.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind63.Path = "updateAllTasks_PicCorsec_TaskProperties1";
            this.updateAllTasks_PicCorsec.MethodInvoking += new System.EventHandler(this.updateAllTasks1_MethodInvoking);
            this.updateAllTasks_PicCorsec.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind63)));
            // 
            // createMultipleTask_PicCorsec
            // 
            activitybind64.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind64.Path = "createMultipleTask_PicCorsec___Context1";
            activitybind65.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind65.Path = "createMultipleTask_PicCorsec_AssignedTo1";
            activitybind66.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind66.Path = "createMultipleTask_PicCorsec_Body1";
            activitybind67.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind67.Path = "createMultipleTask_PicCorsec_ContentTypeId1";
            activitybind68.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind68.Path = "createMultipleTask_PicCorsec_ListItemId1";
            this.createMultipleTask_PicCorsec.Name = "createMultipleTask_PicCorsec";
            activitybind69.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind69.Path = "createMultipleTask_PicCorsec_Subject1";
            activitybind70.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind70.Path = "createMultipleTask_PicCorsec_TaskTitle1";
            activitybind71.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind71.Path = "createMultipleTask_PicCorsec_WFName1";
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind64)));
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind65)));
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind66)));
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind67)));
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind68)));
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind69)));
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind70)));
            this.createMultipleTask_PicCorsec.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind71)));
            // 
            // PopulatePicCorsec1
            // 
            this.PopulatePicCorsec1.Name = "PopulatePicCorsec1";
            this.PopulatePicCorsec1.ExecuteCode += new System.EventHandler(this.PopulateDataOriginatorAkta_ExecuteCode);
            // 
            // ifElseActivity2
            // 
            this.ifElseActivity2.Activities.Add(this.IfPMDN);
            this.ifElseActivity2.Activities.Add(this.ifElseBranchActivity3);
            this.ifElseActivity2.Name = "ifElseActivity2";
            // 
            // UpdatePermissionPicCorsec
            // 
            this.UpdatePermissionPicCorsec.Name = "UpdatePermissionPicCorsec";
            this.UpdatePermissionPicCorsec.ExecuteCode += new System.EventHandler(this.UpdatePermissionOriginator_ExecuteCode);
            // 
            // GetPMAPMDN
            // 
            this.GetPMAPMDN.Name = "GetPMAPMDN";
            this.GetPMAPMDN.ExecuteCode += new System.EventHandler(this.GetPMAPMDN_ExecuteCode);
            // 
            // Rejected
            // 
            this.Rejected.Activities.Add(this.UpdatePermissionRejected);
            this.Rejected.Activities.Add(this.sendEmailToOriginator);
            this.Rejected.Name = "Rejected";
            // 
            // Approve
            // 
            this.Approve.Activities.Add(this.GetPMAPMDN);
            this.Approve.Activities.Add(this.UpdatePermissionPicCorsec);
            this.Approve.Activities.Add(this.ifElseActivity2);
            this.Approve.Activities.Add(this.PopulatePicCorsec1);
            this.Approve.Activities.Add(this.createMultipleTask_PicCorsec);
            this.Approve.Activities.Add(this.updateAllTasks_PicCorsec);
            this.Approve.Activities.Add(this.GetPerubahanNamaDanModal);
            this.Approve.Activities.Add(this.IFCheckPerubahanNama);
            this.Approve.Activities.Add(this.IfCheckPerubahanModal);
            this.Approve.Activities.Add(this.PopulateDataPicCorsec4);
            this.Approve.Activities.Add(this.SetPermissionPicCorsec4);
            this.Approve.Activities.Add(this.createMultipleTask_PicCorsec4);
            this.Approve.Activities.Add(this.updateAllTasksPicCorsec4);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.Approve.Condition = codecondition1;
            this.Approve.Name = "Approve";
            // 
            // UpdatePermissionCompleted
            // 
            this.UpdatePermissionCompleted.Name = "UpdatePermissionCompleted";
            this.UpdatePermissionCompleted.ExecuteCode += new System.EventHandler(this.UpdatePermissionCompleted_ExecuteCode);
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.Approve);
            this.ifElseActivity1.Activities.Add(this.Rejected);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // GetCorsecStatus
            // 
            this.GetCorsecStatus.Name = "GetCorsecStatus";
            this.GetCorsecStatus.ExecuteCode += new System.EventHandler(this.GetChiefCorsecStatus_ExecuteCode);
            // 
            // updateAllTasksDivHead
            // 
            this.updateAllTasksDivHead.CorrelationToken = correlationtoken1;
            this.updateAllTasksDivHead.Name = "updateAllTasksDivHead";
            activitybind72.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind72.Path = "updateAllTasksChiefCorsec_TaskProperties1";
            this.updateAllTasksDivHead.MethodInvoking += new System.EventHandler(this.updateAllTasksChiefCorsec_MethodInvoking);
            this.updateAllTasksDivHead.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind72)));
            // 
            // PerubahanAnggaran
            // 
            activitybind73.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind73.Path = "createMultipleTask1___Context1";
            activitybind74.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind74.Path = "createMultipleTask1_AssignedTo1";
            activitybind75.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind75.Path = "createMultipleTask1_Body1";
            activitybind76.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind76.Path = "createMultipleTask1_ContentTypeId1";
            activitybind77.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind77.Path = "createMultipleTask1_ListItemId1";
            this.PerubahanAnggaran.Name = "PerubahanAnggaran";
            activitybind78.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind78.Path = "createMultipleTask1_Subject1";
            activitybind79.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind79.Path = "createMultipleTask1_TaskTitle1";
            activitybind80.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind80.Path = "createMultipleTask1_WFName1";
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind73)));
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind74)));
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind75)));
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind76)));
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind78)));
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind77)));
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind79)));
            this.PerubahanAnggaran.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind80)));
            // 
            // SetPermissionToDivHead
            // 
            this.SetPermissionToDivHead.Name = "SetPermissionToDivHead";
            this.SetPermissionToDivHead.ExecuteCode += new System.EventHandler(this.SetPermissionToChiefCorsec_ExecuteCode);
            // 
            // PopulatedDivHead
            // 
            this.PopulatedDivHead.Name = "PopulatedDivHead";
            this.PopulatedDivHead.ExecuteCode += new System.EventHandler(this.CollectedApproval_ExecuteCode);
            activitybind82.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind82.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind81.Name = "PerubahanAnggaranDasarPerusahaan";
            activitybind81.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind82)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind81)));
            // 
            // PerubahanAnggaranDasarPerusahaan
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.PopulatedDivHead);
            this.Activities.Add(this.SetPermissionToDivHead);
            this.Activities.Add(this.PerubahanAnggaran);
            this.Activities.Add(this.updateAllTasksDivHead);
            this.Activities.Add(this.GetCorsecStatus);
            this.Activities.Add(this.ifElseActivity1);
            this.Activities.Add(this.UpdatePermissionCompleted);
            this.Name = "PerubahanAnggaranDasarPerusahaan";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksPicCorsecPMAPMDN;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask createMultipleTaskPMAPMDN;

        private IfElseBranchActivity ifElseBranchActivity3;

        private IfElseBranchActivity IfPMDN;

        private IfElseActivity ifElseActivity2;

        private CodeActivity PopulatePicCorsec1;

        private CodeActivity GetPMAPMDN;

        private CodeActivity GetPerubahanNamaDanModal;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksPicCorsec4;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksPicFinance;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask createMultipleTask_PicCorsec4;

        private CodeActivity SetPermissionPicCorsec4;

        private CodeActivity PopulateDataPicCorsec4;

        private CodeActivity SetPermissionPicFinance;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask createMultipleTask_PicFinance;

        private CodeActivity PopulateDataPicFinance;

        private IfElseBranchActivity ifElseBranchActivity4;

        private IfElseBranchActivity IsPerubahanModalTrue;

        private IfElseActivity IfCheckPerubahanModal;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity3;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity4;

        private IfElseBranchActivity ifElseBranchActivity2;

        private IfElseBranchActivity IsPerubahanNamaTrue;

        private IfElseActivity IFCheckPerubahanNama;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity2;

        private CodeActivity UpdatePermissionCompleted;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksPicAcc;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask createMultipleTask_PicTax;

        private CodeActivity SetPermissionPicAcc;

        private CodeActivity PopulateDataPicAcc;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksTax;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask createMultipleTask_PicCorsec3;

        private CodeActivity UpdatePermissionTax;

        private CodeActivity PopulateDataTax;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksPicCorsec2;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask createMultipleTask_PicCorsec2;

        private CodeActivity UpdatePermissionPicCorsec2;

        private CodeActivity PopulateDataPicCorsec2;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasks_PicCorsec;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask createMultipleTask_PicCorsec;

        private CodeActivity PopulatePicCorsec;

        private CodeActivity UpdatePermissionPicCorsec;

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailToOriginator;

        private CodeActivity UpdatePermissionRejected;

        private IfElseBranchActivity Rejected;

        private IfElseBranchActivity Approve;

        private IfElseActivity ifElseActivity1;

        private CodeActivity GetCorsecStatus;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTasksDivHead;

        private CorporateSecretary.Workflow.Activity.CreateMultipleTask PerubahanAnggaran;

        private CodeActivity SetPermissionToDivHead;

        private CodeActivity PopulatedDivHead;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;














































































































































































    }
}
