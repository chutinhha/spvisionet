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
using Microsoft.SharePoint.WorkflowActions;
using System.Collections.Specialized;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace SPVisionet.CorporateSecretary.Workflow.Activity
{
    public partial class CreateSingleTask : SequenceActivity
    {
        public CreateSingleTask()
        {
            InitializeComponent();
        }

        #region Fields

        public static DependencyProperty __ContextProperty =
         DependencyProperty.Register("__Context", typeof(WorkflowContext), typeof(CreateSingleTask));

        public static DependencyProperty ListItemIdProperty =
          DependencyProperty.Register("ListItemId", typeof(int), typeof(CreateSingleTask));

        public static DependencyProperty TaskPropertiesProperty =
          DependencyProperty.Register("TaskProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CreateSingleTask));

        public static DependencyProperty ContentTypeIdProperty =
          DependencyProperty.Register("ContentTypeId", typeof(string), typeof(CreateSingleTask));

        public static DependencyProperty WFNameProperty =
          DependencyProperty.Register("WFName", typeof(string), typeof(CreateSingleTask));

        public static DependencyProperty OriginatorLoginNameProperty =
          DependencyProperty.Register("OriginatorLoginName", typeof(string), typeof(CreateSingleTask));

        public static DependencyProperty SubjectProperty =
         DependencyProperty.Register("Subject", typeof(string), typeof(CreateSingleTask));

        public static DependencyProperty BodyProperty =
         DependencyProperty.Register("Body", typeof(string), typeof(CreateSingleTask));


        public bool _isTask1Complete = false;
        public bool _isTask1Deleted = false;

        #endregion

        #region Properties

        [Description("Context")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public WorkflowContext __Context
        {
            set { base.SetValue(CreateSingleTask.__ContextProperty, value); }
            get { return (WorkflowContext)base.GetValue(CreateSingleTask.__ContextProperty); }
        }


        [Description("ListItemId")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ListItemId
        {
            set { base.SetValue(CreateSingleTask.ListItemIdProperty, value); }
            get { return (int)base.GetValue(CreateSingleTask.ListItemIdProperty); }
        }

        [Description("TaskProperties")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties TaskProperties
        {
            set { base.SetValue(CreateSingleTask.TaskPropertiesProperty, value); }
            get { return (Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)base.GetValue(CreateSingleTask.TaskPropertiesProperty); }
        }

        [Description("ContentTypeId")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ContentTypeId
        {
            set { base.SetValue(CreateSingleTask.ContentTypeIdProperty, value); }
            get { return (string)base.GetValue(CreateSingleTask.ContentTypeIdProperty); }
        }

        [Description("WFName")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string WFName
        {
            set { base.SetValue(CreateSingleTask.WFNameProperty, value); }
            get { return (string)base.GetValue(CreateSingleTask.WFNameProperty); }
        }

        [Description("Subject")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Subject
        {
            set { base.SetValue(CreateSingleTask.SubjectProperty, value); }
            get { return (string)base.GetValue(CreateSingleTask.SubjectProperty); }
        }

        [Description("Body")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Body
        {
            set { base.SetValue(CreateSingleTask.BodyProperty, value); }
            get { return (string)base.GetValue(CreateSingleTask.BodyProperty); }
        }

        #endregion

        #region CREATE TASK

        public String createTaskWithContentType1_ContentTypeId1 = default(System.String);
        public Int32 createTaskWithContentType1_ListItemId1 = default(System.Int32);
        public Guid createTaskWithContentType1_TaskId1 = default(System.Guid);
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties createTaskWithContentType1_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void createTaskWithContentType1_MethodInvoking(object sender, EventArgs e)
        {
            createTaskWithContentType1_TaskId1 = Guid.NewGuid();
            createTaskWithContentType1_ContentTypeId1 = ContentTypeId;
            createTaskWithContentType1_TaskProperties1 = TaskProperties;

            HybridDictionary permsCollection = new HybridDictionary();
            permsCollection.Add(createTaskWithContentType1_TaskProperties1.AssignedTo, SPRoleType.Contributor);
            createTaskWithContentType1.SpecialPermissions = permsCollection;
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            ListItemId = createTaskWithContentType1_ListItemId1;
            string Name = string.Empty;
            string Email = string.Empty;

            string workListURL = string.Format("{0}/Lists/{1}/EditForm.aspx?ID={2}", __Context.Web.Url, "Tasks", ListItemId);

            Name = __Context.Web.Users[createTaskWithContentType1_TaskProperties1.AssignedTo].Name;
            Email = __Context.Web.Users[createTaskWithContentType1_TaskProperties1.AssignedTo].Email;

            SPUtility.SendEmail(__Context.Web, false, false, Email, Subject, string.Format(Body, Name, workListURL));
        }

        public String logToHistoryListActivity1_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity1_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity1_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity1_HistoryDescription1 = string.Format("A new task has been created for {0}", createTaskWithContentType1_TaskProperties1.AssignedTo);
            logToHistoryListActivity1_HistoryOutcome1 = "Task created.";
        }

        #endregion

        #region WAITING CHANGES

        private void whileActivity1_Condition(object sender, ConditionalEventArgs e)
        {
            e.Result = !_isTask1Complete;
        }

        #region TASK CHANGED
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties onTaskChanged1_AfterProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties onTaskChanged1_BeforeProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void onTaskChanged1_Invoked(object sender, ExternalDataEventArgs e)
        {
            if (onTaskChanged1_AfterProperties1.PercentComplete != 0)
                _isTask1Complete = true;
        }

        #endregion

        #region TASK DELETED
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties onTaskDeleted1_AfterProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void onTaskDeleted1_Invoked(object sender, ExternalDataEventArgs e)
        {
            _isTask1Complete = true;
            _isTask1Deleted = true;
        }

        #endregion

        #endregion

        #region COMPLETE

        private void IfElseActivity1_Condition(object sender, ConditionalEventArgs e)
        {
            if (!_isTask1Deleted)
                e.Result = true;
            else
                e.Result = false;
        }

        private void IfElseActivity2_Condition(object sender, ConditionalEventArgs e)
        {
            if (_isTask1Deleted)
            {
                e.Result = true;
            }
            else
                e.Result = false;
        }

        #region TASK COMPLETED

        public String completeTask1_TaskOutcome1 = default(System.String);

        private void completeTask1_MethodInvoking(object sender, EventArgs e)
        {

        }

        public String logToHistoryListActivity2_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity2_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity2_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity2_HistoryDescription1 = string.Format("The task has been actioned by {0}", createTaskWithContentType1_TaskProperties1.AssignedTo);
            logToHistoryListActivity2_HistoryOutcome1 = string.Format("Task Actioned.");
        }

        #endregion

        #region THROW ERROR - TASK DELETED

        public String logToHistoryListActivity3_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity3_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity3_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity3_HistoryDescription1 = string.Format("Workflow cannot continue because related task(s) was deleted.");
            logToHistoryListActivity3_HistoryOutcome1 = string.Format("Task Id: {0}", ListItemId.ToString());
        }

        public Exception throwActivity1_Fault1 = new System.Exception();

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            throwActivity1_Fault1 = new Exception("Task deleted.");
        }

        #endregion

        #endregion
    }
}
