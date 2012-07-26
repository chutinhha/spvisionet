using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.SharePoint;
using SPVisionet.CorporateSecretary.Common;

public partial class _Default : System.Web.UI.Page
{
    [Serializable]
    private class WewenangDireksi
    {
        public int ID { get; set; }
        public string Nama { get; set; }
    }

    private void BindWewenangDireksi()
    {
        List<WewenangDireksi> coll = new List<WewenangDireksi>();
        if (ViewState["WewenangDireksi"] != null)
            coll = ViewState["WewenangDireksi"] as List<WewenangDireksi>;

        dgWewenangDireksi.DataSource = coll;
        dgWewenangDireksi.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string a = Server.UrlDecode("http://robin.com?a=PendirianPerusahaanBaruIndonesia%5Fx003a%5FNamaPerusahaan");

        if (!IsPostBack)
            BindWewenangDireksi();
    }

    protected void dgWewenangDireksi_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        List<WewenangDireksi> coll = new List<WewenangDireksi>();
        if (ViewState["WewenangDireksi"] != null)
            coll = ViewState["WewenangDireksi"] as List<WewenangDireksi>;

        if (e.CommandName == "add")
        {
            TextBox txtNamaAdd = e.Item.FindControl("txtNamaAdd") as TextBox;

            WewenangDireksi o = new WewenangDireksi();
            o.Nama = txtNamaAdd.Text.Trim();
            o.ID = 0;
            coll.Add(o);

            ViewState["WewenangDireksi"] = coll;
        }
        if (e.CommandName == "save")
        {
            TextBox txtNamaEdit = e.Item.FindControl("txtNamaEdit") as TextBox;

            WewenangDireksi o = new WewenangDireksi();
            o.Nama = txtNamaEdit.Text.Trim();
            o.ID = 0;

            coll[e.Item.ItemIndex] = o;
            ViewState["WewenangDireksi"] = coll;

            dgWewenangDireksi.EditItemIndex = -1;
            dgWewenangDireksi.ShowFooter = true;
        }
        if (e.CommandName == "edit")
        {
            dgWewenangDireksi.ShowFooter = false;
            dgWewenangDireksi.EditItemIndex = e.Item.ItemIndex;
        }
        if (e.CommandName == "cancel")
        {
            dgWewenangDireksi.EditItemIndex = -1;
            dgWewenangDireksi.ShowFooter = true;
        }
        if (e.CommandName == "delete")
        {
            coll.RemoveAt(e.Item.ItemIndex);
            ViewState["WewenangDireksi"] = coll;
        }
        BindWewenangDireksi();
    }
}