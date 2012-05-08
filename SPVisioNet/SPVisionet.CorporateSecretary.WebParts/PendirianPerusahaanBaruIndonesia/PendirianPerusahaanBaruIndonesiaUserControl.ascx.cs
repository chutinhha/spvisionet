using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

using SPVisionet.CorporateSecretary.Common;

namespace SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruIndonesia
{
    public partial class PendirianPerusahaanBaruIndonesiaUserControl : UserControl
    {
        public class DATA
        {
            public int A { get; set; }
            public string B { get; set; }
        }

        private void Bind()
        {
            List<DATA> coll = new List<DATA>();
            dgKomisaris.DataSource = coll;
            dgKomisaris.DataBind();

            dgKomisarisDP.DataSource = coll;
            dgKomisarisDP.DataBind();

            dgPemegangSaham.DataSource = coll;
            dgPemegangSaham.DataBind();

            dgPemegangSahamDP.DataSource = coll;
            dgPemegangSahamDP.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Util.RegisterStartupScript(Page, "Indonesia", "RegisterDialog('divMainSearch','divMainDlgContainer', '550');");

            if (!IsPostBack)
            {
                Bind();
            }
        }
    }
}
