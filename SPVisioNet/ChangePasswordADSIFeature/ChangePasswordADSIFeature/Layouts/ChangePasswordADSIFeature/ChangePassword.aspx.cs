using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.DirectoryServices;
using ChangePasswordADSIFeature;

namespace ChangePasswordADSIFeature.Layouts.ChangePasswordADSIFeature
{
    public partial class ChangePassword : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserName.Text = SPContext.Current.Web.CurrentUser.Name;
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                UserChangePassword();
            }
        }

        private void UserChangePassword()
        {
            SPUser user = SPContext.Current.Web.CurrentUser;

            try
            {
                string domainName = user.LoginName.Split('\\')[0];
                string loginName = user.LoginName.Split('\\')[1];

                SPSecurity.RunWithElevatedPrivileges(delegate()
               {
                   ActiveDirectoryUtil activeDirectoryUtil = new ActiveDirectoryUtil(loginName, txtOldPassword.Text, domainName);

                   if (activeDirectoryUtil.GetUserDirectoryEntry() != null)
                   {
                       bool sts = activeDirectoryUtil.SetPassword(txtNewPassword.Text);
                       if (sts)
                           lblMessage.Text = "Password Successfully Changed";
                       else
                           lblMessage.Text = "Password Unsuccessfully Changed";
                   }
                   else
                   {
                       lblMessage.Text = lblUserName.Text + " doesn't exist";
                   }
                   activeDirectoryUtil = null;
               });

                txtOldPassword.Enabled = false;
                txtNewPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                btnChangePassword.Visible = false;
                btnReset.Visible = false;   
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message + "," + ex.StackTrace;
            }
        }

    }
}
