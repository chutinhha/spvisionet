using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebPartPages;

namespace SPVisioNet.WebParts
{
   public class ToolPartCustom : Microsoft.SharePoint.WebPartPages.ToolPart     
   {
       public ToolPartCustom()
       {
            this.AllowMinimize = true;
            this.Title = "About";
       }

       protected override void RenderToolPart(HtmlTextWriter output)
       {
           System.Text.StringBuilder sb = new System.Text.StringBuilder();
           sb.Append("<table border=\"0\" width=\"100%\" ID=\"Table1\" align=\"left\">");
           sb.AppendFormat("<tr><td width=\"15%\" nowrap>Author</td><td>{0}</td></tr>", "Agusto Xaverius");
           sb.AppendFormat("<tr><td width=\"15%\" nowrap>Version</td><td>{0}</td></tr>", this.GetVersionAssembly());
           sb.AppendFormat("<tr><td width=\"15%\" nowrap>Email</td><td><a href='mailto:{0}'>{1}</a></td></tr>", "agustox21@gmail.com", "agustox21@gmail.com");
                      
           sb.Append("</table>");
           output.Write(sb.ToString());
           sb = null;
       }
        
        private string GetVersionAssembly()
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            AssemblyName an = ass.GetName();
            return String.Format("{0}.{1}", an.Version.Major.ToString(), an.Version.Minor.ToString());
        }
    }
}
