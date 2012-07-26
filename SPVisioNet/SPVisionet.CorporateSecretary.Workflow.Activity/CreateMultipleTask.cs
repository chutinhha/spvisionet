using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Linq;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Collections.Specialized;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WorkflowActions;
using Microsoft.SharePoint.Workflow;

namespace SPVisionet.CorporateSecretary.Workflow.Activity
{
    public partial class CreateMultipleTask : SequenceActivity
    {
        public CreateMultipleTask()
        {
            InitializeComponent();
        }

        #region Fields

        public static DependencyProperty __ContextProperty =
            DependencyProperty.Register("__Context", typeof(WorkflowContext), typeof(CreateMultipleTask));

        public static DependencyProperty ListItemIdProperty =
            DependencyProperty.Register("ListItemId", typeof(int), typeof(CreateMultipleTask));

        public static DependencyProperty TaskTitleProperty =
            DependencyProperty.Register("TaskTitle", typeof(string), typeof(CreateMultipleTask));

        public static DependencyProperty AssignedToProperty =
            DependencyProperty.Register("AssignedTo", typeof(string), typeof(CreateMultipleTask));

        public static DependencyProperty ContentTypeIdProperty =
            DependencyProperty.Register("ContentTypeId", typeof(string), typeof(CreateMultipleTask));

        public static DependencyProperty WFNameProperty =
           DependencyProperty.Register("WFName", typeof(string), typeof(CreateMultipleTask));

        public static DependencyProperty OriginatorLoginNameProperty =
          DependencyProperty.Register("OriginatorLoginName", typeof(string), typeof(CreateMultipleTask));

        public static DependencyProperty SubjectProperty =
         DependencyProperty.Register("Subject", typeof(string), typeof(CreateMultipleTask));

        public static DependencyProperty BodyProperty =
         DependencyProperty.Register("Body", typeof(string), typeof(CreateMultipleTask));

        public StringCollection assignedToColl;
        public ArrayList taskIdQueue = new ArrayList();

        #endregion

        #region Properties

        [Description("Context")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public WorkflowContext __Context
        {
            set { base.SetValue(CreateMultipleTask.__ContextProperty, value); }
            get { return (WorkflowContext)base.GetValue(CreateMultipleTask.__ContextProperty); }
        }

        [Description("ListItemId")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ListItemId
        {
            set { base.SetValue(CreateMultipleTask.ListItemIdProperty, value); }
            get { return (int)base.GetValue(CreateMultipleTask.ListItemIdProperty); }
        }

        [Description("TaskTitle")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string TaskTitle
        {
            set { base.SetValue(CreateMultipleTask.TaskTitleProperty, value); }
            get { return (string)base.GetValue(CreateMultipleTask.TaskTitleProperty); }
        }

        [Description("AssignedTo")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string AssignedTo
        {
            set { base.SetValue(CreateMultipleTask.AssignedToProperty, value); }
            get { return (string)base.GetValue(CreateMultipleTask.AssignedToProperty); }
        }


        [Description("ContentTypeId")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ContentTypeId
        {
            set { base.SetValue(CreateMultipleTask.ContentTypeIdProperty, value); }
            get { return (string)base.GetValue(CreateMultipleTask.ContentTypeIdProperty); }
        }

        [Description("WFName")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string WFName
        {
            set { base.SetValue(CreateMultipleTask.WFNameProperty, value); }
            get { return (string)base.GetValue(CreateMultipleTask.WFNameProperty); }
        }

        [Description("Subject")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Subject
        {
            set { base.SetValue(CreateMultipleTask.SubjectProperty, value); }
            get { return (string)base.GetValue(CreateMultipleTask.SubjectProperty); }
        }

        [Description("Body")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Body
        {
            set { base.SetValue(CreateMultipleTask.BodyProperty, value); }
            get { return (string)base.GetValue(CreateMultipleTask.BodyProperty); }
        }

        #endregion

        #region INIT

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            assignedToColl = GetAssignedToColl(this.AssignedTo);
        }

        public String logToHistoryListActivity1_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity1_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity1_MethodInvoking(object sender, EventArgs e)
        {
            string currentAssignedTo = string.Empty;

            foreach (string item in assignedToColl)
            {
                currentAssignedTo += item + ";";
            }
            currentAssignedTo = currentAssignedTo.Remove(currentAssignedTo.Length - 1);

            logToHistoryListActivity1_HistoryDescription1 = string.Format("Prepare create task for {0}", currentAssignedTo);
            logToHistoryListActivity1_HistoryOutcome1 = string.Empty;
        }

        #endregion

        #region REPLICATOR

        private void replicatorActivity1_Initialized(object sender, EventArgs e)
        {

        }

        private void replicatorActivity1_ChildInitialized(object sender, ReplicatorChildEventArgs e)
        {
            SPWorkflowTaskProperties childTaskProperties = new SPWorkflowTaskProperties();
            childTaskProperties.Title = this.TaskTitle;
            childTaskProperties.AssignedTo = (string)e.InstanceData;
            childTaskProperties.PercentComplete = 0;
            childTaskProperties.ExtendedProperties["WF"] = this.WFName;
            childTaskProperties.HasCustomEmailBody = true;
            childTaskProperties.SendEmailNotification = false;

            CreateSingleTask currentChildActivity = (CreateSingleTask)e.Activity;
            currentChildActivity.__Context = __Context;
            currentChildActivity.ContentTypeId = this.ContentTypeId;
            currentChildActivity.Subject = Subject;
            currentChildActivity.Body = Body;

            currentChildActivity.TaskProperties = childTaskProperties;
        }

        private void replicatorActivity1_ChildCompleted(object sender, ReplicatorChildEventArgs e)
        {
            CreateSingleTask currentChildActivity = (CreateSingleTask)e.Activity;
            int childTaskId = currentChildActivity.ListItemId;
            taskIdQueue.Add(childTaskId);
        }

        private void replicatorActivity1_UntilCondition(object sender, ConditionalEventArgs e)
        {
            if (taskIdQueue.Count > 0)
            {
                e.Result = true; //skip all other child activity
            }
            else
                e.Result = false;
        }

        private void replicatorActivity1_Completed(object sender, EventArgs e)
        {
            this.ListItemId = Convert.ToInt32(taskIdQueue[0]);
        }

        #endregion

        #region END

        #endregion

        #region SUPPORT METHOD

        private StringCollection GetAssignedToColl(string assignedTo)
        {
            StringCollection loginNames = new StringCollection();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                string[] split = assignedTo.Split(';');
                foreach (string item in split)
                {
                    loginNames.Add(item);
                }
            });
            return loginNames;
        }

        #endregion
    }
}
