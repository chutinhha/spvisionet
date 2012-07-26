using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using SPVisionet.CorporateSecretary.Common;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;
using System.Collections;
using Microsoft.SharePoint.Workflow;
using Microsoft.Office.DocumentManagement.DocumentSets;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            SPSite site = new SPSite("http://server2008r2");
            SPWeb web = site.OpenWeb();

            SPDocumentLibrary list = (SPDocumentLibrary)web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PerusahaanBaruDokumen"));
            System.Collections.Hashtable properties = new System.Collections.Hashtable();
            //properties.Add("DocumentSetDescription", "My first Document Set by Code"); //InternalName
            properties.Add("PerusahaanBaru", 18); //InternalName

            // Creating the document set
            SPContentType ctype = web.ContentTypes["Document Set"];
            DocumentSet.Create(list.RootFolder, "My First Document Set", list.ContentTypes.BestMatch(ctype.Id), properties, true);
            
            SPList documentPendirianPerusahaanBaru = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PendirianPerusahaanBaruIndonesiaDokumen"));
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<And>" +
                                "<Contains>" +
                                     "<FieldRef Name='LK_x003a_NamaPerusahaan' />" +
                                     "<Value Type='Lookup'>xxx</Value>" +
                                 "</Contains>" +
                                 "<Eq>" +
                                     "<FieldRef Name='LK_x003a_ApprovalStatus' />" +
                                     "<Value Type='Text'>Approved</Value>" +
                                 "</Eq>" +
                             "</And>" +
                          "</Where>";
            //query.ViewAttributes = "Scope=\"Recursive\"";
            query.Folder = documentPendirianPerusahaanBaru.ParentWeb.GetFolder("/PendirianPerusahaanBaruIndonesiaDokumen/Akta");

            SPListItemCollection coll = documentPendirianPerusahaanBaru.GetItems(query);
            if (coll.Count > 0)
            {
            }

            //int i = DateTime.Compare(DateTime.Now.AddDays(1).Date, DateTime.Now.Date);
            //if (i > 0)
            //{
            //}

            //SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "UpdateTaskByEmail"));
            //SPListItem item = list.GetItemById(43);

            //string Status = string.Empty;
            //string Body = item["Body"].ToString();
            //if (Body.ToLower().Contains("approve") || Body.ToLower().Contains("approved"))
            //    Status = "Approve";
            //else if (Body.ToLower().Contains("reject") || Body.ToLower().Contains("rejected"))
            //    Status = "Reject";

            //if (Status != string.Empty)
            //{
            //    Regex r;
            //    Match m;
            //    string url = string.Empty;
            //    int ID = 0;
            //    r = new Regex("href\\s*=\\s*(?:\"(?<1>[^\"]*)\"|(?<1>\\S+))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //    for (m = r.Match(Body); m.Success; m = m.NextMatch())
            //    {
            //        if (m.Groups[1].ToString().Contains("ID="))
            //            url = m.Groups[1].ToString();
            //    }

            //    if (url != string.Empty)
            //    {
            //        Uri tempUri = new Uri(string.Format("http://sharepoint{0}", url));
            //        string sQuery = tempUri.Query;
            //        ID = 187;
            //    }

            //    if (ID != 0)
            //    {
            //        try
            //        {
            //            web.AllowUnsafeUpdates = true;
            //            SPList taskList = web.Lists["Tasks"];
            //            SPListItem taskItem = taskList.GetItemById(ID);

            //            Hashtable taskData = new Hashtable();
            //            taskData.Add("PercentComplete", 1);
            //            taskData.Add("Completed", true);
            //            taskData.Add("ApproveOrReject", Status);
            //            taskData.Add("Status", "Completed");
            //            taskData.Add("Remarks", string.Empty);
            //            SPWorkflowTask.AlterTask(taskItem, taskData, true);

            //            if (taskItem["ParentID"] != null)
            //            {
            //                SPListItem taskItemParent = taskList.GetItemById(Convert.ToInt32(taskItem["ParentID"].ToString()));
            //                SPWorkflowTask.AlterTask(taskItemParent, taskData, true);
            //            }
            //            web.AllowUnsafeUpdates = false;
            //        }
            //        catch
            //        {
            //        }
            //    }
        }

        //string a = Util.GenerateRequestCode(web, RequestCode.IZIN_USAHA, DateTime.Now.Month, DateTime.Now.Year);

        //SPQuery query = new SPQuery();
        //query.Query = "<Where>" +
        //                  "<Eq>" +
        //                     "<FieldRef Name='PendirianPerusahaanBaruIndonesia' LookupId='True' />" +
        //                     "<Value Type='Lookup'>3</Value>" +
        //                  "</Eq>" +
        //              "</Where>" +
        //              "<OrderBy>" +
        //                "<FieldRef Name='Created' Ascending='False' />" +
        //              "</OrderBy>";

        //SPList documentPendirianPerusahaanBaru = web.GetList(Util.CreateSharePointDocLibStrUrl(web.Url, "PendirianPerusahaanBaruIndonesiaDokumen"));
        //query.Folder = documentPendirianPerusahaanBaru.ParentWeb.GetFolder("/PendirianPerusahaanBaruIndonesiaDokumen/SKDP");
        //SPListItemCollection collPKP = documentPendirianPerusahaanBaru.GetItems(query);
        //if (collPKP.Count > 0)
        //{
        //    SPListItem documentItem = collPKP[0];
        //}

        //StringCollection sc = new StringCollection();
        //SPQuery query = new SPQuery();
        //query.Query = "<Where>" +
        //                  "<Eq>" +
        //                     "<FieldRef Name='Role' />" +
        //                     "<Value Type='Choice'>Tax</Value>" +
        //                  "</Eq>" +
        //              "</Where>";

        //SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "ListApproval"));
        //SPListItemCollection coll = list.GetItems(query);
        //if (coll.Count > 0)
        //{
        //    SPListItem item = coll[0];
        //    SPFieldUser userField = item.Fields["User"] as SPFieldUser;
        //    SPFieldUserValueCollection userValueColl = (SPFieldUserValueCollection)userField.GetFieldValue(item["User"].ToString());

        //    string LoginName = string.Empty;
        //    string Email = string.Empty;
        //    foreach (var userValue in userValueColl)
        //    {
        //        if (LoginName == string.Empty)
        //            LoginName = userValue.User.LoginName;
        //        else
        //            LoginName += ";" + userValue.User.LoginName;

        //        if (Email == string.Empty)
        //            Email = userValue.User.Email;
        //        else
        //            Email += ";" + userValue.User.Email;
        //    }
        //    sc.Add(LoginName);
        //    sc.Add(Email);
        //}
        //}
    }
}
