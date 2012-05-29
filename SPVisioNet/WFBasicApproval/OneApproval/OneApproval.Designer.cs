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

namespace InfinysWorkflowPrj.WFBasicApproval.OneApproval
{
    public sealed partial class OneApproval
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
            System.Workflow.Runtime.CorrelationToken correlationtoken2 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind6 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind7 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind8 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind9 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind10 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind11 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind13 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind12 = new System.Workflow.ComponentModel.ActivityBind();
            this.onTaskChanged1 = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.onWorkflowItemChanged1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowItemChanged();
            this.logToHistoryListActivity2 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.completeTask1 = new Microsoft.SharePoint.WorkflowActions.CompleteTask();
            this.whileActivity2 = new System.Workflow.Activities.WhileActivity();
            this.logToHistoryListActivity1 = new Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity();
            this.createTaskWithContentType1 = new Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType();
            this.whileActivity1 = new System.Workflow.Activities.WhileActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // onTaskChanged1
            // 
            activitybind1.Name = "OneApproval";
            activitybind1.Path = "onTaskChanged1_AfterProperties1";
            activitybind2.Name = "OneApproval";
            activitybind2.Path = "onTaskChanged1_BeforeProperties1";
            correlationtoken1.Name = "Approval1";
            correlationtoken1.OwnerActivityName = "OneApproval";
            this.onTaskChanged1.CorrelationToken = correlationtoken1;
            this.onTaskChanged1.Executor = null;
            this.onTaskChanged1.Name = "onTaskChanged1";
            activitybind3.Name = "OneApproval";
            activitybind3.Path = "TaskId";
            this.onTaskChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onTaskChanged1_Invoked);
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onTaskChanged1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // onWorkflowItemChanged1
            // 
            this.onWorkflowItemChanged1.AfterProperties = null;
            this.onWorkflowItemChanged1.BeforeProperties = null;
            correlationtoken2.Name = "workflowToken";
            correlationtoken2.OwnerActivityName = "OneApproval";
            this.onWorkflowItemChanged1.CorrelationToken = correlationtoken2;
            this.onWorkflowItemChanged1.Name = "onWorkflowItemChanged1";
            this.onWorkflowItemChanged1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowItemChanged1_Invoked);
            // 
            // logToHistoryListActivity2
            // 
            this.logToHistoryListActivity2.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity2.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind4.Name = "OneApproval";
            activitybind4.Path = "logToHistoryListActivity2_HistoryDescription1";
            activitybind5.Name = "OneApproval";
            activitybind5.Path = "logToHistoryListActivity2_HistoryOutcome1";
            this.logToHistoryListActivity2.Name = "logToHistoryListActivity2";
            this.logToHistoryListActivity2.OtherData = "";
            this.logToHistoryListActivity2.UserId = -1;
            this.logToHistoryListActivity2.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity2_MethodInvoking);
            this.logToHistoryListActivity2.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.logToHistoryListActivity2.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // completeTask1
            // 
            this.completeTask1.CorrelationToken = correlationtoken1;
            this.completeTask1.Name = "completeTask1";
            activitybind6.Name = "OneApproval";
            activitybind6.Path = "TaskId";
            this.completeTask1.TaskOutcome = null;
            this.completeTask1.SetBinding(Microsoft.SharePoint.WorkflowActions.CompleteTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind6)));
            // 
            // whileActivity2
            // 
            this.whileActivity2.Activities.Add(this.onTaskChanged1);
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CheckApprovalAction);
            this.whileActivity2.Condition = codecondition1;
            this.whileActivity2.Name = "whileActivity2";
            // 
            // logToHistoryListActivity1
            // 
            this.logToHistoryListActivity1.Duration = System.TimeSpan.Parse("-10675199.02:48:05.4775808");
            this.logToHistoryListActivity1.EventId = Microsoft.SharePoint.Workflow.SPWorkflowHistoryEventType.WorkflowComment;
            activitybind7.Name = "OneApproval";
            activitybind7.Path = "logToHistoryListActivity1_HistoryDescription1";
            activitybind8.Name = "OneApproval";
            activitybind8.Path = "logToHistoryListActivity1_HistoryOutcome1";
            this.logToHistoryListActivity1.Name = "logToHistoryListActivity1";
            this.logToHistoryListActivity1.OtherData = "";
            this.logToHistoryListActivity1.UserId = -1;
            this.logToHistoryListActivity1.MethodInvoking += new System.EventHandler(this.logToHistoryListActivity1_MethodInvoking);
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryDescriptionProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind7)));
            this.logToHistoryListActivity1.SetBinding(Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity.HistoryOutcomeProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind8)));
            // 
            // createTaskWithContentType1
            // 
            activitybind9.Name = "OneApproval";
            activitybind9.Path = "ContentTypeID";
            this.createTaskWithContentType1.CorrelationToken = correlationtoken1;
            this.createTaskWithContentType1.ListItemId = -1;
            this.createTaskWithContentType1.Name = "createTaskWithContentType1";
            this.createTaskWithContentType1.SpecialPermissions = null;
            activitybind10.Name = "OneApproval";
            activitybind10.Path = "TaskId";
            activitybind11.Name = "OneApproval";
            activitybind11.Path = "createTaskWithContentType1_TaskProperties1";
            this.createTaskWithContentType1.MethodInvoking += new System.EventHandler(this.createTaskWithContentType1_MethodInvoking);
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.ContentTypeIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind9)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind10)));
            this.createTaskWithContentType1.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind11)));
            // 
            // whileActivity1
            // 
            this.whileActivity1.Activities.Add(this.onWorkflowItemChanged1);
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.CheckApprovalInput);
            this.whileActivity1.Condition = codecondition2;
            this.whileActivity1.Name = "whileActivity1";
            activitybind13.Name = "OneApproval";
            activitybind13.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            this.onWorkflowActivated1.CorrelationToken = correlationtoken2;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind12.Name = "OneApproval";
            activitybind12.Path = "workflowProperties";
            this.onWorkflowActivated1.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onWorkflowActivated1_Invoked_1);
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind13)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind12)));
            // 
            // OneApproval
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.whileActivity1);
            this.Activities.Add(this.createTaskWithContentType1);
            this.Activities.Add(this.logToHistoryListActivity1);
            this.Activities.Add(this.whileActivity2);
            this.Activities.Add(this.completeTask1);
            this.Activities.Add(this.logToHistoryListActivity2);
            this.Name = "OneApproval";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity1;

        private Microsoft.SharePoint.WorkflowActions.CompleteTask completeTask1;

        private Microsoft.SharePoint.WorkflowActions.LogToHistoryListActivity logToHistoryListActivity2;

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onTaskChanged1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowItemChanged onWorkflowItemChanged1;

        private WhileActivity whileActivity2;

        private Microsoft.SharePoint.WorkflowActions.CreateTaskWithContentType createTaskWithContentType1;

        private WhileActivity whileActivity1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;






















    }
}
