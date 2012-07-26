using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System.DirectoryServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Linq;
using SPVisioNet;

namespace SPVisioNet.NotifWorkflowConsole
{


    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string WorkflowName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Url { get; set; }
        public string ListName { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        
    }

    public class Notification
    {
        private SPWeb _spWeb;

        private string webUrl;
        public string WebUrl
        {
            get { return webUrl; }
            set { webUrl = value; }
        }

        private string listUrl;
        public string ListUrl
        {
            get { return listUrl; }
            set { listUrl = value; }
        }

        private string wf;
        public string Wf
        {
            get { return wf; }
            set { wf = value; }
        }

        private int day;
        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        private string from = @"agustox21@gmail.com";

        public string FromEmail
        {
            get { return from; }
            set { from = value; }
        }

        private string smtp = "localhost";
        public string SmtpServer
        {
            get { return smtp; }
            set { smtp = value; }
        }

        private int smtpPort = 25;
        public int SmtpPort
        {
            get { return smtpPort; }
            set { smtpPort = value; }
        }

        private string smtpUser = String.Empty;
        public string SmtpUser
        {
            get { return smtpUser; }
            set { smtpUser = value; }
        }

        private string smtpPass = String.Empty;
        public string SmtpPass
        {
            get { return smtpPass; }
            set { smtpPass = value; }
        }

        private string smtpDomain = String.Empty;
        public string SmtpDomain
        {
            get { return smtpDomain; }
            set { smtpDomain = value; }
        }

        private string logFileName = String.Empty;
        public string LogFileName
        {
            get { return logFileName; }
            set { logFileName = value; }
        }

        private string camlQuery;

        public string CamlQuery
        {
            get { return camlQuery; }
            set
            {

                camlQuery = ReplaceTime(value);
            }
        }
        private List<Message> arMessage = null;


        public Notification()
        {

        }

        private string ReplaceTime(string value)
        {
            if (!value.Contains("[TODAY]"))
                return value;
            int idx = value.IndexOf("[TODAY]");
            int openTag = value.IndexOf(">");
            int nextTag = 0;
            do
            {
                nextTag = value.IndexOf(">", openTag + 1);
                if (nextTag < idx && nextTag > 0)
                    openTag = nextTag;
                else
                    nextTag = -1;

            } while (nextTag > 0);

            nextTag = value.IndexOf("<", openTag);

            string timeVar = value.Substring(openTag + 1, nextTag - openTag - 1);
            idx = timeVar.IndexOf("-");
            if (idx > 0)
                try
                {
                    idx = -int.Parse(timeVar.Substring(idx + 1));
                }
                catch
                {
                    idx = 0;
                }
            else if ((idx = timeVar.IndexOf("+")) > 0)
            {
                try
                {
                    idx = int.Parse(timeVar.Substring(idx + 1));

                }
                catch
                {
                    idx = 0;
                }
            }
            else
            {
                idx = 0;
            }

            DateTime nowTime = DateTime.Now.AddDays(idx);

            StringBuilder sb = new StringBuilder();
            sb.Append(value.Substring(0, openTag + 1));
            sb.Append(SPUtility.CreateISO8601DateTimeFromSystemDateTime(nowTime));
            sb.Append(value.Substring(nextTag));

            return ReplaceTime(sb.ToString());

        }
        private bool CheckVariable()
        {
            if (String.IsNullOrEmpty(WebUrl))
                return false;
            if (!(WebUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) || WebUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase)))
                return false;
            if (String.IsNullOrEmpty(ListUrl))
                return false;

            return true;
        }

        private string getServerRelative(string url)
        {
            string reg = @"(?:http|https)://[\w\.\:0-9]*(?<serverRelative>/.*)";
            Regex regex = new Regex(reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return regex.Replace(url, "${serverRelative}");
        }

        public static string CreateSharePointListStrUrl(string webUrl, string listNameWhenCreated)
        {
            return string.Format("{0}/Lists/{1}", webUrl, listNameWhenCreated);
        }

        public static string GetSettingValue(SPWeb web, string Category, string Title)
        {
            string ReturnValue = string.Empty;
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                            "<And>" +
                                "<Eq>" +
                                    "<FieldRef Name=\"Category\" /><Value Type=\"Text\">" + Category + "</Value>" +
                                "</Eq>" +
                                "<Eq>" +
                                    "<FieldRef Name=\"Title\" /><Value Type=\"Text\">" + Title + "</Value>" +
                                "</Eq>" +
                            "</And>" +
                          "</Where>";
            SPListItemCollection itemConfig = web.GetList(CreateSharePointListStrUrl(web.Url, "Settings")).GetItems(query);
            try
            {
                if (itemConfig.Count > 0)
                    ReturnValue = itemConfig[0]["Value"].ToString();
                else
                    ReturnValue = string.Empty;
            }
            catch (Exception)
            {
                ReturnValue = string.Empty;
            }

            return ReturnValue;
        }

        public static SPListItemCollection GetNotificationSetting(SPWeb web, string Module)
        {
            string ReturnValue = string.Empty;
            SPQuery query = new SPQuery();
            query.Query = string.Format(@"<Where>
                                  <Eq>
                                     <FieldRef Name='Title' />
                                     <Value Type='Text'>{0}</Value>
                                  </Eq>
                               </Where>
                               <OrderBy>
                                  <FieldRef Name='ListUrl' Ascending='True' />
                                  <FieldRef Name='ID' Ascending='True' />
                               </OrderBy>", Module);

            SPListItemCollection items = web.GetList(CreateSharePointListStrUrl(web.Url, "NotificationSetting")).GetItems(query);
            return items;
        }

        public void SetMessage(SPWeb web, string listName, string Caml, string field)
        {
            string fieldName = string.Empty;
            string fieldType = string.Empty;
            SPQuery query = new SPQuery();
            query.Query = Caml;
            string toEmail = string.Empty;
            SPList list = web.GetList(CreateSharePointListStrUrl(web.Url, listName));

            foreach (SPField fieldList in list.Fields)
            {
                if (fieldList.InternalName.Equals(field))
                {
                    fieldName = fieldList.Title;
                    fieldType = fieldList.FieldValueType.FullName;
                    break;
                }
            }

            SPListItemCollection items = list.GetItems(query);

            foreach (SPListItem item in items)
            {
                toEmail = GetEmailUser(item);
                if (!string.IsNullOrEmpty(toEmail))
                {
                    Message msg = new Message();
                    msg.Id = item.ID;
                    msg.ListName = list.Title;
                    msg.Title = item["Title"].ToString();
                    msg.FieldName = fieldName;

                    if (fieldType.Equals("System.DateTime"))
                        msg.FieldValue = (item[field] != null ? Convert.ToDateTime(item[field]).ToString("dd/MM/yyyy") : string.Empty);
                    else
                        msg.FieldValue = (item[field] != null ? item[field].ToString() : string.Empty);

                    msg.Url = items[0].Web.Url + items[0].ListItems.List.DefaultEditFormUrl + "?ID=" + items[0].ID.ToString();
                    if (toEmail.Substring(toEmail.Length - 1, 1).Equals(";"))
                        toEmail = toEmail.Substring(0, toEmail.Length - 1);
                    msg.UserEmail = toEmail;
                    arMessage.Add(msg);
                }

            }
        }

        public void Process()
        {
            string emailTemplate = string.Empty;
            string listUrl = string.Empty;
            string caml = string.Empty;
            string field = string.Empty;

            if (!CheckVariable())
            {
                return;
            }

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                using (SPSite site = new SPSite(WebUrl))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        emailTemplate = GetSettingValue(web, "Email", "NotifWorkflowConsole");
                        SPListItemCollection items = GetNotificationSetting(web, "NotifWorkflowConsole");

                        arMessage = new List<Message>();

                        foreach (SPListItem item in items)
                        {
                            listUrl = item["ListUrl"].ToString();
                            caml = item["CAML"].ToString();
                            field = item["Field"].ToString();
                            SetMessage(web, listUrl, caml, field);
                        }

                        if (arMessage.Count > 0)
                        {
                            var msgList = from msg in arMessage
                                          orderby msg.UserEmail ascending, msg.ListName
                                          select msg;

                            List<Message> list1Message = msgList.ToList();
                            List<Message> list2Message = new List<Message>();

                            for (int i = 0; i < list1Message.Count; i++)
                            {

                                if (i != 0 && list1Message.Count() > i)
                                {

                                    if (!list1Message[i].UserEmail.Equals(list1Message[i - 1].UserEmail))
                                    {
                                        StartNotify(list2Message, emailTemplate);
                                        list2Message.Clear();
                                        list2Message.Add(list1Message[i]);
                                    }
                                    else
                                    {
                                        list2Message.Add(list1Message[i]);
                                    }

                                    if (i + 1 >= list1Message.Count())
                                    {
                                        StartNotify(list2Message, emailTemplate);
                                    }

                                }
                                else if (list1Message.Count() == 1)
                                {
                                    list2Message.Add(list1Message[i]);
                                    StartNotify(list2Message, emailTemplate);
                                }
                                else
                                {
                                    list2Message.Add(list1Message[i]);
                                }
                            }

                        }
                      
                    }
                }
            });
        }

        private void StartNotify(List<Message> arMessage, string emailTemplate)
        {
            string subject = "Reminder your pending task";
            int i = 1;
            StringBuilder pendingTask = new StringBuilder();
            pendingTask.Append("<table border='1' cellpadding='1' cellspacing='1' style='font-size:11px;font-family:Verdana'>");
            pendingTask.Append("<tr>");
            pendingTask.Append("<td>");
            pendingTask.AppendFormat("No.");
            pendingTask.Append("</td>");
            pendingTask.Append("<td>");
            pendingTask.AppendFormat("Task");
            pendingTask.Append("</td>");
            pendingTask.Append("<td>");
            pendingTask.AppendFormat("Workflow");
            pendingTask.Append("</td>");
            pendingTask.Append("</tr>");

            foreach (Message msg in arMessage)
            {
                pendingTask.Append("<tr>");
                pendingTask.Append("<td>");
                pendingTask.Append(i);
                pendingTask.Append("</td>");
                pendingTask.Append("<td>");
                pendingTask.AppendFormat("<a href='{0}'>{1}</a>", msg.Url, msg.Title);
                pendingTask.Append("</td>");
                pendingTask.Append("<td>");
                pendingTask.Append(msg.WorkflowName);
                pendingTask.Append("</td>");
                pendingTask.Append("</tr>");
                i++;
            }
            pendingTask.Append("</table>");

            string template = string.Format(emailTemplate, arMessage[0].UserName, pendingTask.ToString(), WebUrl);
            string toEmail = arMessage[0].UserEmail;

            CreateFile(template + "\n\n\n", LogFileName);
            if (!string.IsNullOrEmpty(toEmail))
                SendMail(subject, toEmail, template);
            template = string.Empty;
        }

        private string GetEmailUser(SPListItem item)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0; ;
            string s = string.Empty;
            int totalRoleAssignment = item.RoleAssignments.Count;

            for (i = 0; i < totalRoleAssignment; i++)
            {
                SPRoleAssignment roleAssignment = item.RoleAssignments[i];
                SPPrincipal prinsipal = roleAssignment.Member;

                if (roleAssignment.RoleDefinitionBindings[0].Name.Equals("Full Control") || roleAssignment.RoleDefinitionBindings[0].Name.Equals("Contribute") || roleAssignment.RoleDefinitionBindings[0].Name.Equals("Design"))
                {
                    if (prinsipal is SPUser)
                    {

                        if (!string.IsNullOrEmpty(((SPUser)prinsipal).Email))
                        {
                            if (!sb.ToString().Contains(((SPUser)prinsipal).Email))
                                sb.Append(((SPUser)prinsipal).Email + ";");
                        }
                        else
                        {
                            s = GetuserPrincipalName(GetuserPrincipalName(((SPUser)prinsipal).LoginName));
                            if (!string.IsNullOrEmpty(s))
                            {
                                if (!sb.ToString().Contains(s))
                                    sb.Append(s + ";");
                            }
                        }

                    }
                    else if (prinsipal is SPGroup)
                    {
                        SPGroup group = (SPGroup)prinsipal;
                        foreach (SPUser user in group.Users)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(user.Email))
                                {
                                    if (!sb.ToString().Contains(user.Email))
                                        sb.Append(user.Email + ";");
                                }
                                else
                                {
                                    s = GetuserPrincipalName(user.LoginName);
                                    {
                                        if (!sb.ToString().Contains(s))
                                            if (!string.IsNullOrEmpty(s)) sb.Append(s + ";");
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }

            }

            return sb.ToString();
        }

        private string GetuserPrincipalName(string userName)
        {

            string defaultNamingContext = string.Empty;
            string ldapPath = string.Empty;

            using (DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE"))
            {
                defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();
                ldapPath = "LDAP://" + defaultNamingContext;
            }

            using (DirectoryEntry root = new DirectoryEntry(ldapPath))
            {
                DirectorySearcher search = new DirectorySearcher(root);
                search.Filter = "(&(objectClass=user)(sAMAccountName=" + userName.Split('\\')[1] + "))";
                search.PropertiesToLoad.Add("userPrincipalName");
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    ResultPropertyValueCollection property = result.Properties["userPrincipalName"];
                    return property[0].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }

        }



        private void SendMail(string subject, string toEmail, string bodyMessage)
        {
            SmtpClient sendmail = new SmtpClient(SmtpServer, smtpPort);

            if (!String.IsNullOrEmpty(SmtpUser) && !String.IsNullOrEmpty(SmtpPass) && string.IsNullOrEmpty(SmtpDomain))
                sendmail.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPass);
            else if (!String.IsNullOrEmpty(SmtpUser) && !String.IsNullOrEmpty(SmtpPass) && !string.IsNullOrEmpty(SmtpDomain))
                sendmail.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPass, SmtpDomain);

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(FromEmail, toEmail);
            msg.Subject = subject;
            msg.Priority = MailPriority.High;
            msg.IsBodyHtml = true;
            msg.Body = bodyMessage;

            try
            {
                sendmail.Send(msg);
            }
            catch
            {

            }
            msg.Dispose();

        }

        private void CreateFile(string s, string filename)
        {
            string appName = Environment.CurrentDirectory;
            string path = appName + "/" + filename;
            s += "\n[- " + DateTime.Today.ToString() + " --------------------------------------------------------------------------------------------]";
            //if (File.Exists(path))
            //{
            //    File.Delete(path);
            //}

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(s);
            }
        }

    }
}

