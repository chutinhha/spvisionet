using System;
using System.Collections.Generic;
using System.Text;

namespace SPVisioNet.NotificationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                if (args.Length % 2 != 0)
                {
                    Console.WriteLine("Incomplete paramater");
                    return;
                }
                
                NotifyUsers(args);
            } else
            {
                ShowHelp();
            }
            //Console.ReadLine();
        }
        
        private static void NotifyUsers(string[] args)
        {
            Notification notification = new Notification();
            
            for(int argNum=0;argNum < args.Length ; argNum++)
            {
               switch(args[argNum].ToLower())
               {
                   case "-from":
                       notification.FromEmail = args[argNum + 1];
                       argNum++;
                       break;
                   case "-to":
                       notification.ToEmail = args[argNum + 1];
                       argNum++;
                       break;
                   case "-l":
                       notification.ListUrl = args[argNum + 1];
                       argNum++;
                       break;
                   case "-q":
                       notification.CamlQuery = args[argNum + 1];
                       argNum++;
                       break;
                   case "-smtp":
                       notification.SmtpServer = args[argNum + 1];
                       argNum++;
                       break;
                   case "-port":
                       try
                       {
                           notification.SmtpPort = int.Parse(args[argNum + 1]);
                       }
                       catch
                       {
                       }
                       argNum++;
                       break;
                   case "-smtpuser":
                       notification.SmtpUser = args[argNum + 1];
                       argNum++;
                       break;
                   case "-smtppass":
                       notification.SmtpPass = args[argNum + 1];
                       argNum++;
                       break;
                   case "-smtpdomain":
                       notification.SmtpPass = args[argNum + 1];
                       argNum++;
                       break;
               }
            }

            notification.Process();
        }


        private static void ShowHelp()
        {
            Console.WriteLine("Usage :");
            Console.WriteLine("   -from system@admin.com");
            Console.WriteLine("   -to john.doe@somewhere.com");
            Console.WriteLine("   -l libraryUrl");
            Console.WriteLine("   -q query");
            Console.WriteLine("   -smtp smtpserver");
            Console.WriteLine("   -port smtpport");
            Console.WriteLine("   -smtpuser smtpuser");
            Console.WriteLine("   -smtppass smtppassword");
            Console.WriteLine("Query options:");
            Console.WriteLine("    [TODAY]");
        }
    }
}
