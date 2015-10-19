using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client {
    public partial class Default : Page {
        protected void Page_Load(object sender, EventArgs e) {
            try {
                var testService = ClientServiceFactory.EmployeeService.GetAllAccounts();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}