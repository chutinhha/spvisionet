using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using Microsoft.SharePoint.Workflow;

namespace InfinysWorkflowPrj.WFBasicApproval.Layouts.WFBasicApproval
{
    public partial class ApproveRejectEdit : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadItem();
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Action("Approved");
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            Action("Rejected");
        }

        private void LoadItem()
        {
            lblMessage.Text = string.Empty;
            try
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPListItem item = (SPListItem)SPContext.Current.Item;
                ltlTitle.Text = Convert.ToString(item["Title"]);

                string[] relatedItemLink = Convert.ToString(item["WorkflowLink"]).Split(',');
                linkRelatedItem.NavigateUrl = relatedItemLink[0].Trim();
                linkRelatedItem.Text = relatedItemLink[1].Trim();

                if (item["RemarksTxt"] !=null)
                {
                    tbxRemarksTxt.Text =  item["RemarksTxt"].ToString();
                    lblRemarks.Text = tbxRemarksTxt.Text;
                    tbxRemarksTxt.Visible = false; 
                }

                if (item["ApproveOrReject"] != null && (item["ApproveOrReject"].ToString().Equals("Approved") || item["ApproveOrReject"].ToString().Equals("Rejected")))
                {
                    btnApprove.Visible = false;
                    btnReject.Visible = false;  
                }
                                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "," + ex.Source;
            }
        }

        private void Action(string Action)
        {
            lblMessage.Text = string.Empty;
            try
            {
                SPWeb web = SPControl.GetContextWeb(this.Context);
                SPListItem item = (SPListItem)SPContext.Current.Item;
                item["ApproveOrReject"] = Action;
                item["RemarksTxt"] = tbxRemarksTxt.Text;
                item.Web.AllowUnsafeUpdates = true;
                item.Update();
                LoadItem();

                lblRemarks.Text = tbxRemarksTxt.Text;
                tbxRemarksTxt.Visible = false; 
                lblMessage.ForeColor = System.Drawing.Color.Black;
                lblMessage.Text = "Task already update successfully";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "," + ex.Source;
            }
        }
    }
}
