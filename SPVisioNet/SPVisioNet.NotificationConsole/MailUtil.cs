using System;
using System.Text;
using System.IO;
using System.Net.Mail;
using Microsoft.Win32;
using System.Diagnostics;
using System.Configuration;
using System.Net;

namespace SPVisioNet.NotificationConsole
{
    public sealed class MailUtil 
    {
        private string _host;
        private int _port;
        private string _username;
        private string _password;
        private string _domain;
               
        #region Properties


        public static string ConfigValue(string s)
        {
            string result;
            try
            {
                result = ConfigurationManager.AppSettings[s].ToString();
                return result;
            }
            catch
            {
                return string.Empty;
            }
        }

        public string Host
        {
            get
            {
                if (_host == null || _host.Length == 0)
                {
                    _host = ConfigValue("SmtpHost");
                }
                return _host;
            }

            set { _host = value; }
        }

        public int Port
        {
            get
            {
                try
                {
                    _port = int.Parse(ConfigValue("SmtpPort"));  
                }
                catch
                {
                    _port = 25;
                }
                return _port;
            }

            set { _port = value; }
        }

        public string Username
        {
            get
            {
                try
                {
                    string s = ConfigValue("SmtpUser");
                    if (s.Length > 0)
                        _username = s;
                    else
                        _username = string.Empty; 
                }
                catch
                {
                    _username = string.Empty;  
                }
                return _username;
            }
           
            set { _username = value; }
        }

        public string Password
        {
            get
            {
                try
                {
                    string s = ConfigValue("SmtpPassword");
                    if (s.Length > 0)
                        _password = s;
                    else
                        _password = string.Empty; 
                }
                catch
                {
                    _password = string.Empty;
                }
                return _password;
            }

            set { _password = value; }
        }

        public string Domain
        {
            get
            {
                try
                {
                    string s = ConfigValue("SmtpDomain");
                    if (s.Length > 0)
                        _domain = s;
                    else
                        _domain = string.Empty;
                }
                catch
                {
                    _domain = string.Empty;
                }
                return _domain;
            }

            set { _domain = value; }
        }

        private SmtpClient SmtpClient
        {
            get
            {
                SmtpClient client = new SmtpClient(Host,Port);
                
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) &&  string.IsNullOrEmpty(Domain))
                    client.Credentials = new NetworkCredential(Username, Password);
                else if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Domain))
                    client.Credentials = new NetworkCredential(Username, Password); 
                return client;
            }
        }
        
        #endregion

        #region Constructor
        
        public MailUtil()
		{}
                
        #endregion

        #region Method
        
        public bool  SendMail(string From,string To,string Subject, string Body)
        {
            MailMessage msg = null;
            SmtpClient client = null;
            Trace.WriteLine("SendMail", "SendMail");

            try
            {
                MailAddress from = new MailAddress(From);
                MailAddress to = new MailAddress(To);
                msg = new MailMessage(from, to);
                msg.Subject = Subject;
                msg.Body = Body;
                msg.IsBodyHtml = true;
                client = SmtpClient;
                client.Send(msg);
                                     
                Trace.WriteLine("SendToMail", "SendMail");
                return true; 
            }
            catch (Exception ex)
            {
                Trace.WriteLine("SendMail-false" + ex.Message, "SendMail");
                return false;
            }finally
            {
                msg = null;
                client = null; 
            }
        }

        public bool SendMail(string From, string To, string Subject, string Body, Attachment[] attach)
        {
            MailMessage msg = null;
            SmtpClient client = null;
            Trace.WriteLine("SendMail", "SendMail");

            try
            {
                MailAddress from = new MailAddress(From);
                MailAddress to = new MailAddress(To);
                msg = new MailMessage(from, to);
                msg.Subject = Subject;
                msg.Body = Body;
                msg.IsBodyHtml = true;
                client = SmtpClient;

                if (attach.Length > 0)
                {
                    for (int i = 0; i < attach.Length; i++)
                    {
                        msg.Attachments.Add((Attachment)attach[i]);   
                    }
                }

                client.Send(msg);

                Trace.WriteLine("SendToMail", "SendMail");
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("SendMail-false" + ex.Message, "SendMail");
                 return false;
            }
            finally
            {
                msg = null;
                client = null;
            }
        }


        public bool SendMail(string Subject, string Body)
        {
            MailMessage msg = null;
            SmtpClient client = null;
            Trace.WriteLine("SendMail", "SendMail");

            try
            {
                MailAddress from = new MailAddress(ConfigValue("FromEmail"));
                MailAddress to = new MailAddress(ConfigValue("ToEmail"));
                msg = new MailMessage(from, to);
                msg.Subject = Subject;
                msg.Body = Body;
                msg.IsBodyHtml = true;
                client = SmtpClient;
                client.Send(msg);

                Trace.WriteLine("SendToMail", "SendMail");
                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("SendMail-false" + ex.Message, "SendMail");
                return false;
            }
            finally
            {
                msg = null;
                client = null;
            }
        }

        #endregion
    }
}
