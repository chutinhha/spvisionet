using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SPVisionet.CorporateSecretary.WebControls
{
    public partial class Delegate : System.Web.UI.Page
    {
        private Guid taskListId = Guid.Empty;
        private int taskItemId = 0;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Request.QueryString["ListID"] != null)
                taskListId = new Guid(HttpUtility.UrlDecode(Request.QueryString["ListID"]));

            if (Request.QueryString["IDP"] != null)
            {
                try
                {
                    taskItemId = Convert.ToInt32(Request.QueryString["IDP"]);
                }
                catch (Exception)
                {
                    taskItemId = 0;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
                LoadFormData();
        }

        private void LoadFormData()
        {
            try
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPList taskList = web.Lists[taskListId];
                SPListItem taskItem = taskList.GetItemById(taskItemId);


                ltlTitle.Text = Convert.ToString(taskItem["Title"]);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btnDelegate_Click(object sender, EventArgs e)
        {
            if (pe.CommaSeparatedAccounts == string.Empty)
            {
                lblErrorMsg.Visible = true;
                return;
            }

            try
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                using (SPSite site = new SPSite(web.Url, web.Site.SystemAccount.UserToken))
                {
                    using (SPWeb webSA = site.OpenWeb())
                    {
                        webSA.AllowUnsafeUpdates = true;

                        SPList taskList = webSA.Lists[taskListId];
                        SPListItem taskItem = taskList.GetItemById(taskItemId);

                        SPListItem targetItem = taskList.Items.Add();
                        foreach (SPField f in taskItem.Fields)
                        {
                            if (!f.ReadOnlyField && f.InternalName != "Attachments")
                            {
                                targetItem[f.InternalName] = taskItem[f.InternalName];
                            }
                        }

                        targetItem["WorkflowLink"] = taskItem["WorkflowLink"];
                        targetItem["WorkflowInstanceID"] = taskItem["WorkflowInstanceID"];
                        targetItem["ParentID"] = taskItem.ID;

                        SPUser newUser = null;
                        string newAssignedTo = string.Empty;
                        try
                        {
                            newUser = webSA.SiteUsers[pe.CommaSeparatedAccounts];
                            newAssignedTo = newUser.ID.ToString();
                        }
                        catch
                        {
                            lbl.Text = "Delegate user is not valid.";
                            return;
                        }

                        targetItem["AssignedTo"] = newAssignedTo;

                        targetItem.Update();

                        if (!targetItem.HasUniqueRoleAssignments)
                            targetItem.BreakRoleInheritance(false);

                        targetItem.Web.AllowUnsafeUpdates = true;

                        SPRoleDefinition ContributeRoleDefinition = targetItem.Web.RoleDefinitions["Contribute"];
                        SPRoleAssignment RoleAssignment = new SPRoleAssignment(newUser.LoginName, string.Empty, string.Empty, string.Empty);
                        RoleAssignment.RoleDefinitionBindings.Add(ContributeRoleDefinition);
                        targetItem.RoleAssignments.Add(RoleAssignment);

                        //targetItem.Update();

                        webSA.AllowUnsafeUpdates = false;

                        lbl.Text = "Successfully delegate task to user " + newUser.LoginName.ToLower();
                        pe.Enabled = false;
                        btnDelegate.Enabled = false;
                    }
                }
            }
            catch
            {
                lbl.Text = "Error. Please try again.";
            }
        }
    }
}