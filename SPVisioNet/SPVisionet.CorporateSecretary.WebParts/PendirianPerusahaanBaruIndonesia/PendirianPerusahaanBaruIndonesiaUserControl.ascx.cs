using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Web;
using System.Data;

using SPVisionet.CorporateSecretary.Common;
using Microsoft.SharePoint;

namespace SPVisionet.CorporateSecretary.WebParts.PendirianPerusahaanBaruIndonesia
{
    public partial class PendirianPerusahaanBaruIndonesiaUserControl : UserControl
    {
        #region Properties

        [Serializable]
        private class WewenangDireksi
        {
            public int ID { get; set; }
            public string Nama { get; set; }
        }

        public class DATA
        {
            public int A { get; set; }
            public string B { get; set; }
        }

        private SPWeb web;
        private int ID = 0;
        private Guid ListId = Guid.Empty;

        #endregion

        #region Methods

        private void BindTempatKedudukan()
        {
            DataTable dt = Util.GetTempatKedudukan(web);
            ddlTempatKedudukan.DataTextField = "Title";
            ddlTempatKedudukan.DataValueField = "ID";
            ddlTempatKedudukan.DataSource = dt;
            ddlTempatKedudukan.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlTempatKedudukan.Items.Insert(0, item);
        }

        private void BindMaksudTujuan()
        {
            DataTable dt = Util.GetMaksudTujuan(web);
            ddlMaksudTujuan.DataTextField = "Title";
            ddlMaksudTujuan.DataValueField = "ID";
            ddlMaksudTujuan.DataSource = dt;
            ddlMaksudTujuan.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlMaksudTujuan.Items.Insert(0, item);
        }

        private void BindStatusOwnership()
        {
            DataTable dt = Util.GetStatusOwnership(web);
            ddlStatusOwnership.DataTextField = "Title";
            ddlStatusOwnership.DataValueField = "ID";
            ddlStatusOwnership.DataSource = dt;
            ddlStatusOwnership.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlStatusOwnership.Items.Insert(0, item);
        }

        private void BindMataUang()
        {
            DataTable dt = Util.GetMataUang(web);
            ddlMataUang.DataTextField = "Title";
            ddlMataUang.DataValueField = "ID";
            ddlMataUang.DataSource = dt;
            ddlMataUang.DataBind();

            ListItem item = new ListItem("--Select--", string.Empty);
            ddlMataUang.Items.Insert(0, item);
        }

        private void BindWewenangDireksi()
        {
            List<WewenangDireksi> coll = new List<WewenangDireksi>();
            if (ViewState["WewenangDireksi"] != null)
                coll = ViewState["WewenangDireksi"] as List<WewenangDireksi>;

            dgWewenangDireksi.DataSource = coll;
            dgWewenangDireksi.DataBind();

            upWewenangDireksi.Update();
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

            dgDokumenLainnya.DataSource = coll;
            dgDokumenLainnya.DataBind();
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            Util.RegisterStartupScript(Page, "Indonesia", "RegisterDialog('divMainSearch','divMainDlgContainer', '550');");

            using (SPSite site = new SPSite(SPContext.Current.Site.Url, SPContext.Current.Site.SystemAccount.UserToken))
            {
                using (web = site.OpenWeb())
                {
                    bool isID = false;
                    if (ViewState["ID"] == null)
                    {
                        if (Request.QueryString["ID"] != null)
                            isID = int.TryParse(Request.QueryString["ID"], out ID);
                    }
                    else
                        ID = Convert.ToInt32(ViewState["ID"]);

                    string mode = Request.QueryString["mode"] == null ? string.Empty : Request.QueryString["mode"].ToString();

                    if (Request.QueryString["List"] != null)
                        ListId = new Guid(HttpUtility.UrlDecode(Request.QueryString["List"]));

                    if (!IsPostBack)
                    {
                        txtModalDasar.Attributes.Add("onkeyup", "FormatNumber('" + txtModalDasar.ClientID + "'); Total('" + txtModalDasar.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalDasar.ClientID + "');");
                        txtModalDasar.Attributes.Add("onblur", " FormatNumber('" + txtModalDasar.ClientID + "')");

                        txtModalSetor.Attributes.Add("onkeyup", "FormatNumber('" + txtModalSetor.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalSetor.ClientID + "');");
                        txtModalSetor.Attributes.Add("onblur", " FormatNumber('" + txtModalSetor.ClientID + "')");

                        txtNominalSaham.Attributes.Add("onkeyup", "FormatNumber('" + txtNominalSaham.ClientID + "'); Total('" + txtModalDasar.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalDasar.ClientID + "'); Total('" + txtModalSetor.ClientID + "','" + txtNominalSaham.ClientID + "','" + txtNominalModalSetor.ClientID + "');");
                        txtNominalSaham.Attributes.Add("onblur", " FormatNumber('" + txtNominalSaham.ClientID + "')");

                        ltrTanggal.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm");
                        Bind();

                        BindMaksudTujuan();
                        BindMataUang();
                        BindStatusOwnership();
                        BindTempatKedudukan();
                        BindWewenangDireksi();

                        //if (isID)
                        //    Display(mode);
                    }
                }
            }
        }

        #region Wewenang Direksi

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

        #endregion

        #endregion
    }
}
