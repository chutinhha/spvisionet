using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

using Microsoft.SharePoint;

namespace SPVisionet.CorporateSecretary.Common
{
    public class Util
    {
        public static string CreateSharePointListStrUrl(string webUrl, string listNameWhenCreated)
        {
            return string.Format("{0}/Lists/{1}", webUrl, listNameWhenCreated);
        }

        public static string CreateSharePointDocLibStrUrl(string webUrl, string docLibNameWhenCreated)
        {
            return string.Format("{0}/{1}", webUrl, docLibNameWhenCreated);
        }

        public static void RegisterStartupScript(Page Page, string Key, string script)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), Key, script, true);
        }

        public static void ShowMessage(Page Page, string Message)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Alert", "alert(\"" + Message + "\");", true);
        }

        public static string GenerateRequestCode(SPWeb web, string Code, int Month, int Year)
        {
            SPQuery query;
            string result = string.Empty;
            string WhereClause = "<Where>" +
                                    "<And>" +
                                        "<Eq>" +
                                            "<FieldRef Name='Title' />" +
                                            "<Value Type='Text'>{0}</Value>" +
                                        "</Eq>" +
                                        "<And>" +
                                            "<Eq>" +
                                                "<FieldRef Name='Month' />" +
                                                "<Value Type='Number'>{1}</Value>" +
                                            "</Eq>" +
                                            "<Eq>" +
                                                "<FieldRef Name='Year' />" +
                                                "<Value Type='Number'>{2}</Value>" +
                                            "</Eq>" +
                                        "</And>" +
                                    "</And>" +
                                "</Where>";


            query = new SPQuery();
            query.Query = string.Format(WhereClause, Code, Month.ToString(), Year.ToString());

            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "RequestCode"));
            web.AllowUnsafeUpdates = true;

            SPListItemCollection coll = list.GetItems(query);
            if (coll.Count == 0)
            {
                SPListItem itemAdd = list.Items.Add();
                itemAdd["Title"] = Code;
                itemAdd["Month"] = Month.ToString();
                itemAdd["Year"] = Year.ToString();
                itemAdd["Counter"] = 1;
                itemAdd.Update();

                result = string.Format("{0}{1}{2}{3}", Code, Year.ToString(), Month.ToString("0#"), Convert.ToInt32(1).ToString("00000#"));
            }
            else
            {
                int Counter = 0;

                SPListItem item = coll[0];
                Counter = Convert.ToInt32(item["Counter"].ToString()) + 1;
                item["Counter"] = Counter;
                item.Update();

                result = string.Format("{0}{1}{2}{3}", Code, Year.ToString(), Month.ToString("0#"), Convert.ToInt32(Counter).ToString("00000#"));
            }

            web.AllowUnsafeUpdates = false;

            return result;
        }
    }
}
