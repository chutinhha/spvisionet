using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
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
    public partial class CreateTaskForMultiCT
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
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
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
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition3 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind14 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind15 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind16 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind17 = new System.Workflow.ComponentModel.ActivityBind();
            this.onTaskDeleted1 = new Microsoft.SharePoint.WorkflowActions.OnTaskDeleted();
            this.onTaskChanged1 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.throwActivity1 = new System.Workflow.ComponentModel.ThrowActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.logToHistoryListActivity5 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.logToHistoryListActivity4 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.completeTask1 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.logToHistoryListActivity1 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.createTaskWithContentType1 = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            activitybind2.Name = "CreateTaskForMultiCT";
            activitybind2.Path = "onTaskDeleted1_AfterProperties1";
            // 
            // onTaskDeleted1
            // 
            correlationtoken1.Name = "createTaskCT1Token";
            correlationtoken1.OwnerActivityName = "sequenceActivity1";
            this.onTaskDeleted1.CorrelationToken = correlationtoken1;
            this.onTaskDeleted1.Executor = null;
            this.onTaskDeleted1.Name = "onTaskDeleted1";
            activitybind1.Name = "CreateTaskForMultiCT";
            activitybind1.Path = "createTaskWithContentType1_TaskId1";
            this.onTaskDeleted1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskDeleted1_Invoked);
            this.onTaskDeleted1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskDeleted.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onTaskDeleted1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskDeleted.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // onTaskChanged1
            // 
            activitybind3.Name = "CreateTaskForMultiCT";
            activitybind3.Path = "onTaskChanged1_AfterProperties1";
            activitybind4.Name = "CreateTaskForMultiCT";
            activitybind4.Path = "onTaskChanged1_BeforeProperties1";
            this.onTaskChanged1.CorrelationToken = correlationtoken1;
            this.onTaskChanged1.Executor = null;
            this.onTaskChanged1.Name = "onTaskChanged1";
            activitybind5.Name = "CreateTaskForMultiCT";
            activitybind5.Path = "createTaskWithContentType1_TaskId1";
            this.onTaskChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged1_Invoked);
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            activitybind6.Name = "CreateTaskForMultiCT";
            activitybind6.Path = "throwActivity1_Fault1";
            // 
            // throwActivity1
            // 
            this.throwActivity1.FaultType = typeof(System.Exception);
            this.throwActivity1.Name = "throwActivity1";
            this.throwActivity1.SetBinding(System.Workflow.ComponentModel.ThrowActivity.FaultProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // logToHistoryListActivity5
            // 
            this.logToHistoryListActivity5.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity5.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind7.Name = "CreateTaskForMultiCT";
            activitybind7.Path = "logToHistoryListActivity5_HistoryDescription1";
            activitybind8.Name = "CreateTaskForMultiCT";
            activitybind8.Path = "logToHistoryListActivity5_HistoryOutcome1";
            this.logToHistoryListActivity5.Name = "logToHistoryListActivity5";
            this.logToHistoryListActivity5.OtherData = "";
            this.logToHistoryListActivity5.UserId = -1;
            this.logToHistoryListActivity5.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity5_MethodInvoking);
            this.logToHistoryListActivity5.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.logToHistoryListActivity5.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            // 
            // logToHistoryListActivity4
            // 
            this.logToHistoryListActivity4.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity4.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind9.Name = "CreateTaskForMultiCT";
            activitybind9.Path = "logToHistoryListActivity4_HistoryDescription1";
            activitybind10.Name = "CreateTaskForMultiCT";
            activitybind10.Path = "logToHistoryListActivity4_HistoryOutcome1";
            this.logToHistoryListActivity4.Name = "logToHistoryListActivity4";
            this.logToHistoryListActivity4.OtherData = "";
            this.logToHistoryListActivity4.UserId = -1;
            this.logToHistoryListActivity4.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity4_MethodInvoking);
            this.logToHistoryListActivity4.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.logToHistoryListActivity4.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // completeTask1
            // 
            this.completeTask1.CorrelationToken = correlationtoken1;
            this.completeTask1.Name = "completeTask1";
            activitybind11.Name = "CreateTaskForMultiCT";
            activitybind11.Path = "createTaskWithContentType1_TaskId1";
            this.completeTask1.TaskOutcome = null;
            this.completeTask1.MethodInvoking += new System.EventHandler(this.completeTask1_MethodInvoking);
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.onTaskDeleted1);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.onTaskChanged1);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Activities.Add(this.logToHistoryListActivity5);
            this.ifElseBranchActivity2.Activities.Add(this.codeActivity2);
            this.ifElseBranchActivity2.Activities.Add(this.throwActivity1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IfElseActivity2_Condition);
            this.ifElseBranchActivity2.Condition = codecondition1;
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.completeTask1);
            this.ifElseBranchActivity1.Activities.Add(this.logToHistoryListActivity4);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IfElseActivity1_Condition);
            this.ifElseBranchActivity1.Condition = codecondition2;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.listenActivity1);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.whileActivity1_Condition);
            this.whileActivity1.Condition = codecondition3;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // logToHistoryListActivity1
            // 
            this.logToHistoryListActivity1.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity1.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind12.Name = "CreateTaskForMultiCT";
            activitybind12.Path = "logToHistoryListActivity1_HistoryDescription1";
            activitybind13.Name = "CreateTaskForMultiCT";
            activitybind13.Path = "logToHistoryListActivity1_HistoryOutcome1";
            this.logToHistoryListActivity1.Name = "logToHistoryListActivity1";
            this.logToHistoryListActivity1.OtherData = "";
            this.logToHistoryListActivity1.UserId = -1;
            this.logToHistoryListActivity1.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity1_MethodInvoking);
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // createTaskWithContentType1
            // 
            activitybind14.Name = "CreateTaskForMultiCT";
            activitybind14.Path = "createTaskWithContentType1_ContentTypeId1";
            this.createTaskWithContentType1.CorrelationToken = correlationtoken1;
            activitybind15.Name = "CreateTaskForMultiCT";
            activitybind15.Path = "createTaskWithContentType1_ListItemId1";
            this.createTaskWithContentType1.Name = "createTaskWithContentType1";
            this.createTaskWithContentType1.SpecialPermissions = null;
            activitybind16.Name = "CreateTaskForMultiCT";
            activitybind16.Path = "createTaskWithContentType1_TaskId1";
            activitybind17.Name = "CreateTaskForMultiCT";
            activitybind17.Path = "createTaskWithContentType1_TaskProperties1";
            this.createTaskWithContentType1.MethodInvoking += new System.EventHandler(this.createTaskWithContentType1_MethodInvoking);
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.createTaskWithContentType1);
            this.sequenceActivity1.Activities.Add(this.codeActivity1);
            this.sequenceActivity1.Activities.Add(this.logToHistoryListActivity1);
            this.sequenceActivity1.Activities.Add(this.whileActivity1);
            this.sequenceActivity1.Activities.Add(this.ifElseActivity1);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // CreateTaskForMultiCT
            // 
            this.Activities.Add(this.sequenceActivity1);
            this.Name = "CreateTaskForMultiCT";
            this.CanModifyActivities = false;

        }

        #endregion

        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity ifElseActivity1;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity5;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity4;
        private ThrowActivity throwActivity1;
        private CodeActivity codeActivity2;
        private Microsoft.SharePoint.WorkflowActions.OnTaskDeleted onTaskDeleted1;
        private EventDrivenActivity eventDrivenActivity2;
        private EventDrivenActivity eventDrivenActivity1;
        private ListenActivity listenActivity1;
        private CodeActivity codeActivity1;
        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity1;
        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged1;
        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask1;
        private WhileActivity whileActivity1;
        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createTaskWithContentType1;
        private SequenceActivity sequenceActivity1;






































    }
}
