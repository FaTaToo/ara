using System;

namespace ARAManager.Presentation.Client.Aspx
{
    public partial class EditCampaignCompany : System.Web.UI.Page
    {
        #region IFields

        private int m_companyId;

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                m_companyId = int.Parse(Request.QueryString["Id"]);
            }   
        }
        #endregion IMethods
    }
}