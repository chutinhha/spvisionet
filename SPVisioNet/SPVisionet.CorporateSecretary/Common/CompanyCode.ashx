<%@ WebHandler Language="C#" Class="CompanyCode" %>

using System;
using System.Web;
using System.Data;
using System.Web.Services;
using Microsoft.SharePoint;
using SPVisionet.CorporateSecretary.Common;

public class CompanyCode : IHttpHandler
{
    private void Bind(HttpContext context, string search)
    {
        context.Response.ContentType = "application/javascript";

        SPQuery query = new SPQuery();
        query.Query = "<Where>" +
                          "<BeginsWith>" +
                             "<FieldRef Name='CompanyCodeAPV' />" +
                             "<Value Type='Text'>" + search + "</Value>" +
                          "</BeginsWith>" +
                       "</Where>";
        query.ViewFields = "<FieldRef Name='CompanyCodeAPV'/>";
        
        using (SPSite site = new SPSite(SPContext.Current.Web.Url, SPContext.Current.Site.SystemAccount.UserToken))
        {
            using (SPWeb web = site.OpenWeb())
            {
                SPList list = web.GetList(Util.CreateSharePointListStrUrl(web.Url, "PendirianPerusahaanBaruIndonesia"));
                SPListItemCollection coll = list.GetItems(query);
                DataTable dt = coll.GetDataTable();
                DataView dv = new DataView(dt);
                dv.Sort = "CompanyCodeAPV Asc";
                dt = dv.ToTable(true, "CompanyCodeAPV");

                string[] items = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    items[i] = dt.Rows[i]["CompanyCodeAPV"].ToString();
                }

                context.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(items));
            }
        }
    }

    public void ProcessRequest(HttpContext context)
    {
        string search = string.Empty;
        try
        {
            search = context.Request.QueryString["Search"].ToString();
            if (search.Trim() != string.Empty)
                Bind(context, search);
        }
        catch
        {
            return;
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}