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

namespace SPVisionet.CorporateSecretary.Workflow.PendirianPerusahaanBaruForeign
{
    public sealed partial class PendirianPerusahaanBaruForeign
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
            this.sendEmailRejected = new Microsoft.SharePoint.WorkflowActions.SendEmail();
            this.UpdatePermissionReject = new System.Workflow.Activities.CodeActivity();
            this.SendEmailApprove = new System.Workflow.Activities.CodeActivity();
            this.UpdatePermissionApprove = new System.Workflow.Activities.CodeActivity();
            this.updateAllPICCorsecTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createPICCorsecTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionPICCorsec = new System.Workflow.Activities.CodeActivity();
            this.PopulatePICCorsecData = new System.Workflow.Activities.CodeActivity();
            this.Rejected = new System.Workflow.Activities.IfElseBranchActivity();
            this.Approved = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.GetApproval = new System.Workflow.Activities.CodeActivity();
            this.updateAllChiefCorsecTasks = new Microsoft.SharePoint.WorkflowActions.UpdateAllTasks();
            this.createChiefCorsecTask = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask();
            this.UpdatePermissionChiefCorsec = new System.Workflow.Activities.CodeActivity();
            this.PopulateChiefCorsecData = new System.Workflow.Activities.CodeActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // sendEmailRejected
            // 
            this.sendEmailRejected.BCC = null;
            activitybind1.Name = "PendirianPerusahaanBaruForeign";
            activitybind1.Path = "sendEmailRejected_Body1";
            this.sendEmailRejected.CC = null;
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "PendirianPerusahaanBaruForeign";
            this.sendEmailRejected.CorrelationToken = correlationtoken1;
            this.sendEmailRejected.From = null;
            activitybind2.Name = "PendirianPerusahaanBaruForeign";
            activitybind2.Path = "sendEmailRejected_Headers1";
            this.sendEmailRejected.IncludeStatus = false;
            this.sendEmailRejected.Name = "sendEmailRejected";
            this.sendEmailRejected.Subject = null;
            this.sendEmailRejected.To = null;
            this.sendEmailRejected.MethodInvoking += new System.EventHandler(this.sendEmailRejected_MethodInvoking);
            this.sendEmailRejected.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.HeadersProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.sendEmailRejected.SetBinding(Microsoft.SharePoint.WorkflowActions.SendEmail.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // UpdatePermissionReject
            // 
            this.UpdatePermissionReject.Name = "UpdatePermissionReject";
            this.UpdatePermissionReject.ExecuteCode += new System.EventHandler(this.UpdatePermissionReject_ExecuteCode);
            // 
            // SendEmailApprove
            // 
            this.SendEmailApprove.Name = "SendEmailApprove";
            this.SendEmailApprove.ExecuteCode += new System.EventHandler(this.SendEmailApprove_ExecuteCode);
            // 
            // UpdatePermissionApprove
            // 
            this.UpdatePermissionApprove.Name = "UpdatePermissionApprove";
            this.UpdatePermissionApprove.ExecuteCode += new System.EventHandler(this.UpdatePermissionApprove_ExecuteCode);
            // 
            // updateAllPICCorsecTasks
            // 
            this.updateAllPICCorsecTasks.CorrelationToken = correlationtoken1;
            this.updateAllPICCorsecTasks.Name = "updateAllPICCorsecTasks";
            activitybind3.Name = "PendirianPerusahaanBaruForeign";
            activitybind3.Path = "updateAllPICCorsecTasks_TaskProperties1";
            this.updateAllPICCorsecTasks.MethodInvoking += new System.EventHandler(this.updateAllPICCorsecTasks_MethodInvoking);
            this.updateAllPICCorsecTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // createPICCorsecTask
            // 
            activitybind4.Name = "PendirianPerusahaanBaruForeign";
            activitybind4.Path = "createPICCorsecTask___Context1";
            activitybind5.Name = "PendirianPerusahaanBaruForeign";
            activitybind5.Path = "createPICCorsecTask_AssignedTo1";
            activitybind6.Name = "PendirianPerusahaanBaruForeign";
            activitybind6.Path = "createPICCorsecTask_Body1";
            activitybind7.Name = "PendirianPerusahaanBaruForeign";
            activitybind7.Path = "createPICCorsecTask_ContentTypeId1";
            activitybind8.Name = "PendirianPerusahaanBaruForeign";
            activitybind8.Path = "createPICCorsecTask_ListItemId1";
            this.createPICCorsecTask.Name = "createPICCorsecTask";
            activitybind9.Name = "PendirianPerusahaanBaruForeign";
            activitybind9.Path = "createPICCorsecTask_Subject1";
            activitybind10.Name = "PendirianPerusahaanBaruForeign";
            activitybind10.Path = "createPICCorsecTask_TaskTitle1";
            activitybind11.Name = "PendirianPerusahaanBaruForeign";
            activitybind11.Path = "createPICCorsecTask_WFName1";
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.createPICCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // UpdatePermissionPICCorsec
            // 
            this.UpdatePermissionPICCorsec.Name = "UpdatePermissionPICCorsec";
            this.UpdatePermissionPICCorsec.ExecuteCode += new System.EventHandler(this.UpdatePermissionPICCorsec_ExecuteCode);
            // 
            // PopulatePICCorsecData
            // 
            this.PopulatePICCorsecData.Name = "PopulatePICCorsecData";
            this.PopulatePICCorsecData.ExecuteCode += new System.EventHandler(this.PopulatePICCorsecData_ExecuteCode);
            // 
            // Rejected
            // 
            this.Rejected.Activities.Add(this.UpdatePermissionReject);
            this.Rejected.Activities.Add(this.sendEmailRejected);
            this.Rejected.Name = "Rejected";
            // 
            // Approved
            // 
            this.Approved.Activities.Add(this.PopulatePICCorsecData);
            this.Approved.Activities.Add(this.UpdatePermissionPICCorsec);
            this.Approved.Activities.Add(this.createPICCorsecTask);
            this.Approved.Activities.Add(this.updateAllPICCorsecTasks);
            this.Approved.Activities.Add(this.UpdatePermissionApprove);
            this.Approved.Activities.Add(this.SendEmailApprove);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ApprovedCondition);
            this.Approved.Condition = codecondition1;
            this.Approved.Name = "Approved";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.Approved);
            this.ifElseActivity1.Activities.Add(this.Rejected);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // GetApproval
            // 
            this.GetApproval.Name = "GetApproval";
            this.GetApproval.ExecuteCode += new System.EventHandler(this.GetApproval_ExecuteCode);
            // 
            // updateAllChiefCorsecTasks
            // 
            this.updateAllChiefCorsecTasks.CorrelationToken = correlationtoken1;
            this.updateAllChiefCorsecTasks.Name = "updateAllChiefCorsecTasks";
            activitybind12.Name = "PendirianPerusahaanBaruForeign";
            activitybind12.Path = "updateAllChiefCorsecTasks_TaskProperties1";
            this.updateAllChiefCorsecTasks.MethodInvoking += new System.EventHandler(this.updateAllChiefCorsecTasks_MethodInvoking);
            this.updateAllChiefCorsecTasks.SetBinding(Microsoft.SharePoint.WorkflowActions.UpdateAllTasks.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // createChiefCorsecTask
            // 
            activitybind13.Name = "PendirianPerusahaanBaruForeign";
            activitybind13.Path = "createChiefCorsecTask___Context1";
            activitybind14.Name = "PendirianPerusahaanBaruForeign";
            activitybind14.Path = "createChiefCorsecTask_AssignedTo1";
            activitybind15.Name = "PendirianPerusahaanBaruForeign";
            activitybind15.Path = "createChiefCorsecTask_Body1";
            activitybind16.Name = "PendirianPerusahaanBaruForeign";
            activitybind16.Path = "createChiefCorsecTask_ContentTypeId1";
            activitybind17.Name = "PendirianPerusahaanBaruForeign";
            activitybind17.Path = "createChiefCorsecTask_ListItemId1";
            this.createChiefCorsecTask.Name = "createChiefCorsecTask";
            activitybind18.Name = "PendirianPerusahaanBaruForeign";
            activitybind18.Path = "createChiefCorsecTask_Subject1";
            activitybind19.Name = "PendirianPerusahaanBaruForeign";
            activitybind19.Path = "createChiefCorsecTask_TaskTitle1";
            activitybind20.Name = "PendirianPerusahaanBaruForeign";
            activitybind20.Path = "createChiefCorsecTask_WFName1";
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.@__ContextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.AssignedToProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.BodyProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.SubjectProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind18)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.TaskTitleProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind19)));
            this.createChiefCorsecTask.SetBinding(SPVisionet.CorporateSecretary.Workflow.Activity.CreateMultipleTask.WFNameProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind20)));
            // 
            // UpdatePermissionChiefCorsec
            // 
            this.UpdatePermissionChiefCorsec.Name = "UpdatePermissionChiefCorsec";
            this.UpdatePermissionChiefCorsec.ExecuteCode += new System.EventHandler(this.UpdatePermissionChiefCorsec_ExecuteCode);
            // 
            // PopulateChiefCorsecData
            // 
            this.PopulateChiefCorsecData.Name = "PopulateChiefCorsecData";
            this.PopulateChiefCorsecData.ExecuteCode += new System.EventHandler(this.PopulateChiefCorsecData_ExecuteCode);
            activitybind22.Name = "PendirianPerusahaanBaruForeign";
            activitybind22.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind21.Name = "PendirianPerusahaanBaruForeign";
            activitybind21.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind22)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind21)));
            // 
            // PendirianPerusahaanBaruForeign
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.PopulateChiefCorsecData);
            this.Activities.Add(this.UpdatePermissionChiefCorsec);
            this.Activities.Add(this.createChiefCorsecTask);
            this.Activities.Add(this.updateAllChiefCorsecTasks);
            this.Activities.Add(this.GetApproval);
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "PendirianPerusahaanBaruForeign";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllPICCorsecTasks;

        private Activity.CreateMultipleTask createPICCorsecTask;

        private CodeActivity UpdatePermissionPICCorsec;

        private CodeActivity PopulatePICCorsecData;

        private IfElseBranchActivity Rejected;

        private IfElseBranchActivity Approved;

        private IfElseActivity ifElseActivity1;

        private CodeActivity SendEmailApprove;

        private CodeActivity UpdatePermissionApprove;

        private CodeActivity UpdatePermissionReject;

        private Microsoft.SharePoint.WorkflowActions.SendEmail sendEmailRejected;

        private Activity.CreateMultipleTask createChiefCorsecTask;

        private CodeActivity UpdatePermissionChiefCorsec;

        private CodeActivity GetApproval;

        private Microsoft.SharePoint.WorkflowActions.UpdateAllTasks updateAllChiefCorsecTasks;

        private CodeActivity PopulateChiefCorsecData;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;




































    }
}
