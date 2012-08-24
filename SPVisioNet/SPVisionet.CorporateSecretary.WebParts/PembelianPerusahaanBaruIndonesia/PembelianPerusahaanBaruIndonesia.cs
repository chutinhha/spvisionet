using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SPVisionet.CorporateSecretary.WebParts.PembelianPerusahaanBaruIndonesia
{
    [ToolboxItemAttribute(false)]
    public class PembelianPerusahaanBaruIndonesia : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/SPVisionet.CorporateSecretary.WebParts/PembelianPerusahaanBaruIndonesia/PembelianPerusahaanBaruIndonesiaUserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
        }
    }
}
