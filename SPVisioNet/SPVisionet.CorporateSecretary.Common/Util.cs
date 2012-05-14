using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Data;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

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

        public DataTable GetItemDataTable(string ListURL, int pageSize, int pageIndex, string strSortFieldName, string strDataType, bool blAscendingTrueFalse, string strViewFields, string strQuery)
        {
            if (ListURL == string.Empty)
                return new DataTable();

            DataTable dt = new DataTable();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(ListURL))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList objList = web.GetList(ListURL);
                        SPQuery spQry = null;
                        pageIndex = pageIndex / pageSize;
                        if (pageIndex < 1)
                        {
                            spQry = new SPQuery();
                            spQry.RowLimit = (uint)pageSize;
                            spQry.ViewFields = strViewFields;

                            spQry.Query = strQuery + "<OrderBy><FieldRef Name=\"" + strSortFieldName + "\" Ascending=\"" + blAscendingTrueFalse + "\" /></OrderBy>";
                        }
                        else
                        {
                            spQry = new SPQuery();
                            spQry.RowLimit = (uint)(pageIndex * pageSize);

                            spQry.ViewFields = "<FieldRef Name='Id'/><FieldRef Name='" + strSortFieldName + "'/>";

                            spQry.Query = strQuery + "<OrderBy><FieldRef Name=\"" + strSortFieldName + "\" Ascending=\"" + blAscendingTrueFalse + "\" /></OrderBy>";

                            SPListItemCollection objItemCollection = objList.GetItems(spQry);

                            spQry = new SPQuery();
                            spQry.RowLimit = (uint)pageSize;
                            spQry.ViewFields = strViewFields;

                            spQry.Query = strQuery + "<OrderBy><FieldRef Name=\"" + strSortFieldName + "\" Ascending=\"" + blAscendingTrueFalse + "\" /></OrderBy>"; ;

                            SPListItemCollectionPosition objSPListColPos = null;

                            if (strDataType.ToUpper() == "DATETIME")
                            {
                                string DateTime = objItemCollection[objItemCollection.Count - 1][strSortFieldName].ToString(); //.Split(new string[] { ";#" }, StringSplitOptions.RemoveEmptyEntries)[1];
                                objSPListColPos = new SPListItemCollectionPosition("Paged=TRUE"
                                + "&p_" + strSortFieldName + "=" + SPEncode.UrlEncode(System.DateTime.Parse(DateTime).ToUniversalTime().ToString("yyyyMMdd hh:mm:ss"))
                                + "&p_ID=" + objItemCollection[objItemCollection.Count - 1]["ID"].ToString());
                            }
                            else
                            {
                                objSPListColPos = new SPListItemCollectionPosition("Paged=TRUE"
                                + "&p_" + strSortFieldName + "=" + objItemCollection[objItemCollection.Count - 1][strSortFieldName].ToString()
                                + "&p_ID=" + objItemCollection[objItemCollection.Count - 1]["ID"].ToString());
                            }

                            spQry.ListItemCollectionPosition = objSPListColPos;
                        }
                        dt = objList.GetItems(spQry).GetDataTable();
                    }
                }
            });
            return dt;
        }

        public int ListItemCount(string ListURL, int pageSize, int pageIndex, string strSortFieldName, string strDataType, bool blAscendingTrueFalse, string strViewFields, string strQuery)
        {
            int Count = 0;
            if (ListURL == string.Empty)
                return Count;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(ListURL))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPQuery query = new SPQuery();
                        query.Query = strQuery;

                        SPListItemCollection itemColl = web.GetList(ListURL).GetItems(query);
                        Count = itemColl.Count;
                    }
                }
            });
            return Count;
        }

        public static DataTable GetKlasifikasiLapanganUsaha(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "KlasifikasiLapanganUsaha"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetStatusPerseroan(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "StatusPerseroan"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetTempatKedudukan(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "TempatKedudukan"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetMaksudTujuan(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "MaksudTujuan"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetStatusOwnership(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "StatusOwnership"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetMataUang(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "MataUang"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
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
