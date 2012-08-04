using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace SPVisioNet.WebParts.wpRedirectURL
{
    [ToolboxItemAttribute(false)]
    public class wpRedirectURL : Microsoft.SharePoint.WebPartPages.WebPart
    {
        private string _RedirectUrl;
        [Personalizable(), WebBrowsable()]
        public string RedirectUrl
        {
            get
            {
                return _RedirectUrl;
            }
            set
            {
                _RedirectUrl = value;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(_RedirectUrl))
            {
                return;
            }
            else
            {
                string str = string.Empty;
                foreach (string s in Page.Request.QueryString.Keys)
                {
                    if (Page.Request.QueryString[s] != null)
                    {
                        str = (!_RedirectUrl.Contains("?") ? string.Format("?{0}={1}", s, Page.Request.QueryString[s]) : string.Format("&{0}={1}", s, Page.Request.QueryString[s]));
                        _RedirectUrl += str;
                        _RedirectUrl = _RedirectUrl.Replace("ID=", "IdItem=");
                    }
                }
                Page.Response.Redirect(_RedirectUrl, true);
            }

        }

        public override ToolPart[] GetToolParts()
        {
            ToolPart[] toolparts = new ToolPart[3];
            WebPartToolPart wp1 = new WebPartToolPart();
            CustomPropertyToolPart wp2 = new CustomPropertyToolPart();
            ToolPartCustom wp3 = new ToolPartCustom();

            wp1.Expand(WebPartToolPart.Categories.Appearance);
            toolparts[0] = wp1;
            toolparts[1] = wp2;
            toolparts[2] = wp3;

            return toolparts;
        }

    }
}
