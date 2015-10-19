using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ARAManager.Presentation.Client
{
    public partial class SiteMaster : MasterPage
    {
        private const string ANTI_XSRF_TOKEN_KEY = "__AntiXsrfToken";
        private const string ANTI_XSRF_USER_NAME_KEY = "__AntiXsrfUserName";
        private string m_antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[ANTI_XSRF_TOKEN_KEY];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                m_antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = m_antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                m_antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = m_antiXsrfTokenValue;

                var responseCookie = new HttpCookie(ANTI_XSRF_TOKEN_KEY)
                {
                    HttpOnly = true,
                    Value = m_antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[ANTI_XSRF_TOKEN_KEY] = Page.ViewStateUserKey;
                ViewState[ANTI_XSRF_USER_NAME_KEY] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[ANTI_XSRF_TOKEN_KEY] != m_antiXsrfTokenValue
                    || (string)ViewState[ANTI_XSRF_USER_NAME_KEY] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}