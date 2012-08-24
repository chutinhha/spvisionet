using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruIndonesiaWorkflow
{
    public sealed partial class PendirianPerusahaanBaruIndonesiaWorkflow : SequentialWorkflowActivity
    {
        public PendirianPerusahaanBaruIndonesiaWorkflow()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        bool _isTask1Complete = false;

        private void onWorkflowActivated1_Invoked(object sender, ExternalDataEventArgs e)
        {
            workflowId = workflowProperties.WorkflowId;
        }




        public Guid createTask1_TaskId1 = default(System.Guid);
        public SPWorkflowTaskProperties createTask1_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        private void createTask1_MethodInvoking(object sender, EventArgs e)
        {
            SPWorkflowTaskProperties childTaskProperties = new SPWorkflowTaskProperties();
            childTaskProperties.Title = "x";
            childTaskProperties.AssignedTo = "corp\\nibor";
            childTaskProperties.PercentComplete = 0;

            createTask1_TaskProperties1 = childTaskProperties;
            createTask1_TaskId1 = Guid.NewGuid();
        }
    }
}
