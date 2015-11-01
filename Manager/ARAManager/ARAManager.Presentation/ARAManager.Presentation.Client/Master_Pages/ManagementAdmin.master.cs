using System;
namespace ARAManager.Presentation.Client.Master_Pages {
    // ReSharper disable once InconsistentNaming - Added by PhucLS
    public partial class ManagementAdmin : System.Web.UI.MasterPage {
        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnCompany_OnClick(object sender, EventArgs e) {
            Response.Redirect(@"~\Aspx\CompanyAdmin.aspx");
        }

        protected void btnCustomer_OnClick(object sender, EventArgs e) {
            Response.Redirect(@"~\Aspx\CustomerAdmin.aspx");
        }
        #endregion IMethods
    }
}