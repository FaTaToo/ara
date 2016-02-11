// --------------------------------------------------------------------------------------------------------------------
/* <header file="Management.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for Management MASTER page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Security;
using System.Web.UI;
using ARAManager.Presentation.Client.Common;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.Master_Pages
{
    public partial class Management : MasterPage
    {
        #region IMethods

        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Text = Page.User.Identity.Name;
        }

        protected void lbLogout_OnClick(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(Routes.NAVIGATION_TO_LOGIN_PAGE);
        }

        #endregion IMethods
    }
}