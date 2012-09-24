using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Data;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

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

        public DataTable GetItemDataTableDocument(string ListURL, int pageSize, int pageIndex, string strSortFieldName, string strDataType, bool blAscendingTrueFalse, string strViewFields, string strQuery, string Folder)
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
                            if (Folder != string.Empty)
                                spQry.Folder = objList.ParentWeb.GetFolder(Folder);
                            spQry.ViewAttributes = "Scope=\"Recursive\"";

                            spQry.Query = strQuery + "<OrderBy><FieldRef Name=\"" + strSortFieldName + "\" Ascending=\"" + blAscendingTrueFalse + "\" /></OrderBy>";
                        }
                        else
                        {
                            spQry = new SPQuery();
                            spQry.RowLimit = (uint)(pageIndex * pageSize);
                            if (Folder != string.Empty)
                                spQry.Folder = objList.ParentWeb.GetFolder(Folder);
                            spQry.ViewFields = "<FieldRef Name='Id'/><FieldRef Name='" + strSortFieldName + "'/>";
                            spQry.ViewAttributes = "Scope=\"Recursive\"";

                            spQry.Query = strQuery + "<OrderBy><FieldRef Name=\"" + strSortFieldName + "\" Ascending=\"" + blAscendingTrueFalse + "\" /></OrderBy>";

                            SPListItemCollection objItemCollection = objList.GetItems(spQry);

                            spQry = new SPQuery();
                            spQry.RowLimit = (uint)pageSize;
                            spQry.ViewFields = strViewFields;
                            if (Folder != string.Empty)
                                spQry.Folder = objList.ParentWeb.GetFolder(Folder);
                            spQry.ViewAttributes = "Scope=\"Recursive\"";

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

        public int ListItemCountDocument(string ListURL, int pageSize, int pageIndex, string strSortFieldName, string strDataType, bool blAscendingTrueFalse, string strViewFields, string strQuery, string Folder)
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
                        SPList list = web.GetList(ListURL);

                        SPQuery query = new SPQuery();
                        query.Query = strQuery;
                        if (Folder != string.Empty)
                            query.Folder = list.ParentWeb.GetFolder(Folder);
                        query.ViewAttributes = "Scope=\"Recursive\"";

                        SPListItemCollection itemColl = list.GetItems(query);
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

        public static DataTable GetTipeDokumen(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "TipeDokumen"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetKomisarisDireksiJabatan(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "KomisarisDireksiJabatan"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetRoles(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "Roles"));

            SPQuery query = new SPQuery();
            query.Query = "<OrderBy>" +
                             "<FieldRef Name='Title' />" +
                          "</OrderBy>";

            SPListItemCollection coll = list.GetItems(query);
            return coll.GetDataTable();
        }

        public static DataTable GetAlasanPembuatan(SPWeb web)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "AlasanPembuatan"));

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

        public static string GetDepartment(SPWeb web, int userID)
        {
            SPList userInformationList = web.Site.RootWeb.SiteUserInfoList;
            SPListItem userItem = userInformationList.Items.GetItemById(userID);
            if (userItem != null)
                return userItem["Department"] == null ? string.Empty : userItem["Department"].ToString();

            return string.Empty;
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

        public static string GetApproval(SPWeb web, string Role)
        {
            SPWeb elevatedWeb = null;
            string LoginName = string.Empty;
            StringCollection sc = new StringCollection();
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite elevatedSite = new SPSite(web.Url))
                    {
                        elevatedWeb = elevatedSite.OpenWeb();
                    }
                });

                SPQuery query = new SPQuery();
                query.Query = "<Where>" +
                                  "<Eq>" +
                                     "<FieldRef Name='Role' />" +
                                     "<Value Type='Choice'>" + Role + "</Value>" +
                                  "</Eq>" +
                              "</Where>";

                SPList list = elevatedWeb.GetList(Util.CreateSharePointListStrUrl(elevatedWeb.Url, "ListApproval"));
                SPListItemCollection coll = list.GetItems(query);
                if (coll.Count > 0)
                {
                    SPListItem item = coll[0];
                    SPFieldUser userField = item.Fields["User"] as SPFieldUser;
                    SPFieldUserValueCollection userValueColl = (SPFieldUserValueCollection)userField.GetFieldValue(item["User"].ToString());

                    foreach (var userValue in userValueColl)
                    {
                        if (LoginName == string.Empty)
                            LoginName = userValue.User.LoginName;
                        else
                            LoginName += ";" + userValue.User.LoginName;
                    }
                }
            }
            finally
            {
                elevatedWeb.Dispose();
            }
            return LoginName;
        }

        public static void UpdateUserPermission(SPWeb web, bool isBreakRole, SPListItem item, string LoginName, string RoleDefinition)
        {
            web.AllowUnsafeUpdates = true;

            if (isBreakRole)
            {
                item.ResetRoleInheritance();
                item.Update();

                if (!item.HasUniqueRoleAssignments)
                    item.BreakRoleInheritance(false);
            }

            SPRoleDefinition SPRoleDefinitionData = item.Web.RoleDefinitions[RoleDefinition];

            string[] split = LoginName.Split(';');
            foreach (string s in split)
            {
                SPRoleAssignment RoleAssignment = new SPRoleAssignment(s, string.Empty, string.Empty, string.Empty);
                RoleAssignment.RoleDefinitionBindings.Add(SPRoleDefinitionData);
                item.RoleAssignments.Add(RoleAssignment);
            }

            item.Update();
        }

        public static void UpdateGroupPermission(SPWeb web, bool isBreakRole, SPListItem item, string Group, string RoleDefinition)
        {
            web.AllowUnsafeUpdates = true;

            if (isBreakRole)
            {
                item.ResetRoleInheritance();
                item.Update();

                if (!item.HasUniqueRoleAssignments)
                    item.BreakRoleInheritance(false);
            }

            SPRoleDefinition SPRoleDefinitionData = item.Web.RoleDefinitions[RoleDefinition];

            string[] GroupSplit = Group.Split(';');
            foreach (string i in GroupSplit)
            {
                SPGroup MembersGroup = item.Web.SiteGroups[i];
                SPRoleAssignment MembersRoleAssignment = new SPRoleAssignment(MembersGroup);
                MembersRoleAssignment.RoleDefinitionBindings.Add(SPRoleDefinitionData);
                item.RoleAssignments.Add(MembersRoleAssignment);
            }

            item.Update();
        }

        public static bool IsUserExistInSharePointGroup(SPWeb web, string LoginName, string SharePointGroup)
        {
            if (LoginName.ToLower() == "sharepoint\\system")
                return true;

            foreach (SPUser user in web.Groups[SharePointGroup].Users)
            {
                if (user.LoginName.ToLower() == LoginName.ToLower())
                    return true;
            }

            return false;
        }

        public static string IsPemegangSahamOK(DataGrid dg, decimal JumlahSaham, decimal JumlahNominal, decimal ModalSetor, decimal NominalSaham)
        {
            decimal resultJumlahNominal = 0;
            foreach (DataGridItem item in dg.Items)
            {
                Label lblJumlahSaham = item.FindControl("lblJumlahSaham") as Label;
                Label lblJumlahNominal = item.FindControl("lblJumlahNominal") as Label;

                if (lblJumlahNominal != null && lblJumlahNominal != null)
                {
                    if ((Convert.ToDecimal(lblJumlahSaham.Text) * NominalSaham) != Convert.ToDecimal(lblJumlahNominal.Text))
                        return "Pemagang Saham Data must be recalculated";
                }

                if (lblJumlahNominal != null)
                    resultJumlahNominal += Convert.ToDecimal(lblJumlahNominal.Text);
            }
            resultJumlahNominal = resultJumlahNominal + JumlahNominal;
            if (resultJumlahNominal > ModalSetor)
                return "Pemegang Saham exceeded 100%";

            return string.Empty;
        }

        public static string GenerateApprovalInformation(StringCollection scInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<br/><br/><table border=1 width='100%' style='font-size:11px;font-family:Verdana'><tr align='center'><td>No</td><td>PIC</td><td>Date</td><td>Activity</td></tr>");
            foreach (string item in scInfo)
            {
                string[] split = item.Split(';');
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", split[0], split[1], Convert.ToDateTime(split[2]).ToString("dd-MMM-yyyy HH:mm"), split[3]);
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        public static bool isExistNamaPerusahaan(SPWeb web, string NamaPerusahaan)
        {
            SPQuery query = new SPQuery();
            query.Query = "<Where>" +
                              "<Eq>" +
                                 "<FieldRef Name='NamaPerusahaan' />" +
                                 "<Value Type='Text'>" + NamaPerusahaan + "</Value>" +
                              "</Eq>" +
                          "</Where>";

            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendirianPerusahaanBaruIndonesia"));
            SPListItemCollection coll = list.GetItems(query);
            if (coll.Count > 0)
                return true;
            return false;
        }

        public static SPListItem GetPemegangSahamKomisarisMasterData(SPWeb web, int ID)
        {
            SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PemegangSahamKomisarisMasterData"));
            SPListItem item = list.GetItemById(ID);
            if (item != null)
                return item;
            return null;
        }

        public static void AddPemegangSahamKomisarisMasterData(SPWeb web, SPListItem itemPerusahaanBaru)
        {
            using (SPSite site = new SPSite(web.Url, web.Site.SystemAccount.UserToken))
            {
                using (SPWeb webSA = site.OpenWeb())
                {
                    SPList list = webSA.GetList(Util.CreateSharePointListStrUrl(webSA.Url, "PemegangSahamKomisarisMasterData"));
                    webSA.AllowUnsafeUpdates = true;

                    SPListItem itemAdd = list.Items.Add();
                    itemAdd["Title"] = itemPerusahaanBaru["NamaPerusahaan"];
                    itemAdd["Tipe"] = "Perusahaan LK";
                    itemAdd["Alamat"] = itemPerusahaanBaru["AlamatSKDP"] == null ? string.Empty : itemPerusahaanBaru["AlamatSKDP"].ToString();
                    itemAdd["NoNPWP"] = itemPerusahaanBaru["NoNPWP"] == null ? string.Empty : itemPerusahaanBaru["NoNPWP"].ToString();
                    itemAdd["NoIdentitas"] = null;
                    itemAdd["TanggalBerakhirNoIdentitas"] = null;
                  
                    SPList document = webSA.GetList(Util.CreateSharePointDocLibStrUrl(webSA.Url, "PerusahaanBaruDokumen"));
                    SPQuery query = new SPQuery();
                    query.Query = "<Where>" +
                                     "<And>" +
                                         "<Eq>" +
                                              "<FieldRef Name='PerusahaanBaru' LookupId='True' />" +
                                              "<Value Type='Lookup'>" + itemPerusahaanBaru.ID + "</Value>" +
                                          "</Eq>" +
                                          "<Eq>" +
                                              "<FieldRef Name='DocumentType' />" +
                                              "<Value Type='Text'>NPWP</Value>" +
                                          "</Eq>" +
                                     "</And>" +
                                  "</Where>" +
                                  "<OrderBy>" +
                                    "<FieldRef Name='Created' Ascending='False' />" +
                                  "</OrderBy>";
                    query.Folder = webSA.Folders["PerusahaanBaruDokumen"].SubFolders[itemPerusahaanBaru.Title];

                    SPListItemCollection coll = document.GetItems(query);
                    if (coll.Count > 0)
                    {
                        SPListItem itemDocument = coll[0];
                        byte[] bytes = itemDocument.File.OpenBinary();

                        itemAdd.Attachments.Add(itemDocument["Name"].ToString(), bytes);
                    }
                    itemAdd.Update();

                    webSA.AllowUnsafeUpdates = false;
                }
            }
        }
    }
}
