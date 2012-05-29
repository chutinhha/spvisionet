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

namespace InfinysWorkflowPrj.WFBasicApproval.OneApproval
{
    public sealed partial class OneApproval : SequentialWorkflowActivity
    {
        public string title = string.Empty;
        public string approvalName = string.Empty;
        public string approvalEmail = string.Empty;
        public string approvalLogon = string.Empty;
        public bool taskCompleted = false;
        public string ContentTypeID = string.Empty;
        private const string ContentType = "ApprovalRejectContentTypeCT";
        private string ApprovalAction = string.Empty;

        public Guid TaskId = default(System.Guid);
        public SPWorkflowTaskProperties createTaskWithContentType1_TaskProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public SPWorkflowTaskProperties onTaskChanged1_AfterProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public SPWorkflowTaskProperties onTaskChanged1_BeforeProperties1 = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        public OneApproval()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();


        private SPContentType GetContentType()
        {
            SPContentType contentType = null;

            foreach (SPContentType cp in workflowProperties.TaskList.ContentTypes)
            {
                if (cp.Name == ContentType)
                {
                    contentType = cp;
                    ContentTypeID = cp.Id.ToString();
                    break;
                }
            }
            return contentType;
        }

        public void VerifyModifyTaskList(SPList taskList, string contentType)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(workflowProperties.Item.Web.Site.ID))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList task = web.Lists[workflowProperties.TaskListId];

                        if (taskList.ContentTypesEnabled != true)
                        {
                            workflowProperties.TaskList.ContentTypesEnabled = true;
                        }

                        foreach (SPContentType cp in web.ContentTypes)
                        {
                            if (cp.Name.Equals(contentType))
                            {

                                SPContentType cp1 = task.ContentTypes.Add(cp);
                                task.Update();
                                ContentTypeID = cp1.Id.ToString();
                                break;
                            }
                        }
                    }
                }
            });
        }

        private void onWorkflowActivated1_Invoked_1(object sender, ExternalDataEventArgs e)
        {
            ContentTypeID = string.Empty;
            ApprovalAction = string.Empty;
            SPContentType cp = GetContentType();

            if (cp == null)
            {
                VerifyModifyTaskList(workflowProperties.TaskList, ContentType);
                cp = GetContentType();
            }
        }

        private void onWorkflowItemChanged1_Invoked(object sender, ExternalDataEventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;
            if (workflowProperties.Item["Approver"] != null)
            {
                SPUser user = new SPFieldUserValue(web, workflowProperties.Item["Approver"].ToString()).User;
                approvalName = user.Name;
                approvalEmail = user.Email;
                approvalLogon = user.LoginName;
            }
        }

        private void CheckApprovalInput(object sender, ConditionalEventArgs e)
        {
            e.Result = string.IsNullOrEmpty(approvalName);
        }

        private void createTaskWithContentType1_MethodInvoking(object sender, EventArgs e)
        {
            TaskId = Guid.NewGuid();

            try
            {
                createTaskWithContentType1_TaskProperties1.ExtendedProperties["ApproveOrReject"] = "No Action";
                createTaskWithContentType1_TaskProperties1.AssignedTo = approvalLogon;
                createTaskWithContentType1_TaskProperties1.Title = "Need Approval: " + workflowProperties.Item["Name"].ToString();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                throw;
            }
        }

        private void onTaskChanged1_Invoked(object sender, ExternalDataEventArgs e)
        {
            SPWeb web = workflowProperties.Item.Web;
            SPListItem item = web.Lists[workflowProperties.TaskListId].GetItemById(onTaskChanged1_AfterProperties1.TaskItemId);

            if (item["ApproveOrReject"] != null)
            {
                ApprovalAction = item["ApproveOrReject"].ToString();
                SPUser user = new SPFieldUserValue(web, item["Editor"].ToString()).User;
                approvalLogon = user.LoginName; 
                approvalEmail = user.Email;
                approvalName = user.Name; 
            }
        }

        private void CheckApprovalAction(object sender, ConditionalEventArgs e)
        {
            e.Result = true;
            if (ApprovalAction.Equals("Approved") || ApprovalAction.Equals("Rejected"))
            {
                e.Result = false;
            }

        }

        public String logToHistoryListActivity1_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity1_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity1_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity1_HistoryDescription1 = string.Format("Prepare create task for {0}", approvalName + "," + approvalLogon);
            logToHistoryListActivity1_HistoryOutcome1 = string.Empty;
        }

        public String logToHistoryListActivity2_HistoryDescription1 = default(System.String);
        public String logToHistoryListActivity2_HistoryOutcome1 = default(System.String);

        private void logToHistoryListActivity2_MethodInvoking(object sender, EventArgs e)
        {
            logToHistoryListActivity2_HistoryDescription1 = string.Format("Task Completed by {0}", approvalName + "," + approvalLogon);
            logToHistoryListActivity2_HistoryOutcome1 = string.Empty;
        }

    }
}
