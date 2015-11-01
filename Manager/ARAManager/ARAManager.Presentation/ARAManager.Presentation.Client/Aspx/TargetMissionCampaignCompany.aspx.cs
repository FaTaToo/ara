using System;
using Subgurim.Controles;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class TargetMissionCampaignCompany : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            GMap1.Add(new GControl(GControl.preBuilt.GOverviewMapControl));
            GMap1.Add(new GControl(GControl.preBuilt.LargeMapControl));
            GMarker marker = new GMarker(new GLatLng(39.5, -3.2));
            GInfoWindow window = new GInfoWindow(marker, "<center><b>GoogleMaps.Subgurim.NET</b></center>", true);
            GMap1.Add(window);
        }
    }
}