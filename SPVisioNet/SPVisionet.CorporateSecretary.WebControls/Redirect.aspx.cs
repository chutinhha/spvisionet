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
    public partial class Redirect : System.Web.UI.Page
    {
        private Guid taskListId = Guid.Empty;
        private int taskItemId = 0;
        private string source = string.Empty;

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
            if (Request.QueryString["Source"] != null)
            {
                source = HttpUtility.UrlDecode(Request.QueryString["Source"]);
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

        protected void btnRedirect_Click(object sender, EventArgs e)
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

                        SPUser newUser = null;
                        string newAssignedTo = string.Empty;
                        try
                        {
                            newUser = webSA.SiteUsers[pe.CommaSeparatedAccounts];
                            newAssignedTo = newUser.ID.ToString();
                        }
                        catch
                        {
                            lbl.Text = "Redirect user is not valid.";
                            return;
                        }


                        SPFieldUserValue oldUserVal = new SPFieldUserValue(webSA, taskItem["AssignedTo"].ToString().Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        string oldAssignedTo = oldUserVal.User.LoginName.ToString();

                        SPRoleAssignmentCollection rolecoll = taskItem.RoleAssignments;
                        for (int i = rolecoll.Count - 1; i > -1; i--)
                        {
                            SPRoleAssignment item = rolecoll[i];
                            Type type = item.Member.GetType();
                            if (type.Name == "SPUser" && item.RoleDefinitionBindings[0].Name != "Read")
                            {
                                SPUser user = item.Member as SPUser;
                                if (oldAssignedTo.ToLower() == user.LoginName.ToLower())
                                {
                                    rolecoll.Remove(item.Member);
                                }
                            }
                        }

                        SPRoleDefinition ContributeRoleDefinition = taskItem.Web.RoleDefinitions["Contribute"];
                        SPRoleAssignment RoleAssignment = new SPRoleAssignment(newUser.LoginName, string.Empty, string.Empty, string.Empty);
                        RoleAssignment.RoleDefinitionBindings.Add(ContributeRoleDefinition);
                        taskItem.RoleAssignments.Add(RoleAssignment);

                        taskItem["AssignedTo"] = newAssignedTo;
                        taskItem.Update();

                        webSA.AllowUnsafeUpdates = false;

                        lbl.Text = "Successfully redirect task to user " + newUser.LoginName.ToLower();
                        pe.Enabled = false;
                        btnRedirect.Enabled = false;
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