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

namespace SPVisionet.CorporateSecretary.Workflow.PendirianPerusahaanBaruIndonesia
{
    public sealed partial class PendirianPerusahaanBaruIndonesia
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
            System.Workflow.ComponentModel.ActivityBind activitybind72 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind73 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind74 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind75 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind76 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind77 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind78 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind79 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind80 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind81 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind82 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind83 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind84 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind85 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind86 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind87 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind88 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind89 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind90 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind91 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind92 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind94 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind93 = new System.Workflow.ComponentModel.ActivityBind();
            this.GetTax2ActionData = new System.Workflow.Activities.CodeActivity();
            this.UpdateAllTax2Tasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createTax2Task = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionTax2 = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataTax2 = new System.Workflow.Activities.CodeActivity();
            this.GetTaxActionData = new System.Workflow.Activities.CodeActivity();
            this.updateAllTaxTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createTaxTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionTax = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataTax = new System.Workflow.Activities.CodeActivity();
            this.updateAllPICCorsec3Tasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createPICCorsec3Task = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionPICCorsec3 = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPICCorsec3 = new System.Workflow.Activities.CodeActivity();
            this.GetFinanceActionData = new System.Workflow.Activities.CodeActivity();
            this.updateAllFinancTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createFinanceTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionFinance = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataFinance = new System.Workflow.Activities.CodeActivity();
            this.GetAccountingStaffActionData = new System.Workflow.Activities.CodeActivity();
            this.updateAllAccountingTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createAccountingTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionAccounting = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataAccounting = new System.Workflow.Activities.CodeActivity();
            this.GetAccountingHeadActionData = new System.Workflow.Activities.CodeActivity();
            this.updateAllAccountingHeadTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createAccountingHeadTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionAccountingHead = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataAccountingHead = new System.Workflow.Activities.CodeActivity();
            this.updateAllPICCorsec2Tasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createPICCorsec2Task = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionPICCorsec2 = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPICCorsec2 = new System.Workflow.Activities.CodeActivity();
            this.updateAllPICCorsec1Tasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createPICCorsec1Task = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionPICCorsec1 = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPICCorsec1 = new System.Workflow.Activities.CodeActivity();
            this.ChiefCorsecReject = new System.Workflow.Activities.IfElseBranchActivity();
            this.ChiefCorsecApprove = new System.Workflow.Activities.IfElseBranchActivity();
            this.sendEmailReject = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.UpdatePermissionReject = new System.Workflow.Activities.CodeActivity();
            this.SendMailApprove = new System.Workflow.Activities.CodeActivity();
            this.UpdatePermissionApprove = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity2 = new System.Workflow.Activities.IfElseActivity();
            this.GetChiefCorsecApprovalStatus = new System.Workflow.Activities.CodeActivity();
            this.updateAllChiefCorsecTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createChiefCorsecTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionChiefCorsec = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataChiefCorsec = new System.Workflow.Activities.CodeActivity();
            this.Reject = new System.Workflow.Activities.IfElseBranchActivity();
            this.Approve = new System.Workflow.Activities.IfElseBranchActivity();
            this.DeptHeadReject = new System.Workflow.Activities.IfElseBranchActivity();
            this.DeptHeadApprove = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity4 = new System.Workflow.Activities.IfElseActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.GetDeptHeadApprovalStatus = new System.Workflow.Activities.CodeActivity();
            this.updateAllDeptHeadTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createDeptHeadTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionDeptHead = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataDeptHead = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // GetTax2ActionData
            // 
            this.GetTax2ActionData.Name = "GetTax2ActionData";
            this.GetTax2ActionData.ExecuteCode += new System.EventHandler(this.GetTax2ActionData_ExecuteCode);
            // 
            // UpdateAllTax2Tasks
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "PendirianPerusahaanBaruIndonesia";
            this.UpdateAllTax2Tasks.CorrelationToken = correlationtoken1;
            this.UpdateAllTax2Tasks.Name = "UpdateAllTax2Tasks";
            activitybind1.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind1.Path = "UpdateAllTax2Tasks_TaskProperties1";
            this.UpdateAllTax2Tasks.MethodInvoking += new System.EventHandler(this.UpdateAllTax2Tasks_MethodInvoking);
            this.UpdateAllTax2Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // createTax2Task
            // 
            activitybind2.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind2.Path = "createTax2Task___Context1";
            activitybind3.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind3.Path = "createTax2Task_AssignedTo1";
            activitybind4.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind4.Path = "createTax2Task_Body1";
            activitybind5.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind5.Path = "createTax2Task_ContentTypeId1";
            activitybind6.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind6.Path = "createTax2Task_ListItemId1";
            this.createTax2Task.Name = "createTax2Task";
            activitybind7.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind7.Path = "createTax2Task_Subject1";
            activitybind8.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind8.Path = "createTax2Task_TaskTitle1";
            activitybind9.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind9.Path = "createTax2Task_WFName1";
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // UpdatePermissionTax2
            // 
            this.UpdatePermissionTax2.Name = "UpdatePermissionTax2";
            this.UpdatePermissionTax2.ExecuteCode += new System.EventHandler(this.UpdatePermissionTax2_ExecuteCode);
            // 
            // PopulateDataTax2
            // 
            this.PopulateDataTax2.Name = "PopulateDataTax2";
            this.PopulateDataTax2.ExecuteCode += new System.EventHandler(this.PopulateDataTax2_ExecuteCode);
            // 
            // GetTaxActionData
            // 
            this.GetTaxActionData.Name = "GetTaxActionData";
            this.GetTaxActionData.ExecuteCode += new System.EventHandler(this.GetTaxActionData_ExecuteCode);
            // 
            // updateAllTaxTasks
            // 
            this.updateAllTaxTasks.CorrelationToken = correlationtoken1;
            this.updateAllTaxTasks.Name = "updateAllTaxTasks";
            activitybind10.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind10.Path = "updateAllTaxTasks_TaskProperties1";
            this.updateAllTaxTasks.MethodInvoking += new System.EventHandler(this.updateAllTaxTasks_MethodInvoking);
            this.updateAllTaxTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // createTaxTask
            // 
            activitybind11.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind11.Path = "createTaxTask___Context1";
            activitybind12.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind12.Path = "createTaxTask_AssignedTo1";
            activitybind13.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind13.Path = "createTaxTask_Body1";
            activitybind14.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind14.Path = "createTaxTask_ContentTypeId1";
            activitybind15.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind15.Path = "createTaxTask_ListItemId1";
            this.createTaxTask.Name = "createTaxTask";
            activitybind16.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind16.Path = "createTaxTask_Subject1";
            activitybind17.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind17.Path = "createTaxTask_TaskTitle1";
            activitybind18.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind18.Path = "createTaxTask_WFName1";
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            // 
            // UpdatePermissionTax
            // 
            this.UpdatePermissionTax.Name = "UpdatePermissionTax";
            this.UpdatePermissionTax.ExecuteCode += new System.EventHandler(this.UpdatePermissionTax_ExecuteCode);
            // 
            // PopulateDataTax
            // 
            this.PopulateDataTax.Name = "PopulateDataTax";
            this.PopulateDataTax.ExecuteCode += new System.EventHandler(this.PopulateDataTax_ExecuteCode);
            // 
            // updateAllPICCorsec3Tasks
            // 
            this.updateAllPICCorsec3Tasks.CorrelationToken = correlationtoken1;
            this.updateAllPICCorsec3Tasks.Name = "updateAllPICCorsec3Tasks";
            activitybind19.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind19.Path = "updateAllPICCorsec3Tasks_TaskProperties1";
            this.updateAllPICCorsec3Tasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsec3Tasks_MethodInvoking);
            this.updateAllPICCorsec3Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            // 
            // createPICCorsec3Task
            // 
            activitybind20.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind20.Path = "createPICCorsec3Task___Context1";
            activitybind21.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind21.Path = "createPICCorsec3Task_AssignedTo1";
            activitybind22.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind22.Path = "createPICCorsec3Task_Body1";
            activitybind23.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind23.Path = "createPICCorsec3Task_ContentTypeId1";
            activitybind24.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind24.Path = "createPICCorsec3Task_ListItemId1";
            this.createPICCorsec3Task.Name = "createPICCorsec3Task";
            activitybind25.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind25.Path = "createPICCorsec3Task_Subject1";
            activitybind26.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind26.Path = "createPICCorsec3Task_TaskTitle1";
            activitybind27.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind27.Path = "createPICCorsec3Task_WFName1";
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            // 
            // UpdatePermissionPICCorsec3
            // 
            this.UpdatePermissionPICCorsec3.Name = "UpdatePermissionPICCorsec3";
            this.UpdatePermissionPICCorsec3.ExecuteCode += new System.EventHandler(this.UpdatePermissionPICCorsec3_ExecuteCode);
            // 
            // PopulateDataPICCorsec3
            // 
            this.PopulateDataPICCorsec3.Name = "PopulateDataPICCorsec3";
            this.PopulateDataPICCorsec3.ExecuteCode += new System.EventHandler(this.PopulateDataPICCorsec3_ExecuteCode);
            // 
            // GetFinanceActionData
            // 
            this.GetFinanceActionData.Name = "GetFinanceActionData";
            this.GetFinanceActionData.ExecuteCode += new System.EventHandler(this.GetFinanceActionData_ExecuteCode);
            // 
            // updateAllFinancTasks
            // 
            this.updateAllFinancTasks.CorrelationToken = correlationtoken1;
            this.updateAllFinancTasks.Name = "updateAllFinancTasks";
            activitybind28.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind28.Path = "updateAllFinancTasks_TaskProperties1";
            this.updateAllFinancTasks.MethodInvoking += new System.EventHandler(this.updateAllFinancTasks_MethodInvoking);
            this.updateAllFinancTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            // 
            // createFinanceTask
            // 
            activitybind29.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind29.Path = "createFinanceTask___Context1";
            activitybind30.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind30.Path = "createFinanceTask_AssignedTo1";
            activitybind31.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind31.Path = "createFinanceTask_Body1";
            activitybind32.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind32.Path = "createFinanceTask_ContentTypeId1";
            activitybind33.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind33.Path = "createFinanceTask_ListItemId1";
            this.createFinanceTask.Name = "createFinanceTask";
            activitybind34.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind34.Path = "createFinanceTask_Subject1";
            activitybind35.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind35.Path = "createFinanceTask_TaskTitle1";
            activitybind36.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind36.Path = "createFinanceTask_WFName1";
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind29)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind30)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind31)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind32)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind33)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind34)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind35)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind36)));
            // 
            // UpdatePermissionFinance
            // 
            this.UpdatePermissionFinance.Name = "UpdatePermissionFinance";
            this.UpdatePermissionFinance.ExecuteCode += new System.EventHandler(this.UpdatePermissionFinance_ExecuteCode);
            // 
            // PopulateDataFinance
            // 
            this.PopulateDataFinance.Name = "PopulateDataFinance";
            this.PopulateDataFinance.ExecuteCode += new System.EventHandler(this.PopulateDataFinance_ExecuteCode);
            // 
            // GetAccountingStaffActionData
            // 
            this.GetAccountingStaffActionData.Name = "GetAccountingStaffActionData";
            this.GetAccountingStaffActionData.ExecuteCode += new System.EventHandler(this.GetAccountingStaffActionData_ExecuteCode);
            // 
            // updateAllAccountingTasks
            // 
            this.updateAllAccountingTasks.CorrelationToken = correlationtoken1;
            this.updateAllAccountingTasks.Name = "updateAllAccountingTasks";
            activitybind37.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind37.Path = "updateAllAccountingTasks_TaskProperties1";
            this.updateAllAccountingTasks.MethodInvoking += new System.EventHandler(this.updateAllAccountingTasks_MethodInvoking);
            this.updateAllAccountingTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind37)));
            // 
            // createAccountingTask
            // 
            activitybind38.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind38.Path = "createAccountingTask___Context1";
            activitybind39.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind39.Path = "createAccountingTask_AssignedTo1";
            activitybind40.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind40.Path = "createAccountingTask_Body1";
            activitybind41.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind41.Path = "createAccountingTask_ContentTypeId1";
            activitybind42.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind42.Path = "createAccountingTask_ListItemId1";
            this.createAccountingTask.Name = "createAccountingTask";
            activitybind43.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind43.Path = "createAccountingTask_Subject1";
            activitybind44.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind44.Path = "createAccountingTask_TaskTitle1";
            activitybind45.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind45.Path = "createAccountingTask_WFName1";
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind38)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind39)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind40)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind41)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind42)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind43)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind44)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind45)));
            // 
            // UpdatePermissionAccounting
            // 
            this.UpdatePermissionAccounting.Name = "UpdatePermissionAccounting";
            this.UpdatePermissionAccounting.ExecuteCode += new System.EventHandler(this.UpdatePermissionAccounting_ExecuteCode);
            // 
            // PopulateDataAccounting
            // 
            this.PopulateDataAccounting.Name = "PopulateDataAccounting";
            this.PopulateDataAccounting.ExecuteCode += new System.EventHandler(this.PopulateDataAccounting_ExecuteCode);
            // 
            // GetAccountingHeadActionData
            // 
            this.GetAccountingHeadActionData.Name = "GetAccountingHeadActionData";
            this.GetAccountingHeadActionData.ExecuteCode += new System.EventHandler(this.GetAccountingHeadActionData_ExecuteCode);
            // 
            // updateAllAccountingHeadTasks
            // 
            this.updateAllAccountingHeadTasks.CorrelationToken = correlationtoken1;
            this.updateAllAccountingHeadTasks.Name = "updateAllAccountingHeadTasks";
            activitybind46.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind46.Path = "updateAllAccountingHeadTasks_TaskProperties1";
            this.updateAllAccountingHeadTasks.MethodInvoking += new System.EventHandler(this.updateAllAccountingHeadTasks_MethodInvoking);
            this.updateAllAccountingHeadTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind46)));
            // 
            // createAccountingHeadTask
            // 
            activitybind47.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind47.Path = "createAccountingHeadTask___Context1";
            activitybind48.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind48.Path = "createAccountingHeadTask_AssignedTo1";
            activitybind49.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind49.Path = "createAccountingHeadTask_Body1";
            activitybind50.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind50.Path = "createAccountingHeadTask_ContentTypeId1";
            activitybind51.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind51.Path = "createAccountingHeadTask_ListItemId1";
            this.createAccountingHeadTask.Name = "createAccountingHeadTask";
            activitybind52.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind52.Path = "createAccountingHeadTask_Subject1";
            activitybind53.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind53.Path = "createAccountingHeadTask_TaskTitle1";
            activitybind54.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind54.Path = "createAccountingHeadTask_WFName1";
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind47)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind48)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind49)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind50)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind51)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind52)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind53)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind54)));
            // 
            // UpdatePermissionAccountingHead
            // 
            this.UpdatePermissionAccountingHead.Name = "UpdatePermissionAccountingHead";
            this.UpdatePermissionAccountingHead.ExecuteCode += new System.EventHandler(this.UpdatePermissionAccountingHead_ExecuteCode);
            // 
            // PopulateDataAccountingHead
            // 
            this.PopulateDataAccountingHead.Name = "PopulateDataAccountingHead";
            this.PopulateDataAccountingHead.ExecuteCode += new System.EventHandler(this.PopulateDataAccountingHead_ExecuteCode);
            // 
            // updateAllPICCorsec2Tasks
            // 
            this.updateAllPICCorsec2Tasks.CorrelationToken = correlationtoken1;
            this.updateAllPICCorsec2Tasks.Name = "updateAllPICCorsec2Tasks";
            activitybind55.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind55.Path = "updateAllPICCorsec2Tasks_TaskProperties1";
            this.updateAllPICCorsec2Tasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsec2Tasks_MethodInvoking);
            this.updateAllPICCorsec2Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind55)));
            // 
            // createPICCorsec2Task
            // 
            activitybind56.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind56.Path = "createPICCorsec2Task___Context1";
            activitybind57.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind57.Path = "createPICCorsec2Task_AssignedTo1";
            activitybind58.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind58.Path = "createPICCorsec2Task_Body1";
            activitybind59.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind59.Path = "createPICCorsec2Task_ContentTypeId1";
            activitybind60.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind60.Path = "createPICCorsec2Task_ListItemId1";
            this.createPICCorsec2Task.Name = "createPICCorsec2Task";
            activitybind61.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind61.Path = "createPICCorsec2Task_Subject1";
            activitybind62.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind62.Path = "createPICCorsec2Task_TaskTitle1";
            activitybind63.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind63.Path = "createPICCorsec2Task_WFName1";
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind56)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind57)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind58)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind59)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind60)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind61)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind62)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind63)));
            // 
            // UpdatePermissionPICCorsec2
            // 
            this.UpdatePermissionPICCorsec2.Name = "UpdatePermissionPICCorsec2";
            this.UpdatePermissionPICCorsec2.ExecuteCode += new System.EventHandler(this.UpdatePermissionPICCorsec2_ExecuteCode);
            // 
            // PopulateDataPICCorsec2
            // 
            this.PopulateDataPICCorsec2.Name = "PopulateDataPICCorsec2";
            this.PopulateDataPICCorsec2.ExecuteCode += new System.EventHandler(this.PopulateDataPICCorsec2_ExecuteCode);
            // 
            // updateAllPICCorsec1Tasks
            // 
            this.updateAllPICCorsec1Tasks.CorrelationToken = correlationtoken1;
            this.updateAllPICCorsec1Tasks.Name = "updateAllPICCorsec1Tasks";
            activitybind64.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind64.Path = "updateAllPICCorsec1Tasks_TaskProperties1";
            this.updateAllPICCorsec1Tasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsec1Tasks_MethodInvoking);
            this.updateAllPICCorsec1Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind64)));
            // 
            // createPICCorsec1Task
            // 
            activitybind65.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind65.Path = "createPICCorsec1Task___Context1";
            activitybind66.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind66.Path = "createPICCorsec1Task_AssignedTo1";
            activitybind67.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind67.Path = "createPICCorsec1Task_Body1";
            activitybind68.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind68.Path = "createPICCorsec1Task_ContentTypeId1";
            activitybind69.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind69.Path = "createPICCorsec1Task_ListItemId1";
            this.createPICCorsec1Task.Name = "createPICCorsec1Task";
            activitybind70.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind70.Path = "createPICCorsec1Task_Subject1";
            activitybind71.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind71.Path = "createPICCorsec1Task_TaskTitle1";
            activitybind72.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind72.Path = "createPICCorsec1Task_WFName1";
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind65)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind66)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind67)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind68)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind69)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind70)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind71)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind72)));
            // 
            // UpdatePermissionPICCorsec1
            // 
            this.UpdatePermissionPICCorsec1.Name = "UpdatePermissionPICCorsec1";
            this.UpdatePermissionPICCorsec1.ExecuteCode += new System.EventHandler(this.UpdatePermissionPICCorsec1_ExecuteCode);
            // 
            // PopulateDataPICCorsec1
            // 
            this.PopulateDataPICCorsec1.Name = "PopulateDataPICCorsec1";
            this.PopulateDataPICCorsec1.ExecuteCode += new System.EventHandler(this.PopulateDataPICCorsec1_ExecuteCode);
            // 
            // ChiefCorsecReject
            // 
            this.ChiefCorsecReject.Name = "ChiefCorsecReject";
            // 
            // ChiefCorsecApprove
            // 
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataPICCorsec1);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionPICCorsec1);
            this.ChiefCorsecApprove.Activities.Add(this.createPICCorsec1Task);
            this.ChiefCorsecApprove.Activities.Add(this.updateAllPICCorsec1Tasks);
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataPICCorsec2);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionPICCorsec2);
            this.ChiefCorsecApprove.Activities.Add(this.createPICCorsec2Task);
            this.ChiefCorsecApprove.Activities.Add(this.updateAllPICCorsec2Tasks);
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataAccountingHead);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionAccountingHead);
            this.ChiefCorsecApprove.Activities.Add(this.createAccountingHeadTask);
            this.ChiefCorsecApprove.Activities.Add(this.updateAllAccountingHeadTasks);
            this.ChiefCorsecApprove.Activities.Add(this.GetAccountingHeadActionData);
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataAccounting);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionAccounting);
            this.ChiefCorsecApprove.Activities.Add(this.createAccountingTask);
            this.ChiefCorsecApprove.Activities.Add(this.updateAllAccountingTasks);
            this.ChiefCorsecApprove.Activities.Add(this.GetAccountingStaffActionData);
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataFinance);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionFinance);
            this.ChiefCorsecApprove.Activities.Add(this.createFinanceTask);
            this.ChiefCorsecApprove.Activities.Add(this.updateAllFinancTasks);
            this.ChiefCorsecApprove.Activities.Add(this.GetFinanceActionData);
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataPICCorsec3);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionPICCorsec3);
            this.ChiefCorsecApprove.Activities.Add(this.createPICCorsec3Task);
            this.ChiefCorsecApprove.Activities.Add(this.updateAllPICCorsec3Tasks);
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataTax);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionTax);
            this.ChiefCorsecApprove.Activities.Add(this.createTaxTask);
            this.ChiefCorsecApprove.Activities.Add(this.updateAllTaxTasks);
            this.ChiefCorsecApprove.Activities.Add(this.GetTaxActionData);
            this.ChiefCorsecApprove.Activities.Add(this.PopulateDataTax2);
            this.ChiefCorsecApprove.Activities.Add(this.UpdatePermissionTax2);
            this.ChiefCorsecApprove.Activities.Add(this.createTax2Task);
            this.ChiefCorsecApprove.Activities.Add(this.UpdateAllTax2Tasks);
            this.ChiefCorsecApprove.Activities.Add(this.GetTax2ActionData);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.ChiefCorsecApprove.Condition = codecondition1;
            this.ChiefCorsecApprove.Name = "ChiefCorsecApprove";
            // 
            // sendEmailReject
            // 
            this.sendEmailReject.BCC = null;
            activitybind73.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind73.Path = "sendEmailReject_Body1";
            this.sendEmailReject.CC = null;
            this.sendEmailReject.CorrelationToken = correlationtoken1;
            this.sendEmailReject.From = null;
            activitybind74.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind74.Path = "sendEmailReject_Headers1";
            this.sendEmailReject.IncludeStatus = false;
            this.sendEmailReject.Name = "sendEmailReject";
            this.sendEmailReject.Subject = null;
            this.sendEmailReject.To = null;
            this.sendEmailReject.MethodInvoking += new System.EventHandler(this.sendEmailReject_MethodInvoking);
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind74)));
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind73)));
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
            this.ifElseActivity2.Activities.Add(this.ChiefCorsecApprove);
            this.ifElseActivity2.Activities.Add(this.ChiefCorsecReject);
            this.ifElseActivity2.Name = "ifElseActivity2";
            // 
            // GetChiefCorsecApprovalStatus
            // 
            this.GetChiefCorsecApprovalStatus.Name = "GetChiefCorsecApprovalStatus";
            this.GetChiefCorsecApprovalStatus.ExecuteCode += new System.EventHandler(this.GetChiefCorsecApprovalStatus_ExecuteCode);
            // 
            // updateAllChiefCorsecTasks
            // 
            this.updateAllChiefCorsecTasks.CorrelationToken = correlationtoken1;
            this.updateAllChiefCorsecTasks.Name = "updateAllChiefCorsecTasks";
            activitybind75.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind75.Path = "updateAllChiefCorsecTasks_TaskProperties1";
            this.updateAllChiefCorsecTasks.MethodInvoking += new System.EventHandler(this.updateAllChiefCorsecTasks_MethodInvoking);
            this.updateAllChiefCorsecTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind75)));
            // 
            // createChiefCorsecTask
            // 
            activitybind76.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind76.Path = "createChiefCorsecTask___Context1";
            activitybind77.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind77.Path = "createChiefCorsecTask_AssignedTo1";
            activitybind78.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind78.Path = "createChiefCorsecTask_Body1";
            activitybind79.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind79.Path = "createChiefCorsecTask_ContentTypeId1";
            activitybind80.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind80.Path = "createChiefCorsecTask_ListItemId1";
            this.createChiefCorsecTask.Name = "createChiefCorsecTask";
            activitybind81.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind81.Path = "createChiefCorsecTask_Subject1";
            activitybind82.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind82.Path = "createChiefCorsecTask_TaskTitle1";
            activitybind83.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind83.Path = "createChiefCorsecTask_WFName1";
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind76)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind77)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind78)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind79)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind80)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind81)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind82)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind83)));
            // 
            // UpdatePermissionChiefCorsec
            // 
            this.UpdatePermissionChiefCorsec.Name = "UpdatePermissionChiefCorsec";
            this.UpdatePermissionChiefCorsec.ExecuteCode += new System.EventHandler(this.UpdatePermissionChiefCorsec_ExecuteCode);
            // 
            // PopulateDataChiefCorsec
            // 
            this.PopulateDataChiefCorsec.Name = "PopulateDataChiefCorsec";
            this.PopulateDataChiefCorsec.ExecuteCode += new System.EventHandler(this.PopulateDataChiefCorsec_ExecuteCode);
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
            // DeptHeadReject
            // 
            this.DeptHeadReject.Name = "DeptHeadReject";
            // 
            // DeptHeadApprove
            // 
            this.DeptHeadApprove.Activities.Add(this.PopulateDataChiefCorsec);
            this.DeptHeadApprove.Activities.Add(this.UpdatePermissionChiefCorsec);
            this.DeptHeadApprove.Activities.Add(this.createChiefCorsecTask);
            this.DeptHeadApprove.Activities.Add(this.updateAllChiefCorsecTasks);
            this.DeptHeadApprove.Activities.Add(this.GetChiefCorsecApprovalStatus);
            this.DeptHeadApprove.Activities.Add(this.ifElseActivity2);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.DeptHeadApprove.Condition = codecondition3;
            this.DeptHeadApprove.Name = "DeptHeadApprove";
            // 
            // ifElseActivity4
            // 
            this.ifElseActivity4.Activities.Add(this.Approve);
            this.ifElseActivity4.Activities.Add(this.Reject);
            this.ifElseActivity4.Name = "ifElseActivity4";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.DeptHeadApprove);
            this.ifElseActivity1.Activities.Add(this.DeptHeadReject);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // GetDeptHeadApprovalStatus
            // 
            this.GetDeptHeadApprovalStatus.Name = "GetDeptHeadApprovalStatus";
            this.GetDeptHeadApprovalStatus.ExecuteCode += new System.EventHandler(this.GetDeptHeadApprovalStatus_ExecuteCode);
            // 
            // updateAllDeptHeadTasks
            // 
            this.updateAllDeptHeadTasks.CorrelationToken = correlationtoken1;
            this.updateAllDeptHeadTasks.Name = "updateAllDeptHeadTasks";
            activitybind84.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind84.Path = "updateAllDeptHeadTasks_TaskProperties1";
            this.updateAllDeptHeadTasks.MethodInvoking += new System.EventHandler(this.updateAllDeptHeadTasks_MethodInvoking);
            this.updateAllDeptHeadTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind84)));
            // 
            // createDeptHeadTask
            // 
            activitybind85.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind85.Path = "createDeptHeadTask___Context1";
            activitybind86.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind86.Path = "createDeptHeadTask_AssignedTo1";
            activitybind87.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind87.Path = "createDeptHeadTask_Body1";
            activitybind88.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind88.Path = "createDeptHeadTask_ContentTypeId1";
            activitybind89.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind89.Path = "createDeptHeadTask_ListItemId1";
            this.createDeptHeadTask.Name = "createDeptHeadTask";
            activitybind90.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind90.Path = "createDeptHeadTask_Subject1";
            activitybind91.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind91.Path = "createDeptHeadTask_TaskTitle1";
            activitybind92.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind92.Path = "createDeptHeadTask_WFName1";
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind85)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind86)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind87)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind88)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind89)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind90)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind91)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind92)));
            // 
            // UpdatePermissionDeptHead
            // 
            this.UpdatePermissionDeptHead.Name = "UpdatePermissionDeptHead";
            this.UpdatePermissionDeptHead.ExecuteCode += new System.EventHandler(this.UpdatePermissionDeptHead_ExecuteCode);
            // 
            // PopulateDataDeptHead
            // 
            this.PopulateDataDeptHead.Name = "PopulateDataDeptHead";
            this.PopulateDataDeptHead.ExecuteCode += new System.EventHandler(this.PopulateDataDeptHead_ExecuteCode);
            activitybind94.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind94.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind93.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind93.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind94)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind93)));
            // 
            // PendirianPerusahaanBaruIndonesia
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.PopulateDataDeptHead);
            this.Activities.Add(this.UpdatePermissionDeptHead);
            this.Activities.Add(this.createDeptHeadTask);
            this.Activities.Add(this.updateAllDeptHeadTasks);
            this.Activities.Add(this.GetDeptHeadApprovalStatus);
            this.Activities.Add(this.ifElseActivity1);
            this.Activities.Add(this.ifElseActivity4);
            this.Name = "PendirianPerusahaanBaruIndonesia";
            this.CanModifyActivities = false;

        }

        #endregion

        private Activity.CreateMultipleTask createTax2Task;

        private CodeActivity UpdatePermissionTax2;

        private CodeActivity PopulateDataTax2;

        private CodeActivity GetTax2ActionData;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks UpdateAllTax2Tasks;

        private CodeActivity GetFinanceActionData;

        private CodeActivity GetAccountingStaffActionData;

        private CodeActivity GetAccountingHeadActionData;

        private CodeActivity GetTaxActionData;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllAccountingHeadTasks;

        private Activity.CreateMultipleTask createAccountingHeadTask;

        private CodeActivity UpdatePermissionAccountingHead;

        private CodeActivity PopulateDataAccountingHead;

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailReject;

        private CodeActivity UpdatePermissionReject;

        private CodeActivity SendMailApprove;

        private CodeActivity UpdatePermissionApprove;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllPICCorsec3Tasks;

        private Activity.CreateMultipleTask createPICCorsec3Task;

        private CodeActivity UpdatePermissionPICCorsec3;

        private CodeActivity PopulateDataPICCorsec3;

        private IfElseBranchActivity Reject;

        private IfElseBranchActivity Approve;

        private IfElseActivity ifElseActivity4;

        private CodeActivity UpdatePermissionFinance;

        private CodeActivity PopulateDataFinance;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllFinancTasks;

        private Activity.CreateMultipleTask createFinanceTask;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllPICCorsec2Tasks;

        private Activity.CreateMultipleTask createPICCorsec2Task;

        private CodeActivity UpdatePermissionPICCorsec2;

        private CodeActivity PopulateDataPICCorsec2;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllAccountingTasks;

        private Activity.CreateMultipleTask createAccountingTask;

        private CodeActivity UpdatePermissionAccounting;

        private CodeActivity PopulateDataAccounting;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllTaxTasks;

        private Activity.CreateMultipleTask createTaxTask;

        private CodeActivity UpdatePermissionTax;

        private CodeActivity PopulateDataTax;

        private CodeActivity PopulateDataPICCorsec1;

        private CodeActivity UpdatePermissionPICCorsec1;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllPICCorsec1Tasks;

        private Activity.CreateMultipleTask createPICCorsec1Task;

        private IfElseBranchActivity ChiefCorsecReject;

        private IfElseBranchActivity ChiefCorsecApprove;

        private IfElseActivity ifElseActivity2;

        private CodeActivity GetChiefCorsecApprovalStatus;

        private IfElseBranchActivity DeptHeadReject;

        private IfElseBranchActivity DeptHeadApprove;

        private IfElseActivity ifElseActivity1;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllChiefCorsecTasks;

        private Activity.CreateMultipleTask createChiefCorsecTask;

        private CodeActivity UpdatePermissionChiefCorsec;

        private CodeActivity PopulateDataChiefCorsec;

        private CodeActivity GetDeptHeadApprovalStatus;

        private Activity.CreateMultipleTask createDeptHeadTask;

        private CodeActivity UpdatePermissionDeptHead;

        private CodeActivity PopulateDataDeptHead;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllDeptHeadTasks;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;
















































































































































































    }
}
