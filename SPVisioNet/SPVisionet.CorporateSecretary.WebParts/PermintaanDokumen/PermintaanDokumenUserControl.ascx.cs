using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace SPVisionet.CorporateSecretary.WebParts.PermintaanDokumen
{
    public partial class PermintaanDokumenUserControl : UserControl
    {
        public class DATA
        {
            public int A { get; set; }
            public string B { get; set; }
        }

        private void Bind()
        {
            List<DATA> coll = new List<DATA>();
            dgDokumen.DataSource = coll;
            dgDokumen.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltrDate.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm");
                Bind();
            }
        }
    }
}
