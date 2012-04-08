using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace SPVisioNet.WebParts.wpNotification
{
    public enum Scope
    {
        Recursive,
        SiteCollection
    }


    [ToolboxItemAttribute(false)]
    public class wpNotification : Microsoft.SharePoint.WebPartPages.WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/Baznas/wpNotification/wpNotificationUserControl.ascx";
        private string _errMessage = "";
        protected SPVisioNet.WebParts.wpNotification.wpNotificationUserControl ucControl;


        private string selectQuery = "<Where><Gt><FieldRef Name='Period_x0020_End_x0020_Date' /><Value Type='DateTime'><Today OffsetDays='-30' /></Value></Gt></Where>";
        [
          Personalizable(),
          Category("Miscellaneous"),
          DefaultValue(""),
          WebBrowsable(true),
          WebDisplayName("SelectQuery"),
          WebDescription("SelectQuery")
        ]
        public string SelectQuery
        {
            get { return selectQuery; }
            set { selectQuery = value; }
        }

        private Scope searchScope;
        [
          Personalizable(),
          Category("Miscellaneous"),
          DefaultValue(Scope.Recursive),
          WebBrowsable(true),
          WebDisplayName("SearchScope"),
          WebDescription("SearchScope")
        ]
        public Scope SearchScope
        {
            get { return searchScope; }
            set { searchScope = value; }
        }

        private string viewFields = "<FieldRef Name='Title' Nullable='TRUE' /><FieldRef Name='FileRef' Nullable='TRUE' /><FieldRef Name='Modified' Nullable='TRUE' /><FieldRef Name='Period_x0020_End_x0020_Date' />";
        [
          Personalizable(),
          Category("Miscellaneous"),
          DefaultValue(""),
          WebBrowsable(true),
          WebDisplayName("ViewFields"),
          WebDescription("ViewFields")
        ]
        public string ViewFields
        {
            get { return viewFields; }
            set { viewFields = value; }
        }

        private int pageSize = 15;
        [
          Personalizable(),
          Category("Miscellaneous"),
          DefaultValue(15),
          WebBrowsable(true),
          WebDisplayName("PageSize"),
          WebDescription("PageSize")
        ]
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            try
            {
                if (_errMessage != string.Empty)
                    output.Write(_errMessage);
                RenderChildren(output);
            }
            catch (Exception ex)
            {
                output.Write(ex.Message + "<br>" + ex.StackTrace);
            }
        }

        protected override void RenderChildren(HtmlTextWriter output)
        {
            try
            {
                if (HasControls())
                {
                    Controls[0].RenderControl(output);
                }
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message + "<br>" + ex.StackTrace;
            }
        }

        protected override void CreateChildControls()
        {
            try
            {
                ucControl = (SPVisioNet.WebParts.wpNotification.wpNotificationUserControl)Page.LoadControl(_ascxPath);
                ucControl.SelectQuery = selectQuery;
                ucControl.ViewFields = viewFields;
                ucControl.PageSize = pageSize;
                Controls.AddAt(0, ucControl);
            }
            catch (Exception ex)
            {
                _errMessage = ex.Message + "<br>" + ex.StackTrace;
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
