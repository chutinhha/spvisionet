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
    public partial class CreateSingleTask
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
            this.cancellationHandlerActivity3 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.onTaskDeleted1 = new Microsoft.SharePoint.WorkflowActions.OnTaskDeleted();
            this.cancellationHandlerActivity2 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.onTaskChanged1 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.faultHandlersActivity2 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.can = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.throwActivity1 = new System.Workflow.ComponentModel.ThrowActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.logToHistoryListActivity3 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.cancellationHandlerActivity5 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.logToHistoryListActivity2 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.completeTask1 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.cancellationHandlerActivity6 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.cancellationHandlerActivity7 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.listenActivity1 = new System.Workflow.Activities.ListenActivity();
            this.cancellationHandlerActivity4 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.logToHistoryListActivity1 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.createTaskWithContentType1 = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.faultHandlersActivity1 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.cancellationHandlerActivity1 = new System.Workflow.ComponentModel.CancellationHandlerActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            // 
            // cancellationHandlerActivity3
            // 
            this.cancellationHandlerActivity3.Enabled = false;
            this.cancellationHandlerActivity3.Name = "cancellationHandlerActivity3";
            activitybind2.Name = "CreateSingleTask";
            activitybind2.Path = "onTaskDeleted1_AfterProperties1";
            // 
            // onTaskDeleted1
            // 
            correlationtoken1.Name = "token";
            correlationtoken1.OwnerActivityName = "sequenceActivity1";
            this.onTaskDeleted1.CorrelationToken = correlationtoken1;
            this.onTaskDeleted1.Executor = null;
            this.onTaskDeleted1.Name = "onTaskDeleted1";
            activitybind1.Name = "CreateSingleTask";
            activitybind1.Path = "createTaskWithContentType1_TaskId1";
            this.onTaskDeleted1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskDeleted1_Invoked);
            this.onTaskDeleted1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskDeleted.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onTaskDeleted1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskDeleted.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // cancellationHandlerActivity2
            // 
            this.cancellationHandlerActivity2.Enabled = false;
            this.cancellationHandlerActivity2.Name = "cancellationHandlerActivity2";
            // 
            // onTaskChanged1
            // 
            activitybind3.Name = "CreateSingleTask";
            activitybind3.Path = "onTaskChanged1_AfterProperties1";
            activitybind4.Name = "CreateSingleTask";
            activitybind4.Path = "onTaskChanged1_BeforeProperties1";
            this.onTaskChanged1.CorrelationToken = correlationtoken1;
            this.onTaskChanged1.Executor = null;
            this.onTaskChanged1.Name = "onTaskChanged1";
            activitybind5.Name = "CreateSingleTask";
            activitybind5.Path = "createTaskWithContentType1_TaskId1";
            this.onTaskChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged1_Invoked);
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // faultHandlersActivity2
            // 
            this.faultHandlersActivity2.Name = "faultHandlersActivity2";
            // 
            // can
            // 
            this.can.Enabled = false;
            this.can.Name = "can";
            activitybind6.Name = "CreateSingleTask";
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
            // logToHistoryListActivity3
            // 
            this.logToHistoryListActivity3.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity3.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind7.Name = "CreateSingleTask";
            activitybind7.Path = "logToHistoryListActivity3_HistoryDescription1";
            activitybind8.Name = "CreateSingleTask";
            activitybind8.Path = "logToHistoryListActivity3_HistoryOutcome1";
            this.logToHistoryListActivity3.Name = "logToHistoryListActivity3";
            this.logToHistoryListActivity3.OtherData = "";
            this.logToHistoryListActivity3.UserId = -1;
            this.logToHistoryListActivity3.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity3_MethodInvoking);
            this.logToHistoryListActivity3.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.logToHistoryListActivity3.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            // 
            // cancellationHandlerActivity5
            // 
            this.cancellationHandlerActivity5.Enabled = false;
            this.cancellationHandlerActivity5.Name = "cancellationHandlerActivity5";
            // 
            // logToHistoryListActivity2
            // 
            this.logToHistoryListActivity2.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity2.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind9.Name = "CreateSingleTask";
            activitybind9.Path = "logToHistoryListActivity2_HistoryDescription1";
            activitybind10.Name = "CreateSingleTask";
            activitybind10.Path = "logToHistoryListActivity2_HistoryOutcome1";
            this.logToHistoryListActivity2.Name = "logToHistoryListActivity2";
            this.logToHistoryListActivity2.OtherData = "";
            this.logToHistoryListActivity2.UserId = -1;
            this.logToHistoryListActivity2.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity2_MethodInvoking);
            this.logToHistoryListActivity2.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.logToHistoryListActivity2.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            // 
            // completeTask1
            // 
            this.completeTask1.CorrelationToken = correlationtoken1;
            this.completeTask1.Name = "completeTask1";
            activitybind11.Name = "CreateSingleTask";
            activitybind11.Path = "createTaskWithContentType1_TaskId1";
            this.completeTask1.TaskOutcome = null;
            this.completeTask1.MethodInvoking += new System.EventHandler(this.completeTask1_MethodInvoking);
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.onTaskDeleted1);
            this.eventDrivenActivity2.Activities.Add(this.cancellationHandlerActivity3);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.onTaskChanged1);
            this.eventDrivenActivity1.Activities.Add(this.cancellationHandlerActivity2);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // cancellationHandlerActivity6
            // 
            this.cancellationHandlerActivity6.Enabled = false;
            this.cancellationHandlerActivity6.Name = "cancellationHandlerActivity6";
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Activities.Add(this.logToHistoryListActivity3);
            this.ifElseBranchActivity2.Activities.Add(this.codeActivity2);
            this.ifElseBranchActivity2.Activities.Add(this.throwActivity1);
            this.ifElseBranchActivity2.Activities.Add(this.can);
            this.ifElseBranchActivity2.Activities.Add(this.faultHandlersActivity2);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IfElseActivity2_Condition);
            this.ifElseBranchActivity2.Condition = codecondition1;
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.completeTask1);
            this.ifElseBranchActivity1.Activities.Add(this.logToHistoryListActivity2);
            this.ifElseBranchActivity1.Activities.Add(this.cancellationHandlerActivity5);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.IfElseActivity1_Condition);
            this.ifElseBranchActivity1.Condition = codecondition2;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // cancellationHandlerActivity7
            // 
            this.cancellationHandlerActivity7.Enabled = false;
            this.cancellationHandlerActivity7.Name = "cancellationHandlerActivity7";
            // 
            // listenActivity1
            // 
            this.listenActivity1.Activities.Add(this.eventDrivenActivity1);
            this.listenActivity1.Activities.Add(this.eventDrivenActivity2);
            this.listenActivity1.Name = "listenActivity1";
            // 
            // cancellationHandlerActivity4
            // 
            this.cancellationHandlerActivity4.Enabled = false;
            this.cancellationHandlerActivity4.Name = "cancellationHandlerActivity4";
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Activities.Add(this.cancellationHandlerActivity6);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.listenActivity1);
            this.whileActivity1.Activities.Add(this.cancellationHandlerActivity7);
            codecondition3.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.whileActivity1_Condition);
            this.whileActivity1.Condition = codecondition3;
            this.whileActivity1.Name = "whileActivity1";
            // 
            // logToHistoryListActivity1
            // 
            this.logToHistoryListActivity1.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity1.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind12.Name = "CreateSingleTask";
            activitybind12.Path = "logToHistoryListActivity1_HistoryDescription1";
            activitybind13.Name = "CreateSingleTask";
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
            activitybind14.Name = "CreateSingleTask";
            activitybind14.Path = "createTaskWithContentType1_ContentTypeId1";
            this.createTaskWithContentType1.CorrelationToken = correlationtoken1;
            activitybind15.Name = "CreateSingleTask";
            activitybind15.Path = "createTaskWithContentType1_ListItemId1";
            this.createTaskWithContentType1.Name = "createTaskWithContentType1";
            this.createTaskWithContentType1.SpecialPermissions = null;
            activitybind16.Name = "CreateSingleTask";
            activitybind16.Path = "createTaskWithContentType1_TaskId1";
            activitybind17.Name = "CreateSingleTask";
            activitybind17.Path = "createTaskWithContentType1_TaskProperties1";
            this.createTaskWithContentType1.MethodInvoking += new System.EventHandler(this.createTaskWithContentType1_MethodInvoking);
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind14)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ListItemIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind15)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind16)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind17)));
            // 
            // faultHandlersActivity1
            // 
            this.faultHandlersActivity1.Name = "faultHandlersActivity1";
            // 
            // cancellationHandlerActivity1
            // 
            this.cancellationHandlerActivity1.Enabled = false;
            this.cancellationHandlerActivity1.Name = "cancellationHandlerActivity1";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.createTaskWithContentType1);
            this.sequenceActivity1.Activities.Add(this.codeActivity1);
            this.sequenceActivity1.Activities.Add(this.logToHistoryListActivity1);
            this.sequenceActivity1.Activities.Add(this.whileActivity1);
            this.sequenceActivity1.Activities.Add(this.ifElseActivity1);
            this.sequenceActivity1.Activities.Add(this.cancellationHandlerActivity4);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // CreateSingleTask
            // 
            this.Activities.Add(this.sequenceActivity1);
            this.Activities.Add(this.cancellationHandlerActivity1);
            this.Activities.Add(this.faultHandlersActivity1);
            this.Name = "CreateSingleTask";
            this.CanModifyActivities = false;

        }

        #endregion

        private CancellationHandlerActivity cancellationHandlerActivity3;

        private CancellationHandlerActivity cancellationHandlerActivity2;

        private CancellationHandlerActivity can;

        private ThrowActivity throwActivity1;

        private CancellationHandlerActivity cancellationHandlerActivity5;

        private CancellationHandlerActivity cancellationHandlerActivity6;

        private FaultHandlersActivity faultHandlersActivity2;

        private CancellationHandlerActivity cancellationHandlerActivity4;

        private CancellationHandlerActivity cancellationHandlerActivity7;

        private SequenceActivity sequenceActivity1;

        private FaultHandlersActivity faultHandlersActivity1;

        private Microsoft.SharePoint.WorkflowActions.OnTaskDeleted onTaskDeleted1;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged1;

        private CodeActivity codeActivity2;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity3;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity2;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask1;

        private EventDrivenActivity eventDrivenActivity2;

        private EventDrivenActivity eventDrivenActivity1;

        private IfElseBranchActivity ifElseBranchActivity2;

        private IfElseBranchActivity ifElseBranchActivity1;

        private ListenActivity listenActivity1;

        private IfElseActivity ifElseActivity1;

        private WhileActivity whileActivity1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity1;

        private CodeActivity codeActivity1;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createTaskWithContentType1;

        private CancellationHandlerActivity cancellationHandlerActivity1;


































    }
}
