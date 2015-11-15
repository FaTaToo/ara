using System.Globalization;

namespace ARAManager.Common
{
    /// <summary>
    /// Define const used for many cases in ARA
    /// </summary>
    public class Dictionary
    {
        #region SFields
        
        public static readonly CultureInfo EnUs = new CultureInfo("en-US");

        #endregion SFields

        #region IConstants

        public const string DATE_FORMAT = "MM.dd.yy";
        public const string ADMIN_USERNAME = "admin";
        public const string ADMIN_PASSWORD = "admin";

        // Exception messages
        public const string USERNAME_CONSTRAINT_EXCEPTION_MSG =
        "The username has already existed.";
        public const string EMAIL_CONSTRAINT_EXCEPTION_MSG =
        "The email address has already been registered.";
        public const string PHONE_CONSTRAINT_EXCEPTION_MSG =
       "The phone has already been registered.";
        public const string CAMPAIGN_CONCURRENT_UPDATE_EXCEPTION_MSG =
        "The campaign has been edited by another.";
        public const string CAMPAIGN_DELETED_EXCEPTION_MSG =
        "The campaign has been already deleted.";
        public const string CAMPAIGN_NAME_CONSTRAINT_EXCEPTION_MSG =
        "The campaign name has already existed.";
        public const string COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG =
       "The company has been edited by another.";
        public const string COMPANY_DELETED_EXCEPTION_MSG =
        "The company has been already deleted.";
        public const string COMPANY_NAME_CONSTRAINT_EXCEPTION_MSG =
        "The company name has already existed.";
        public const string CUSTOMER_CONCURRENT_UPDATE_EXCEPTION_MSG =
       "The customer has been edited by another.";
        public const string CUSTOMER_DELETED_EXCEPTION_MSG =
        "The customer has been already deleted.";
        public const string MISSION_CONCURRENT_UPDATE_EXCEPTION_MSG =
        "The mission has been edited by another.";
        public const string MISSION_DELETED_EXCEPTION_MSG =
        "The mission has been already deleted.";
        public const string MISSION_NAME_CONSTRAINT_EXCEPTION_MSG =
        "The mission name has already existed.";
        public const string PRE_MISSION_CONSTRAINT_EXCEPTION_MSG =
        "The pre mission has already existed.";
        public const string SUBSCRIPTION_CONCURRENT_UPDATE_EXCEPTION_MSG =
        "The subscription has been edited by another.";
        public const string SUBSCRIPTION_DELETED_EXCEPTION_MSG =
        "The subscription has been already deleted.";
        public const string SUBSCRIPTION_CONSTRAINT_EXCEPTION_MSG =
        "The subscription has already joined the campaign.";
        public const string UNIQUE_CONSTRAINT_EXCEPTION_REASON =
        "Violate unique constraint";
        public const string CONCURRENT_UPDATE_EXCEPTION_REASON =
        "Concurrent update exception";
        public const string DELETED_EXCEPTION_REASON =
        "Deleted data";
        public const string UNKNOWN_REASON =
        "Unknown exception reason";
        //------------------------------------------------------------------------------------

        // Error messages
        public const string INVALID_LOGIN = "Invalid credentials. Please try again.";
        //------------------------------------------------------------------------------------
        
        // Headers
        public const string COMPANY_ADMIN_NEW_HEADER = "New " + "COMPANY" + " information";
        public const string COMPANY_ADMIN_EDIT_HEADER = "Edit " + "COMPANY" + " information";
        public const string CUSTOMER_ADMIN_NEW_HEADER = "New " + "CUSTOMER" + " information";
        public const string CUSTOMER_ADMIN_EDIT_HEADER = "Edit " + "CUSTOMER" + " information";
        //------------------------------------------------------------------------------------

        // Path
        public const string PATH_UPLOADED_TARGET = @"~/Ara_Data/Targets/";
        public const string PATH_UPLOADED_CAMPAIGNS_AVATAR = @"~/Ara_Data/Campaigns/Avatar/";
        public const string PATH_UPLOADED_CAMPAIGNS_BANNER = @"~/Ara_Data/Campaigns/Banner/";
        public const string PATH_UPLOADED_MISSIONS_AVATAR = @"~/Ara_Data/Missions/Avatar/";
        //------------------------------------------------------------------------------------

        #endregion IConstants
    }
}
