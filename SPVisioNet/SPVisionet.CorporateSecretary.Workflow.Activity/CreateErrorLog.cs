using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint;

namespace SPVisionet.CorporateSecretary.Workflow.Activity
{
    public partial class CreateErrorLog : System.Workflow.ComponentModel.Activity
    {
        #region Static Fields
        public static DependencyProperty WorkflowPropertiesProperty =
          DependencyProperty.Register("WorkflowProperties", typeof(SPWorkflowActivationProperties), typeof(CreateErrorLog));

        public static DependencyProperty WorkflowExceptionProperty =
          DependencyProperty.Register("WorkflowException", typeof(Exception), typeof(CreateErrorLog));

        /*
        public static DependencyProperty MethodInvokingEvent = 
          DependencyProperty.Register("MethodInvoking", typeof(EventHandler), typeof(CreateErrorLogItem));
        */
        #endregion

        #region Fields

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        [Category("Custom Properties"), Browsable(true)]
        [Description("SharePoint Workflow Activation Properties")]
        [ValidationOption(ValidationOption.Required)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public SPWorkflowActivationProperties WorkflowProperties
        {
            set { this.SetValue(WorkflowPropertiesProperty, value); }
            get { return (SPWorkflowActivationProperties)this.GetValue(WorkflowPropertiesProperty); }
        }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        [Category("Custom Properties"), Browsable(true)]
        [Description("Workflow Exception that needs to be log.")]
        [ValidationOption(ValidationOption.Optional)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Exception WorkflowException
        {
            set { this.SetValue(WorkflowExceptionProperty, value); }
            get { return (Exception)this.GetValue(WorkflowExceptionProperty); }
        }

        #region Event Handler Properties
        /*
    [Category("Custom Properties"), Browsable(true)]
    [DescriptionAttribute("Method Invoking")]
    [ValidationOption(ValidationOption.Optional)]
    [DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Visible)]
    /// <summary>
    /// Method Invoking (event handler).
    /// </summary>
    /// <value>The event handler.</value>   
    public event EventHandler MethodInvoking
    {
      add
      {
        base.AddHandler(MethodInvokingEvent, value);
      }
      remove
      {
        base.RemoveHandler(MethodInvokingEvent, value);
      }
    }
    */
        #endregion
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateErrorLogItem"/> class.
        /// </summary>
        public CreateErrorLog()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Executes the activity.
        /// </summary>
        /// <param name="executionContext">The execution context of the activity.</param>
        /// <returns>
        /// The <see cref="T:System.Workflow.ComponentModel.ActivityExecutionStatus"/> of the activity after executing the activity.
        /// </returns>
        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            //this.RaiseEvent(MethodInvokingEvent, this, EventArgs.Empty);
            CreateItem();

            return ActivityExecutionStatus.Closed;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates the item.
        /// </summary>
        private void CreateItem()
        {
            SPWorkflowActivationProperties workflowProps = this.WorkflowProperties;
            Exception workflowException = this.WorkflowException;
            SPSite site = workflowProps.Site;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPSite saSite = new SPSite(site.Url);
                SPWeb saWeb = saSite.OpenWeb();
                SPListCollection lists = saWeb.Lists;
                SPList list = lists["WFErrorLog"];

                SPListItem listItem = list.Items.Add();
                listItem["Title"] = workflowProps.TemplateName;
                listItem["Message"] = workflowException.Message;
                listItem["Source"] = workflowException.Source;
                listItem["TargetSite"] = workflowException.TargetSite;
                listItem["StackTrace"] = workflowException.StackTrace;

                if (workflowException.InnerException != null)
                    listItem["InnerException"] = workflowException.InnerException.Message;

                listItem.Update();
            });
        }
        #endregion
    }
}
