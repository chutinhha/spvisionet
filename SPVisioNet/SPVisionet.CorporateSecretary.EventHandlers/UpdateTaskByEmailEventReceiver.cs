using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections;
using Microsoft.SharePoint.Workflow;

namespace SPVisionet.CorporateSecretary.EventHandlers
{
    public class UpdateTaskByEmailEventReceiver : SPEmailEventReceiver
    {
        public override void EmailReceived(SPList list, SPEmailMessage emailMessage, String receiverData)
        {
            base.EmailReceived(list, emailMessage, receiverData);
            SPListItem item = list.Items.Add();
            item["Title"] = emailMessage.Headers["Subject"];
            item["Body"] = emailMessage.HtmlBody;
            item["EmailFrom"] = emailMessage.Sender;
            item.Update();

            using (SPSite site = new SPSite(list.ParentWeb.Site.Url, list.ParentWeb.Site.SystemAccount.UserToken))
            {
                using (SPWeb webSA = site.OpenWeb())
                {
                    string Status = string.Empty;
                    string Body = emailMessage.HtmlBody;
                    if (Body.ToLower().Contains("approve") || Body.ToLower().Contains("approved"))
                        Status = "Approve";
                    else if (Body.ToLower().Contains("reject") || Body.ToLower().Contains("rejected"))
                        Status = "Reject";

                    if (Status != string.Empty)
                    {
                        Regex r;
                        Match m;
                        string url = string.Empty;
                        int ID = 0;
                        r = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
                        for (m = r.Match(Body); m.Success; m = m.NextMatch())
                        {
                            if (m.Groups[1].ToString().Contains("ID="))
                                url = m.Groups[1].ToString();
                        }

                        if (url != string.Empty)
                        {
                            Uri tempUri = new Uri(string.Format("http://sharepoint{0}", url));
                            string sQuery = tempUri.Query;
                            ID = Convert.ToInt32(HttpUtility.ParseQueryString(sQuery).Get("ID"));
                        }

                        if (ID != 0)
                        {
                            try
                            {
                                webSA.AllowUnsafeUpdates = true;
                                SPList taskList = webSA.Lists["Tasks"];
                                SPListItem taskItem = taskList.GetItemById(ID);

                                Hashtable taskData = new Hashtable();
                                taskData.Add("PercentComplete", 1);
                                taskData.Add("Completed", true);
                                taskData.Add("ApproveOrReject", Status);
                                taskData.Add("Status", "Completed");
                                taskData.Add("Remarks", string.Empty);
                                SPWorkflowTask.AlterTask(taskItem, taskData, true);
                                taskItem.Update();

                                if (taskItem["ParentID"] != null)
                                {
                                    SPListItem taskItemParent = taskList.GetItemById(Convert.ToInt32(taskItem["ParentID"].ToString()));
                                    SPWorkflowTask.AlterTask(taskItemParent, taskData, true);
                                    taskItemParent.Update();
                                }
                                webSA.AllowUnsafeUpdates = false;
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}
