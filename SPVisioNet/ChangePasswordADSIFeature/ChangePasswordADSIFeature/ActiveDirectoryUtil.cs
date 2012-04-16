using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.DirectoryServices;
using System.Collections;

namespace ChangePasswordADSIFeature
{
    #region Enumeration

    public enum ADAccountOptions
    {
        UF_TEMP_DUPLICATE_ACCOUNT = 0x0100,
        UF_NORMAL_ACCOUNT = 0x0200,
        UF_INTERDOMAIN_TRUST_ACCOUNT = 0x0800,
        UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
        UF_SERVER_TRUST_ACCOUNT = 0x2000,
        UF_DONT_EXPIRE_PASSWD = 0x10000,
        UF_SCRIPT = 0x0001,
        UF_ACCOUNTDISABLE = 0x0002,
        UF_HOMEDIR_REQUIRED = 0x0008,
        UF_LOCKOUT = 0x0010,
        UF_PASSWD_NOTREQD = 0x0020,
        UF_PASSWD_CANT_CHANGE = 0x0040,
        UF_ACCOUNT_LOCKOUT = 0x0010,
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0x0080,
    }

    #endregion

    public class ActiveDirectoryUtil
    {
        private string _authenticationUserId;
        private string _authenticationPassword;
        private string _domain;
        private DirectoryEntry _userEntry;

        public ActiveDirectoryUtil(string AuthenticationUserId, string AuthenticationPassword, string Domain)
        {
            _authenticationUserId = AuthenticationUserId;
            _authenticationPassword = AuthenticationPassword;
            _domain = Domain;
        }

        public string LDAPPath
        {
            get
            {
                string defaultNamingContext = string.Empty;
                string ldapPath = string.Empty;

                using (DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE"))
                {
                    defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();
                    ldapPath = "LDAP://" + defaultNamingContext;
                }
                return ldapPath;
            }
        }

        public DirectoryEntry GetUserDirectoryEntry()
        {
            using (DirectoryEntry root = new DirectoryEntry(LDAPPath))
            {
                DirectorySearcher search = new DirectorySearcher(root);
                search.Filter = "(sAMAccountName=" + _authenticationUserId + ")";
                SearchResult result = search.FindOne();

                if (result != null)
                    return result.GetDirectoryEntry();
                else
                    return null;
            }
        }

        private void SetPassword(DirectoryEntry userEntry, string password)
        {
            string sLdap = userEntry.Path;
            DirectoryEntry usr = new DirectoryEntry(userEntry.Path);
            //usr.Path = userEntry.Path;
            object[] oPassword = new object[] { password };
            object ret = usr.Invoke("SetPassword", oPassword);
            usr.CommitChanges();
            usr.Close();

        }

        public bool SetPassword(string password)
        {
            DirectoryEntry userEntry = GetUserDirectoryEntry();
            if (userEntry != null)
            {
                try
                {
                    SetPassword(userEntry, password);
                    SetPassword(userEntry, password);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string[] ListUsers()
        {
            ArrayList al = new ArrayList();

            DirectorySearcher searcher = new DirectorySearcher(_userEntry);
            searcher.Filter = "(objectClass=user)";

            SearchResultCollection results = searcher.FindAll();
            foreach (SearchResult result in results)
            {
                DirectoryEntry entry = result.GetDirectoryEntry();
                al.Add(_domain + "\\" + entry.Properties["sAMAccountName"].Value);
            }
            return (string[])al.ToArray(typeof(string));
        }


    }
}
