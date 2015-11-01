using System;
using System.Net;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class TargetMissionCampaignCompany : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            
        }
        //public static Coordinate GetCoordinates(string region) {
        //    using (var client = new WebClient()) {
        //        string uri = "http://maps.google.com/maps/geo?q='"
        //            + region 
        //            + "'&output=csv&key=ABQIAAAAzr2EBOXUKnm_jVnk0OJI7xSosDVG8KKPE1"
        //            + "-m51RBrvYughuyMxQ-i1QfUnH94QxWIa6N4U6MouMmBA";
        //        string[] geocodeInfo = client.DownloadString(uri).Split(',');
        //        return new Coordinate(Convert.ToDouble(geocodeInfo[2]),
        //                   Convert.ToDouble(geocodeInfo[3]));
        //    }
        //}
        //public struct Coordinate {
        //    private double m_latitude;
        //    private double m_longitude;
        //    public Coordinate(double latitude, double longitude) {
        //        m_latitude = latitude;
        //        m_longitude = longitude; 
        //    }
        //    public double Latitude {
        //        get {
        //            return m_latitude;
        //        } set {
        //            m_latitude = value;
        //        }
        //    }
        //    public double Longitude {
        //        get {
        //            return m_longitude;
        //        }
        //        set {
        //            m_longitude = value;
        //        }
        //    }
        //}
    }
}