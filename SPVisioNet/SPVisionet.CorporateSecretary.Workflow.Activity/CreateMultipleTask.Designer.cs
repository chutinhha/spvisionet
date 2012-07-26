using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace SPVisionet.CorporateSecretary.Workflow.Activity
{
    public partial class CreateMultipleTask
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        [System.CodeDom.Compiler.GeneratedCode("", "")]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            this.createSingleTask1 = new SPVisionet.CorporateSecretary.Workflow.Activity.CreateSingleTask();
            this.replicatorActivity1 = new System.Workflow.Activities.ReplicatorActivity();
            this.logToHistoryListActivity1 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
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
            activitybind1.Name = "CreateMultipleTask";
            activitybind1.Path = "assignedToColl";
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
            this.replicatorActivity1.SetBinding(System.Workflow.Activities.ReplicatorActivity.InitialChildDataProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // logToHistoryListActivity1
            // 
            this.logToHistoryListActivity1.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity1.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind2.Name = "CreateMultipleTask";
            activitybind2.Path = "logToHistoryListActivity1_HistoryDescription1";
            activitybind3.Name = "CreateMultipleTask";
            activitybind3.Path = "logToHistoryListActivity1_HistoryOutcome1";
            this.logToHistoryListActivity1.Name = "logToHistoryListActivity1";
            this.logToHistoryListActivity1.OtherData = "";
            this.logToHistoryListActivity1.UserId = -1;
            this.logToHistoryListActivity1.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity1_MethodInvoking);
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // CreateMultipleTask
            // 
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.logToHistoryListActivity1);
            this.Activities.Add(this.replicatorActivity1);
            this.Name = "CreateMultipleTask";
            this.CanModifyActivities = false;

        }

        #endregion

        private CreateSingleTask createSingleTask1;

        private ReplicatorActivity replicatorActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity1;

        private CodeActivity codeActivity1;



    }
}
