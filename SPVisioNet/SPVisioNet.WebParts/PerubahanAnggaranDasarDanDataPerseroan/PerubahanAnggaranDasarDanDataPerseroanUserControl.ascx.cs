using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace SPVisioNet.WebParts.PerubahanAnggaranDasarDanDataPerseroan
{
    public partial class PerubahanAnggaranDasarDanDataPerseroanUserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           Util.RegisterStartupScript(Page, "Foreign", "RegisterDialog('divMainSearch','divMainDlgContainer', '550');");

            if (!IsPostBack)
            {
               
            }
        }
    }
}
