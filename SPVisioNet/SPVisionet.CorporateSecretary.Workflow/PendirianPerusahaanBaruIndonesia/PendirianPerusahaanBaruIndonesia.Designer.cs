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
            System.Workflow.ComponentModel.ActivityBind activitybind84 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind85 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind86 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind87 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind88 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind89 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind90 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind91 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind92 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind93 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind94 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind95 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind96 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind97 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind98 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind99 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind100 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind101 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind102 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind103 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind104 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind105 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind106 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind107 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind108 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind109 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind110 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition4 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind111 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind112 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind113 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind114 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind115 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind116 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind117 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind118 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind119 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind121 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind120 = new System.Workflow.ComponentModel.ActivityBind();
            this.GetAccActionData = new System.Workflow.Activities.CodeActivity();
            this.updateAccAllTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createAccTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionAcc = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataAcc = new System.Workflow.Activities.CodeActivity();
            this.GetAccHeadActionData = new System.Workflow.Activities.CodeActivity();
            this.updateAllAccHeadTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createAccHeadTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionAccHead = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataAccHead = new System.Workflow.Activities.CodeActivity();
            this.updateAllPICCorsecTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createPICCorsecTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionPICCorsec = new System.Workflow.Activities.CodeActivity();
            this.PopulateDataPICCorsec = new System.Workflow.Activities.CodeActivity();
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
            this.PembelianPerusahaan = new System.Workflow.Activities.IfElseBranchActivity();
            this.PendirianPerusahaan = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity3 = new System.Workflow.Activities.IfElseActivity();
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
            // GetAccActionData
            // 
            this.GetAccActionData.Name = "GetAccActionData";
            this.GetAccActionData.ExecuteCode += new System.EventHandler(this.GetAccActionData_ExecuteCode);
            // 
            // updateAccAllTasks
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "PendirianPerusahaanBaruIndonesia";
            this.updateAccAllTasks.CorrelationToken = correlationtoken1;
            this.updateAccAllTasks.Name = "updateAccAllTasks";
            activitybind1.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind1.Path = "updateAccAllTasks_TaskProperties1";
            this.updateAccAllTasks.MethodInvoking += new System.EventHandler(this.updateAccAllTasks_MethodInvoking);
            this.updateAccAllTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // createAccTask
            // 
            activitybind2.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind2.Path = "createAccTask___Context1";
            activitybind3.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind3.Path = "createAccTask_AssignedTo1";
            activitybind4.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind4.Path = "createAccTask_Body1";
            activitybind5.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind5.Path = "createAccTask_ContentTypeId1";
            activitybind6.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind6.Path = "createAccTask_ListItemId1";
            this.createAccTask.Name = "createAccTask";
            activitybind7.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind7.Path = "createAccTask_Subject1";
            activitybind8.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind8.Path = "createAccTask_TaskTitle1";
            activitybind9.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind9.Path = "createAccTask_WFName1";
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.createAccTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            // 
            // UpdatePermissionAcc
            // 
            this.UpdatePermissionAcc.Name = "UpdatePermissionAcc";
            this.UpdatePermissionAcc.ExecuteCode += new System.EventHandler(this.UpdatePermissionAcc_ExecuteCode);
            // 
            // PopulateDataAcc
            // 
            this.PopulateDataAcc.Name = "PopulateDataAcc";
            this.PopulateDataAcc.ExecuteCode += new System.EventHandler(this.PopulateDataAcc_ExecuteCode);
            // 
            // GetAccHeadActionData
            // 
            this.GetAccHeadActionData.Name = "GetAccHeadActionData";
            this.GetAccHeadActionData.ExecuteCode += new System.EventHandler(this.GetAccHeadActionData_ExecuteCode);
            // 
            // updateAllAccHeadTasks
            // 
            this.updateAllAccHeadTasks.CorrelationToken = correlationtoken1;
            this.updateAllAccHeadTasks.Name = "updateAllAccHeadTasks";
            activitybind10.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind10.Path = "updateAllAccHeadTasks_TaskProperties1";
            this.updateAllAccHeadTasks.MethodInvoking += new System.EventHandler(this.updateAllAccHeadTasks_MethodInvoking);
            this.updateAllAccHeadTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // createAccHeadTask
            // 
            activitybind11.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind11.Path = "createAccHeadTask___Context1";
            activitybind12.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind12.Path = "createAccHeadTask_AssignedTo1";
            activitybind13.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind13.Path = "createAccHeadTask_Body1";
            activitybind14.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind14.Path = "createAccHeadTask_ContentTypeId1";
            activitybind15.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind15.Path = "createAccHeadTask_ListItemId1";
            this.createAccHeadTask.Name = "createAccHeadTask";
            activitybind16.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind16.Path = "createAccHeadTask_Subject1";
            activitybind17.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind17.Path = "createAccHeadTask_TaskTitle1";
            activitybind18.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind18.Path = "createAccHeadTask_WFName1";
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            this.createAccHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            // 
            // UpdatePermissionAccHead
            // 
            this.UpdatePermissionAccHead.Name = "UpdatePermissionAccHead";
            this.UpdatePermissionAccHead.ExecuteCode += new System.EventHandler(this.UpdatePermissionAccHead_ExecuteCode);
            // 
            // PopulateDataAccHead
            // 
            this.PopulateDataAccHead.Name = "PopulateDataAccHead";
            this.PopulateDataAccHead.ExecuteCode += new System.EventHandler(this.PopulateDataAccHead_ExecuteCode);
            // 
            // updateAllPICCorsecTasks
            // 
            this.updateAllPICCorsecTasks.CorrelationToken = correlationtoken1;
            this.updateAllPICCorsecTasks.Name = "updateAllPICCorsecTasks";
            activitybind19.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind19.Path = "updateAllPICCorsecTasks_TaskProperties1";
            this.updateAllPICCorsecTasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsecTasks_MethodInvoking);
            this.updateAllPICCorsecTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            // 
            // createPICCorsecTask
            // 
            activitybind20.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind20.Path = "createPICCorsecTask___Context1";
            activitybind21.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind21.Path = "createPICCorsecTask_AssignedTo1";
            activitybind22.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind22.Path = "createPICCorsecTask_Body1";
            activitybind23.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind23.Path = "createPICCorsecTask_ContentTypeId1";
            activitybind24.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind24.Path = "createPICCorsecTask_ListItemId1";
            this.createPICCorsecTask.Name = "createPICCorsecTask";
            activitybind25.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind25.Path = "createPICCorsecTask_Subject1";
            activitybind26.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind26.Path = "createPICCorsecTask_TaskTitle1";
            activitybind27.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind27.Path = "createPICCorsecTask_WFName1";
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind23)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind24)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind25)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind26)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind27)));
            // 
            // UpdatePermissionPICCorsec
            // 
            this.UpdatePermissionPICCorsec.Name = "UpdatePermissionPICCorsec";
            this.UpdatePermissionPICCorsec.ExecuteCode += new System.EventHandler(this.UpdatePermissionPICCorsec_ExecuteCode);
            // 
            // PopulateDataPICCorsec
            // 
            this.PopulateDataPICCorsec.Name = "PopulateDataPICCorsec";
            this.PopulateDataPICCorsec.ExecuteCode += new System.EventHandler(this.PopulateDataPICCorsec_ExecuteCode);
            // 
            // GetTax2ActionData
            // 
            this.GetTax2ActionData.Name = "GetTax2ActionData";
            this.GetTax2ActionData.ExecuteCode += new System.EventHandler(this.GetTax2ActionData_ExecuteCode);
            // 
            // UpdateAllTax2Tasks
            // 
            this.UpdateAllTax2Tasks.CorrelationToken = correlationtoken1;
            this.UpdateAllTax2Tasks.Name = "UpdateAllTax2Tasks";
            activitybind28.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind28.Path = "UpdateAllTax2Tasks_TaskProperties1";
            this.UpdateAllTax2Tasks.MethodInvoking += new System.EventHandler(this.UpdateAllTax2Tasks_MethodInvoking);
            this.UpdateAllTax2Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind28)));
            // 
            // createTax2Task
            // 
            activitybind29.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind29.Path = "createTax2Task___Context1";
            activitybind30.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind30.Path = "createTax2Task_AssignedTo1";
            activitybind31.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind31.Path = "createTax2Task_Body1";
            activitybind32.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind32.Path = "createTax2Task_ContentTypeId1";
            activitybind33.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind33.Path = "createTax2Task_ListItemId1";
            this.createTax2Task.Name = "createTax2Task";
            activitybind34.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind34.Path = "createTax2Task_Subject1";
            activitybind35.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind35.Path = "createTax2Task_TaskTitle1";
            activitybind36.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind36.Path = "createTax2Task_WFName1";
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind29)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind30)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind31)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind32)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind33)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind34)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind35)));
            this.createTax2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind36)));
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
            activitybind37.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind37.Path = "updateAllTaxTasks_TaskProperties1";
            this.updateAllTaxTasks.MethodInvoking += new System.EventHandler(this.updateAllTaxTasks_MethodInvoking);
            this.updateAllTaxTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind37)));
            // 
            // createTaxTask
            // 
            activitybind38.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind38.Path = "createTaxTask___Context1";
            activitybind39.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind39.Path = "createTaxTask_AssignedTo1";
            activitybind40.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind40.Path = "createTaxTask_Body1";
            activitybind41.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind41.Path = "createTaxTask_ContentTypeId1";
            activitybind42.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind42.Path = "createTaxTask_ListItemId1";
            this.createTaxTask.Name = "createTaxTask";
            activitybind43.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind43.Path = "createTaxTask_Subject1";
            activitybind44.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind44.Path = "createTaxTask_TaskTitle1";
            activitybind45.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind45.Path = "createTaxTask_WFName1";
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind38)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind39)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind40)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind41)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind42)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind43)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind44)));
            this.createTaxTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind45)));
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
            activitybind46.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind46.Path = "updateAllPICCorsec3Tasks_TaskProperties1";
            this.updateAllPICCorsec3Tasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsec3Tasks_MethodInvoking);
            this.updateAllPICCorsec3Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind46)));
            // 
            // createPICCorsec3Task
            // 
            activitybind47.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind47.Path = "createPICCorsec3Task___Context1";
            activitybind48.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind48.Path = "createPICCorsec3Task_AssignedTo1";
            activitybind49.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind49.Path = "createPICCorsec3Task_Body1";
            activitybind50.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind50.Path = "createPICCorsec3Task_ContentTypeId1";
            activitybind51.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind51.Path = "createPICCorsec3Task_ListItemId1";
            this.createPICCorsec3Task.Name = "createPICCorsec3Task";
            activitybind52.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind52.Path = "createPICCorsec3Task_Subject1";
            activitybind53.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind53.Path = "createPICCorsec3Task_TaskTitle1";
            activitybind54.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind54.Path = "createPICCorsec3Task_WFName1";
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind47)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind48)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind49)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind50)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind51)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind52)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind53)));
            this.createPICCorsec3Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind54)));
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
            activitybind55.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind55.Path = "updateAllFinancTasks_TaskProperties1";
            this.updateAllFinancTasks.MethodInvoking += new System.EventHandler(this.updateAllFinancTasks_MethodInvoking);
            this.updateAllFinancTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind55)));
            // 
            // createFinanceTask
            // 
            activitybind56.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind56.Path = "createFinanceTask___Context1";
            activitybind57.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind57.Path = "createFinanceTask_AssignedTo1";
            activitybind58.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind58.Path = "createFinanceTask_Body1";
            activitybind59.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind59.Path = "createFinanceTask_ContentTypeId1";
            activitybind60.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind60.Path = "createFinanceTask_ListItemId1";
            this.createFinanceTask.Name = "createFinanceTask";
            activitybind61.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind61.Path = "createFinanceTask_Subject1";
            activitybind62.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind62.Path = "createFinanceTask_TaskTitle1";
            activitybind63.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind63.Path = "createFinanceTask_WFName1";
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind56)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind57)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind58)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind59)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind60)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind61)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind62)));
            this.createFinanceTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind63)));
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
            activitybind64.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind64.Path = "updateAllAccountingTasks_TaskProperties1";
            this.updateAllAccountingTasks.MethodInvoking += new System.EventHandler(this.updateAllAccountingTasks_MethodInvoking);
            this.updateAllAccountingTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind64)));
            // 
            // createAccountingTask
            // 
            activitybind65.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind65.Path = "createAccountingTask___Context1";
            activitybind66.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind66.Path = "createAccountingTask_AssignedTo1";
            activitybind67.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind67.Path = "createAccountingTask_Body1";
            activitybind68.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind68.Path = "createAccountingTask_ContentTypeId1";
            activitybind69.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind69.Path = "createAccountingTask_ListItemId1";
            this.createAccountingTask.Name = "createAccountingTask";
            activitybind70.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind70.Path = "createAccountingTask_Subject1";
            activitybind71.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind71.Path = "createAccountingTask_TaskTitle1";
            activitybind72.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind72.Path = "createAccountingTask_WFName1";
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind65)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind66)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind67)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind68)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind69)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind70)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind71)));
            this.createAccountingTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind72)));
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
            activitybind73.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind73.Path = "updateAllAccountingHeadTasks_TaskProperties1";
            this.updateAllAccountingHeadTasks.MethodInvoking += new System.EventHandler(this.updateAllAccountingHeadTasks_MethodInvoking);
            this.updateAllAccountingHeadTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind73)));
            // 
            // createAccountingHeadTask
            // 
            activitybind74.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind74.Path = "createAccountingHeadTask___Context1";
            activitybind75.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind75.Path = "createAccountingHeadTask_AssignedTo1";
            activitybind76.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind76.Path = "createAccountingHeadTask_Body1";
            activitybind77.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind77.Path = "createAccountingHeadTask_ContentTypeId1";
            activitybind78.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind78.Path = "createAccountingHeadTask_ListItemId1";
            this.createAccountingHeadTask.Name = "createAccountingHeadTask";
            activitybind79.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind79.Path = "createAccountingHeadTask_Subject1";
            activitybind80.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind80.Path = "createAccountingHeadTask_TaskTitle1";
            activitybind81.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind81.Path = "createAccountingHeadTask_WFName1";
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind74)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind75)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind76)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind77)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind78)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind79)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind80)));
            this.createAccountingHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind81)));
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
            activitybind82.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind82.Path = "updateAllPICCorsec2Tasks_TaskProperties1";
            this.updateAllPICCorsec2Tasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsec2Tasks_MethodInvoking);
            this.updateAllPICCorsec2Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind82)));
            // 
            // createPICCorsec2Task
            // 
            activitybind83.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind83.Path = "createPICCorsec2Task___Context1";
            activitybind84.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind84.Path = "createPICCorsec2Task_AssignedTo1";
            activitybind85.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind85.Path = "createPICCorsec2Task_Body1";
            activitybind86.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind86.Path = "createPICCorsec2Task_ContentTypeId1";
            activitybind87.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind87.Path = "createPICCorsec2Task_ListItemId1";
            this.createPICCorsec2Task.Name = "createPICCorsec2Task";
            activitybind88.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind88.Path = "createPICCorsec2Task_Subject1";
            activitybind89.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind89.Path = "createPICCorsec2Task_TaskTitle1";
            activitybind90.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind90.Path = "createPICCorsec2Task_WFName1";
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind83)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind84)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind85)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind86)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind87)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind88)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind89)));
            this.createPICCorsec2Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind90)));
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
            activitybind91.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind91.Path = "updateAllPICCorsec1Tasks_TaskProperties1";
            this.updateAllPICCorsec1Tasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsec1Tasks_MethodInvoking);
            this.updateAllPICCorsec1Tasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind91)));
            // 
            // createPICCorsec1Task
            // 
            activitybind92.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind92.Path = "createPICCorsec1Task___Context1";
            activitybind93.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind93.Path = "createPICCorsec1Task_AssignedTo1";
            activitybind94.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind94.Path = "createPICCorsec1Task_Body1";
            activitybind95.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind95.Path = "createPICCorsec1Task_ContentTypeId1";
            activitybind96.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind96.Path = "createPICCorsec1Task_ListItemId1";
            this.createPICCorsec1Task.Name = "createPICCorsec1Task";
            activitybind97.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind97.Path = "createPICCorsec1Task_Subject1";
            activitybind98.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind98.Path = "createPICCorsec1Task_TaskTitle1";
            activitybind99.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind99.Path = "createPICCorsec1Task_WFName1";
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind92)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind93)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind94)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind95)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind96)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind97)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind98)));
            this.createPICCorsec1Task.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind99)));
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
            // PembelianPerusahaan
            // 
            this.PembelianPerusahaan.Activities.Add(this.PopulateDataPICCorsec);
            this.PembelianPerusahaan.Activities.Add(this.UpdatePermissionPICCorsec);
            this.PembelianPerusahaan.Activities.Add(this.createPICCorsecTask);
            this.PembelianPerusahaan.Activities.Add(this.updateAllPICCorsecTasks);
            this.PembelianPerusahaan.Activities.Add(this.PopulateDataAccHead);
            this.PembelianPerusahaan.Activities.Add(this.UpdatePermissionAccHead);
            this.PembelianPerusahaan.Activities.Add(this.createAccHeadTask);
            this.PembelianPerusahaan.Activities.Add(this.updateAllAccHeadTasks);
            this.PembelianPerusahaan.Activities.Add(this.GetAccHeadActionData);
            this.PembelianPerusahaan.Activities.Add(this.PopulateDataAcc);
            this.PembelianPerusahaan.Activities.Add(this.UpdatePermissionAcc);
            this.PembelianPerusahaan.Activities.Add(this.createAccTask);
            this.PembelianPerusahaan.Activities.Add(this.updateAccAllTasks);
            this.PembelianPerusahaan.Activities.Add(this.GetAccActionData);
            this.PembelianPerusahaan.Name = "PembelianPerusahaan";
            // 
            // PendirianPerusahaan
            // 
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataPICCorsec1);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionPICCorsec1);
            this.PendirianPerusahaan.Activities.Add(this.createPICCorsec1Task);
            this.PendirianPerusahaan.Activities.Add(this.updateAllPICCorsec1Tasks);
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataPICCorsec2);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionPICCorsec2);
            this.PendirianPerusahaan.Activities.Add(this.createPICCorsec2Task);
            this.PendirianPerusahaan.Activities.Add(this.updateAllPICCorsec2Tasks);
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataAccountingHead);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionAccountingHead);
            this.PendirianPerusahaan.Activities.Add(this.createAccountingHeadTask);
            this.PendirianPerusahaan.Activities.Add(this.updateAllAccountingHeadTasks);
            this.PendirianPerusahaan.Activities.Add(this.GetAccountingHeadActionData);
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataAccounting);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionAccounting);
            this.PendirianPerusahaan.Activities.Add(this.createAccountingTask);
            this.PendirianPerusahaan.Activities.Add(this.updateAllAccountingTasks);
            this.PendirianPerusahaan.Activities.Add(this.GetAccountingStaffActionData);
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataFinance);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionFinance);
            this.PendirianPerusahaan.Activities.Add(this.createFinanceTask);
            this.PendirianPerusahaan.Activities.Add(this.updateAllFinancTasks);
            this.PendirianPerusahaan.Activities.Add(this.GetFinanceActionData);
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataPICCorsec3);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionPICCorsec3);
            this.PendirianPerusahaan.Activities.Add(this.createPICCorsec3Task);
            this.PendirianPerusahaan.Activities.Add(this.updateAllPICCorsec3Tasks);
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataTax);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionTax);
            this.PendirianPerusahaan.Activities.Add(this.createTaxTask);
            this.PendirianPerusahaan.Activities.Add(this.updateAllTaxTasks);
            this.PendirianPerusahaan.Activities.Add(this.GetTaxActionData);
            this.PendirianPerusahaan.Activities.Add(this.PopulateDataTax2);
            this.PendirianPerusahaan.Activities.Add(this.UpdatePermissionTax2);
            this.PendirianPerusahaan.Activities.Add(this.createTax2Task);
            this.PendirianPerusahaan.Activities.Add(this.UpdateAllTax2Tasks);
            this.PendirianPerusahaan.Activities.Add(this.GetTax2ActionData);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.TypeCondition);
            this.PendirianPerusahaan.Condition = codecondition1;
            this.PendirianPerusahaan.Name = "PendirianPerusahaan";
            // 
            // ifElseActivity3
            // 
            this.ifElseActivity3.Activities.Add(this.PendirianPerusahaan);
            this.ifElseActivity3.Activities.Add(this.PembelianPerusahaan);
            this.ifElseActivity3.Name = "ifElseActivity3";
            // 
            // ChiefCorsecReject
            // 
            this.ChiefCorsecReject.Name = "ChiefCorsecReject";
            // 
            // ChiefCorsecApprove
            // 
            this.ChiefCorsecApprove.Activities.Add(this.ifElseActivity3);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.ChiefCorsecApprove.Condition = codecondition2;
            this.ChiefCorsecApprove.Name = "ChiefCorsecApprove";
            // 
            // sendEmailReject
            // 
            this.sendEmailReject.BCC = null;
            activitybind100.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind100.Path = "sendEmailReject_Body1";
            this.sendEmailReject.CC = null;
            this.sendEmailReject.CorrelationToken = correlationtoken1;
            this.sendEmailReject.From = null;
            activitybind101.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind101.Path = "sendEmailReject_Headers1";
            this.sendEmailReject.IncludeStatus = false;
            this.sendEmailReject.Name = "sendEmailReject";
            this.sendEmailReject.Subject = null;
            this.sendEmailReject.To = null;
            this.sendEmailReject.MethodInvoking += new System.EventHandler(this.sendEmailReject_MethodInvoking);
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind101)));
            this.sendEmailReject.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind100)));
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
            activitybind102.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind102.Path = "updateAllChiefCorsecTasks_TaskProperties1";
            this.updateAllChiefCorsecTasks.MethodInvoking += new System.EventHandler(this.updateAllChiefCorsecTasks_MethodInvoking);
            this.updateAllChiefCorsecTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind102)));
            // 
            // createChiefCorsecTask
            // 
            activitybind103.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind103.Path = "createChiefCorsecTask___Context1";
            activitybind104.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind104.Path = "createChiefCorsecTask_AssignedTo1";
            activitybind105.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind105.Path = "createChiefCorsecTask_Body1";
            activitybind106.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind106.Path = "createChiefCorsecTask_ContentTypeId1";
            activitybind107.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind107.Path = "createChiefCorsecTask_ListItemId1";
            this.createChiefCorsecTask.Name = "createChiefCorsecTask";
            activitybind108.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind108.Path = "createChiefCorsecTask_Subject1";
            activitybind109.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind109.Path = "createChiefCorsecTask_TaskTitle1";
            activitybind110.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind110.Path = "createChiefCorsecTask_WFName1";
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind103)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind104)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind105)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind106)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind107)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind108)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind109)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind110)));
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
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.Approve.Condition = codecondition3;
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
            codecondition4.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.DeptHeadApprove.Condition = codecondition4;
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
            activitybind111.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind111.Path = "updateAllDeptHeadTasks_TaskProperties1";
            this.updateAllDeptHeadTasks.MethodInvoking += new System.EventHandler(this.updateAllDeptHeadTasks_MethodInvoking);
            this.updateAllDeptHeadTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind111)));
            // 
            // createDeptHeadTask
            // 
            activitybind112.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind112.Path = "createDeptHeadTask___Context1";
            activitybind113.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind113.Path = "createDeptHeadTask_AssignedTo1";
            activitybind114.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind114.Path = "createDeptHeadTask_Body1";
            activitybind115.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind115.Path = "createDeptHeadTask_ContentTypeId1";
            activitybind116.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind116.Path = "createDeptHeadTask_ListItemId1";
            this.createDeptHeadTask.Name = "createDeptHeadTask";
            activitybind117.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind117.Path = "createDeptHeadTask_Subject1";
            activitybind118.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind118.Path = "createDeptHeadTask_TaskTitle1";
            activitybind119.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind119.Path = "createDeptHeadTask_WFName1";
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind112)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind113)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind114)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind115)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind116)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind117)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind118)));
            this.createDeptHeadTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind119)));
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
            activitybind121.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind121.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind120.Name = "PendirianPerusahaanBaruIndonesia";
            activitybind120.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind121)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind120)));
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

        private CodeActivity GetAccActionData;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAccAllTasks;

        private Activity.CreateMultipleTask createAccTask;

        private CodeActivity UpdatePermissionAcc;

        private CodeActivity PopulateDataAcc;

        private CodeActivity GetAccHeadActionData;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllAccHeadTasks;

        private Activity.CreateMultipleTask createAccHeadTask;

        private CodeActivity UpdatePermissionAccHead;

        private CodeActivity PopulateDataAccHead;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllPICCorsecTasks;

        private Activity.CreateMultipleTask createPICCorsecTask;

        private CodeActivity UpdatePermissionPICCorsec;

        private CodeActivity PopulateDataPICCorsec;

        private IfElseBranchActivity PembelianPerusahaan;

        private IfElseBranchActivity PendirianPerusahaan;

        private IfElseActivity ifElseActivity3;

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
