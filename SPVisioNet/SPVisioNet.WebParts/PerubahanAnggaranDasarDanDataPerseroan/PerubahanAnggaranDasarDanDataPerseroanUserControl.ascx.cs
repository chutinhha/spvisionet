using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

namespace SPVisioNet.WebParts.PerubahanAnggaranDasarDanDataPerseroan
{
    public partial class PerubahanAnggaranDasarDanDataPerseroanUserControl : UserControl
    {
        public class DATA
        {
            public int A { get; set; }
            public string B { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           Util.RegisterStartupScript(Page, "Foreign", "RegisterDialog('divMainSearch','divMainDlgContainer', '550');");

            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            List<DATA> coll = new List<DATA>();
            dgNPWP.DataSource = coll;
            dgNPWP.DataBind();

            dgPemegangSahamMenjadi.DataSource = coll;
            dgPemegangSahamMenjadi.DataBind();

            dgPemegangSahamSemula.DataSource = coll;
            dgPemegangSahamSemula.DataBind();

            dgShareholderMenjadi.DataSource = coll;
            dgShareholderMenjadi.DataBind();

            dgShareholderSemula.DataSource = coll;
            dgShareholderSemula.DataBind();
        }
    }
}
