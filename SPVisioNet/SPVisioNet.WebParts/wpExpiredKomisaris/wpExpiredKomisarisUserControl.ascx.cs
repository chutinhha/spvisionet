using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Linq;

namespace SPVisioNet.WebParts.wpExpiredKomisaris
{
    [Serializable]
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ListName { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string Komisaris { get; set; }
    }

    public partial class wpExpiredKomisarisUserControl : UserControl
    {
        private SPWeb web = SPContext.Current.Web;
        private List<Message> arMessage = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            GetData();
            if (arMessage != null)
            {
                GridView1.Visible = true;
                GridView1.DataSource = arMessage.ToArray();
                GridView1.DataBind();
                Label2.Text = string.Format("Total = {0}", arMessage.Count);
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        public static string CreateSharePointListStrUrl(string webUrl, string listNameWhenCreated)
        {
            return string.Format("{0}/Lists/{1}", webUrl, listNameWhenCreated);
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

            string lookupfieldName = string.Empty;
            string lookupfieldId = string.Empty;
            SPList lookupfieldList = null;


            SPQuery query = new SPQuery();
            query.Query = Caml;
            string toEmail = string.Empty;

            SPList list = web.GetList(CreateSharePointListStrUrl(web.Url, listName));

            foreach (SPField fieldList in list.Fields)
            {
                if (fieldList.FieldValueType != null)
                {
                    if (fieldList.InternalName.Equals(field))
                    {
                        fieldName = fieldList.Title;
                        fieldType = fieldList.FieldValueType.FullName;
                    }


                    if (fieldList.Title.Equals("Request Code"))
                    {
                        lookupfieldName = fieldList.InternalName;
                        SPFieldLookup lookup = fieldList as SPFieldLookup;
                        lookupfieldList = web.Lists[new Guid(lookup.LookupList)];
                    }
                }
            }

            SPListItemCollection items = list.GetItems(query);

            foreach (SPListItem item in items)
            {
                try
                {

                    Message msg = new Message();
                    msg.Id = item.ID;
                    msg.ListName = lookupfieldList.Title;
                    msg.Title = lookupfieldList.GetItemById(new SPFieldLookupValue(item[lookupfieldName].ToString()).LookupId)["Title"].ToString();
                    msg.Komisaris = item["Title"].ToString();
                    msg.FieldName = fieldName;

                    if (fieldType.Equals("System.DateTime"))
                        msg.FieldValue = (item[field] != null ? Convert.ToDateTime(item[field]).ToString("dd/MM/yyyy") : string.Empty);
                    else
                        msg.FieldValue = (item[field] != null ? item[field].ToString() : string.Empty);

                    msg.Url = items[0].Web.ParentWeb.Url + lookupfieldList.DefaultEditFormUrl + "?ID=" + new SPFieldLookupValue(item[lookupfieldName].ToString()).LookupId.ToString();
                    msg.UserEmail = toEmail;
                    arMessage.Add(msg);
                }
                catch { }

            }
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


        private void GetData()
        {
            string emailTemplate = string.Empty;
            string listUrl = string.Empty;
            string caml = string.Empty;
            string field = string.Empty;


            SPListItemCollection items = GetNotificationSetting(web, "NotifExpiredKomisaris");

            arMessage = new List<Message>();

            foreach (SPListItem item in items)
            {
                listUrl = item["ListUrl"].ToString();
                caml = item["CAML"].ToString();
                field = item["Field"].ToString();
                SetMessage(web, listUrl, caml, field);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = arMessage.ToArray();
            GridView1.DataBind();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            GetData();
            Message[] arMessageSort = null;
            string sortDirection = ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "asc";
            string sortExpression = ViewState["SortExpression"] != null ? ViewState["SortExpression"].ToString() : e.SortExpression;

            if (!sortExpression.Equals(e.SortExpression))
            {
                sortDirection = "asc";
            }


            switch (e.SortExpression)
            {
                case "Title":
                    if (sortDirection.Equals("asc"))
                    {
                        var x = from msg in arMessage
                                orderby msg.Title ascending
                                select msg;
                        arMessageSort = x.ToArray();
                    }
                    else
                    {
                        var x = from msg in arMessage
                                orderby msg.Title descending
                                select msg;
                        arMessageSort = x.ToArray();
                    }
                    break;
                case "ListName":
                    if (sortDirection.Equals("asc"))
                    {
                        var x = from msg in arMessage
                                orderby msg.ListName ascending
                                select msg;
                        arMessageSort = x.ToArray();
                    }
                    else
                    {
                        var x = from msg in arMessage
                                orderby msg.ListName descending
                                select msg;
                        arMessageSort = x.ToArray();
                    }
                    break;
                case "Status":
                    if (sortDirection.Equals("asc"))
                    {
                        var x = from msg in arMessage
                                orderby msg.Status ascending
                                select msg;
                        arMessageSort = x.ToArray();
                    }
                    else
                    {
                        var x = from msg in arMessage
                                orderby msg.Status descending
                                select msg;
                        arMessageSort = x.ToArray();
                    }
                    break;
            }

            sortDirection = sortDirection.Equals("asc") ? "desc" : "asc";

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = sortExpression;

            GridView1.DataSource = arMessageSort.ToArray();
            GridView1.DataBind();

        }
    }
}

