using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
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
    public partial class CreateTaskForMultiCT : SequenceActivity
    {
        public CreateTaskForMultiCT()
        {
            InitializeComponent();
        }

        #region Fields

        public static DependencyProperty __ContextProperty =
         DependencyProperty.Register("__Context", typeof(WorkflowContext), typeof(CreateTaskForMultiCT));

        public static DependencyProperty ListItemIdProperty =
          DependencyProperty.Register("ListItemId", typeof(int), typeof(CreateTaskForMultiCT));

        public static DependencyProperty TaskPropertiesProperty =
          DependencyProperty.Register("TaskProperties", typeof(Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties), typeof(CreateTaskForMultiCT));

        public static DependencyProperty ContentTypeIdProperty =
          DependencyProperty.Register("ContentTypeId", typeof(string), typeof(CreateTaskForMultiCT));

        //public static DependencyProperty WFNameProperty =
        //  DependencyProperty.Register("WFName", typeof(string), typeof(CreateTaskForMultiCT));

        public static DependencyProperty OriginatorLoginNameProperty =
          DependencyProperty.Register("OriginatorLoginName", typeof(string), typeof(CreateTaskForMultiCT));

        public static DependencyProperty SubjectProperty =
         DependencyProperty.Register("Subject", typeof(string), typeof(CreateTaskForMultiCT));

        public static DependencyProperty BodyProperty =
         DependencyProperty.Register("Body", typeof(string), typeof(CreateTaskForMultiCT));


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
            set { base.SetValue(CreateTaskForMultiCT.__ContextProperty, value); }
            get { return (WorkflowContext)base.GetValue(CreateTaskForMultiCT.__ContextProperty); }
        }


        [Description("ListItemId")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ListItemId
        {
            set { base.SetValue(CreateTaskForMultiCT.ListItemIdProperty, value); }
            get { return (int)base.GetValue(CreateTaskForMultiCT.ListItemIdProperty); }
        }

        [Description("TaskProperties")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties TaskProperties
        {
            set { base.SetValue(CreateTaskForMultiCT.TaskPropertiesProperty, value); }
            get { return (Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties)base.GetValue(CreateTaskForMultiCT.TaskPropertiesProperty); }
        }

        [Description("ContentTypeId")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string ContentTypeId
        {
            set { base.SetValue(CreateTaskForMultiCT.ContentTypeIdProperty, value); }
            get { return (string)base.GetValue(CreateTaskForMultiCT.ContentTypeIdProperty); }
        }

        //[Description("WFName")]
        //[Browsable(true)]
        //[ValidationOption(ValidationOption.Required)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public string WFName
        //{
        //    set { base.SetValue(CreateTaskForMultiCT.WFNameProperty, value); }
        //    get { return (string)base.GetValue(CreateTaskForMultiCT.WFNameProperty); }
        //}

        [Description("Subject")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Subject
        {
            set { base.SetValue(CreateTaskForMultiCT.SubjectProperty, value); }
            get { return (string)base.GetValue(CreateTaskForMultiCT.SubjectProperty); }
        }

        [Description("Body")]
        [Browsable(true)]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Body
        {
            set { base.SetValue(CreateTaskForMultiCT.BodyProperty, value); }
            get { return (string)base.GetValue(CreateTaskForMultiCT.BodyProperty); }
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

            //HybridDictionary permsCollection = new HybridDictionary();
            //permsCollection.Add(createTaskWithContentType1_TaskProperties1.AssignedTo, SPRoleType.Contributor);
            //createTaskWithContentType1.SpecialPermissions = permsCollection;
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            ListItemId = createTaskWithContentType1_ListItemId1;
            string Name = string.Empty;
            string Email = string.Empty;

            string workListURL = string.Format("{0}/Lists/{1}/EditForm.aspx?ID={2}", __Context.Web.Url, "Tasks", ListItemId);

            //SPUtility.GetFullNameandEmailfromLogin(__Context.Web, createTaskWithContentType1_TaskProperties1.AssignedTo, out Name, out Email);

            Name = __Context.Web.Users[createTaskWithContentType1_TaskProperties1.AssignedTo].Name;
            Email = __Context.Web.Users[createTaskWithContentType1_TaskProperties1.AssignedTo].Email;

            //SPUtility.SendEmail(__Context.Web, false, false, Email, Subject, string.Format(Body, Name, workListURL));
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
        public String onTaskChanged1_Executor1 = default(System.String);

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

        public String logToHistoryListActivity4_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity4_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity4_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity4_HistoryDescription1 = string.Format("The task has been actioned by {0}", createTaskWithContentType1_TaskProperties1.AssignedTo);
            logToHistoryListActivity4_HistoryOutcome1 = string.Format("Task Actioned.");
        }

        #endregion

        #region THROW ERROR - TASK DELETED

        public String logToHistoryListActivity5_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity5_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity5_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity5_HistoryDescription1 = string.Format("Workflow cannot continue because related task(s) was deleted.");
            logToHistoryListActivity5_HistoryOutcome1 = string.Format("Task Id: {0}", ListItemId.ToString());
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
