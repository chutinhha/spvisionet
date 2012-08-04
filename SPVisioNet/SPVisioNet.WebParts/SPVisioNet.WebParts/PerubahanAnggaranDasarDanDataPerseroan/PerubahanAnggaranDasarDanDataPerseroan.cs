using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SPVisioNet.WebParts.PerubahanAnggaranDasarDanDataPerseroan
{
    [ToolboxItemAttribute(false)]
    public class PerubahanAnggaranDasarDanDataPerseroan : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/SPVisioNet.WebParts/PerubahanAnggaranDasarDanDataPerseroan/PerubahanAnggaranDasarDanDataPerseroanUserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
        }
    }
}
