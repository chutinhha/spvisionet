using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.IO;
using System.DirectoryServices;

namespace SPVisioNet.NotificationConsole
{
    public class Notification
    {
        private SPWeb _spWeb;

        private string listUrl;

        public string ListUrl
        {
            get { return listUrl; }
            set { listUrl = value; }
        }


        private string from = @"agustox21@gmail.com";

        public string FromEmail
        {
            get { return from; }
            set { from = value; }
        }

        private string toEmail;

        public string ToEmail
        {
            get { return toEmail; }
            set { toEmail = value; }
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


        private string camlQuery;

        public string CamlQuery
        {
            get { return camlQuery; }
            set
            {

                camlQuery = ReplaceTime(value);
            }
        }

        
        public Notification()
        {

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
            if (String.IsNullOrEmpty(ListUrl))
                return false;
            if (!(ListUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) || ListUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase)))
                return false;
            if (String.IsNullOrEmpty(CamlQuery))
                return false;

            return true;
        }

        private string getServerRelative(string url)
        {
            string reg = @"(?:http|https)://[\w\.\:0-9]*(?<serverRelative>/.*)";
            Regex regex = new Regex(reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            return regex.Replace(url, "${serverRelative}");
        }

        public void Process()
        {

            if (!CheckVariable())
            {
                return;
            }

            _spWeb = new SPSite(ListUrl).OpenWeb();

            SPQuery query = new SPQuery();
            query.Query = CamlQuery;
            query.ViewAttributes = "Scope=\"Recursive\"";

            foreach (SPList list in _spWeb.Lists)
            {
                if (list.Hidden == false)
                {
                    try
                    {
                        SPListItemCollection Items = list.GetItems(query);
                        foreach (SPListItem item in Items)
                        {
                            StartNotify(item);
                        }
                    }
                    catch { }
                }
            }
        }

        private void StartNotify(SPListItem item)
        {
            StringBuilder sb = new StringBuilder();
            string sIndex = string.Empty;
            string listUrl = item.Web.Url;

            string toEmail = GetEmailUser(item);
            string subject = "[eDoc] Document Expiration Notify";
            sb.Append(string.Format("<a href='{0}' title='{1}'>{2}</><br/><br/>Following document has been expired : <br/><br/>", listUrl, listUrl, listUrl));
            sb.Append("<a href='{0}'>{1}</a> is expiring at {2} and to edit index click <a href='{3}' title='edit index'>here</a>. <br/>");
            sIndex = listUrl + "/Forms/EditForm.aspx?ID=" + item.ID.ToString();
            sb.Append(String.Format(sb.ToString(), item.Web.Url + "/" + item.Url, item["Title"], item["Period_x0020_End_x0020_Date"].ToString(), sIndex));

            if (!string.IsNullOrEmpty(toEmail))
                SendMail(toEmail, sb.ToString());
            sb = null;
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

        private void StartNotify(SPListItemCollection items)
        {
            string sIndex = string.Empty;
            if (String.IsNullOrEmpty(ToEmail))
                return;
            SmtpClient sendmail = new SmtpClient(SmtpServer, smtpPort);

            if (!String.IsNullOrEmpty(SmtpUser) && !String.IsNullOrEmpty(SmtpPass))
                sendmail.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPass);

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(FromEmail, ToEmail);
            msg.Subject = "[eDoc] Document Expiration Notify";
            msg.Priority = MailPriority.High;
            msg.IsBodyHtml = true;
            //msg.Priority = "High";

            StringBuilder sb = new StringBuilder();
            msg.Body = string.Format("<a href='{0}' title='{1}'>{2}</><br/><br/>Following document has been expired : <br/><br/>", listUrl, listUrl, listUrl);

            sb.Append("<a href='{0}'>{1}</a> is expiring at {2} and to edit index click <a href='{3}' title='edit index'>here</a>. <br/>");
            foreach (SPListItem item in items)
            {
                //msg.Subject += item["Title"];
                sIndex = listUrl + "/Forms/EditForm.aspx?ID=" + item.ID.ToString();

                msg.Body += String.Format(sb.ToString(),
                    item.Web.Url + "/" + item.Url, item["Title"]
                    , item["Period_x0020_End_x0020_Date"].ToString()
                    , sIndex
                    );
                CreateFile(msg.Body);
            }
            msg.Body += "Please verify! <br><br>Document Admin";

            try
            {
                sendmail.Send(msg);
            }
            catch
            {

            }

        }

        private void SendMail(string toEmail, string bodyMessage)
        {
            SmtpClient sendmail = new SmtpClient(SmtpServer, smtpPort);

            if (!String.IsNullOrEmpty(SmtpUser) && !String.IsNullOrEmpty(SmtpPass) && string.IsNullOrEmpty(SmtpDomain))
                sendmail.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPass);
            else if (!String.IsNullOrEmpty(SmtpUser) && !String.IsNullOrEmpty(SmtpPass) && !string.IsNullOrEmpty(SmtpDomain))
                sendmail.Credentials = new System.Net.NetworkCredential(SmtpUser, SmtpPass,SmtpDomain);

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage(FromEmail, toEmail);
            msg.Subject = "[eDoc] Document Expiration Notify";
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

        private void CreateFile(string s)
        {
            string path = @"c:\test.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (FileStream fs = File.Create(path, 1024))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(s);
                fs.Write(info, 0, info.Length);
            }
        }

    }
}
