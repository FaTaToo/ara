using System;
using System.Web.Security;

namespace ARAManager.Presentation.Client.Master_Pages {
    public partial class Management : System.Web.UI.MasterPage {
        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {
            lblUser.Text = Page.User.Identity.Name;
        }

        protected void lbLogout_OnClick(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }
        #endregion IMethods
    }
}