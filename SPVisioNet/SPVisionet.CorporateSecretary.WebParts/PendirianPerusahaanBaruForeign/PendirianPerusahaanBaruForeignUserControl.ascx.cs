using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

using SPVisionet.CorporateSecretary.Common;

namespace SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruForeign
{
    public partial class PendirianPerusahaanBaruForeignUserControl : UserControl
    {
        public class DATA
        {
            public int A { get; set; }
            public string B { get; set; }
        }

        private void Bind()
        {
            List<DATA> coll = new List<DATA>();
            dgCommissioners.DataSource = coll;
            dgCommissioners.DataBind();

            dgOfficer.DataSource = coll;
            dgOfficer.DataBind();

            dgShareholder.DataSource = coll;
            dgShareholder.DataBind();

            dgShareholderDP.DataSource = coll;
            dgShareholderDP.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Util.RegisterStartupScript(Page, "Foreign", "RegisterDialog('divMainSearch','divMainDlgContainer', '550');");

            if (!IsPostBack)
            {
                Bind();
            }
        }
    }
}
