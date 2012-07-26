using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Utilities;

namespace SPVisionet.CorporateSecretary.Workflow.Layouts.SPVisionet.CorporateSecretary.Workflow.ToDoTaskCT
{
    public partial class ToDoTaskCT_Display : LayoutsPageBase
    {
        #region Fields

        private Guid taskListId = Guid.Empty;
        private int taskItemId = 0;
        private string source = string.Empty;

        #endregion

        #region Event Handlers

        /// <summary>
        /// Raises the init event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Request.QueryString["List"] != null)
                taskListId = new Guid(HttpUtility.UrlDecode(Request.QueryString["List"]));

            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    taskItemId = Convert.ToInt32(Request.QueryString["ID"]);
                }
                catch (Exception)
                {
                    taskItemId = 0;
                }
            }

            if (Request.QueryString["Source"] != null)
            {
                source = HttpUtility.UrlDecode(Request.QueryString["Source"]);
            }
        }

        /// <summary>
        /// Raises the load event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs"/> instance containing the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
                LoadFormData();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SPWeb web = SPControl.GetContextWeb(this.Context);
            if (source != string.Empty)
                SPUtility.Redirect("Default.aspx", SPRedirectFlags.UseSource, this.Context);
            else
                Response.Redirect(web.Url, true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the form data.
        /// </summary>
        private void LoadFormData()
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPWeb web = SPControl.GetContextWeb(this.Context);
                    SPList taskList = web.Lists[taskListId];
                    SPListItem taskItem = taskList.GetItemById(taskItemId);

                    ltlTitle.Text = Convert.ToString(taskItem["Title"]);
                    ltlStatus.Text = Convert.ToString(taskItem["Status"]);

                    string[] relatedItemLink = Convert.ToString(taskItem["WorkflowLink"]).Split(',');
                    linkRelatedItem.Target = "_blank";
                    linkRelatedItem.NavigateUrl = relatedItemLink[0].Trim();
                    linkRelatedItem.Text = relatedItemLink[1].Trim();
                });
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        #endregion
    }
}