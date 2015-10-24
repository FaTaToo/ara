using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ARAManager.Common.Dto;

namespace ARAManager.Presentation.Client.Aspx
{
    public partial class CategoryAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var tmp = new List<AccountType>()
            {
                new AccountType(){Name = "abc",AccountTypeId = 1,GroupType = 1}
            };
            GridViewResult.DataSource = tmp;
            GridViewResult.DataBind();
        }
    }
}