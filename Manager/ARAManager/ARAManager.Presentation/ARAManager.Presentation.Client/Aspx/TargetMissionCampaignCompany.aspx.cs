// --------------------------------------------------------------------------------------------------------------------
// <header file="TargetMissionCampaignCompany.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for TargetMissionCampaignCompany page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.UI.WebControls;
using Subgurim.Controles;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class TargetMissionCampaignCompany : System.Web.UI.Page {
        #region IFields

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {
            
        }

        protected void CustomValidator_TargetName_OnServerValidate(object source, ServerValidateEventArgs args) {
            throw new NotImplementedException();
        }

        protected void CustomValidator_Description_OnServerValidate(object source, ServerValidateEventArgs args) {
            throw new NotImplementedException();
        }

        protected void CustomValidator_Video_OnServerValidate(object source, ServerValidateEventArgs args) {
            throw new NotImplementedException();
        }

        protected void CustomValidator_Facebook_OnServerValidate(object source, ServerValidateEventArgs args) {
            throw new NotImplementedException();
        }

        protected void CustomValidator_Youtube_OnServerValidate(object source, ServerValidateEventArgs args) {
            throw new NotImplementedException();
        }

        private void InitializeDataForGMap() {
            GMAP_Target.Add(new GControl(GControl.preBuilt.GOverviewMapControl));
            GMAP_Target.Add(new GControl(GControl.preBuilt.LargeMapControl));
            GMarker marker = new GMarker(new GLatLng(39.5, -3.2));
            GInfoWindow window = new GInfoWindow(marker, "<center><b>Target location</b></center>", true);
            GMAP_Target.Add(window);
        }

        #endregion IMethods
    }
}