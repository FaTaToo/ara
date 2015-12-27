﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="Dictionary.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
//      Implement the Dictionary.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;

namespace ARAManager.Common
{
    /// <summary>
    ///     Define const used for many cases in ARA
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

        public const string TARGET_NAME_CONSTRAINT_EXCEPTION_MSG =
            "The target name has already existed.";

        public const string TARGET_CONCURRENT_UPDATE_EXCEPTION_MSG =
            "The target has been edited by another.";

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
        public const string EXCEED_NUMBER_OF_MISSION = "Exceed the number of mission";
        //------------------------------------------------------------------------------------

        // Headers
        public const string COMPANY_ADMIN_NEW_HEADER = "New " + "COMPANY" + " information";
        public const string COMPANY_ADMIN_EDIT_HEADER = "Edit " + "COMPANY" + " information";
        public const string CUSTOMER_ADMIN_NEW_HEADER = "New " + "CUSTOMER" + " information";
        public const string CUSTOMER_ADMIN_EDIT_HEADER = "Edit " + "CUSTOMER" + " information";
        //------------------------------------------------------------------------------------

        // Path
        public const string PATH_UPLOADED_TARGET = @"~/Ar_Data/Json/";
        public const string PATH_LIST_TARGET = @"~/Ara_Data/Targets/ListTargets.txt";
        public const string PATH_UPLOADED_CAMPAIGNS_AVATAR = @"~/Ara_Data/Campaigns/Avatar/";
        public const string PATH_UPLOADED_CAMPAIGNS_BANNER = @"~/Ara_Data/Campaigns/Banner/";
        public const string PATH_UPLOADED_MISSIONS_AVATAR = @"~/Ara_Data/Missions/Avatar/";
        //------------------------------------------------------------------------------------

        // Web services
        public const string PATH_AR_JSON = "~/Ar_Data/";
        //------------------------------------------------------------------------------------

        // ArResources
        public const string ARSM_PICTURES_GALLERY = "ARSM-PicturesGallery";
        public const string ARSM_YOUTUBE = "ARSM-Youtube";
        public const string ARSM_FACEBOOK = "ARSM-Facebook";
        public const string ARSM_TEXT = "ARMM-Text";
        public const string AR_KEY_URL = "URL";
        public const string AR_KEY_NAME = "Name";
        public const string AR_KEY_DIRECTOR = "Director";
        public const string AR_KEY_ACTOR = "Actor";
        public const string AR_KEY_DESCRIPTION = "Description";
        public const string AR_PLATFORM_ID_ANDROID = "Android";
        public const string AR_PROCESSOR_TYPE_IMAGE_SWITCHER = "ImageSwitcher";
        public const string AR_PROCESSOR_TYPE_FACEBOOK = "Facebook";
        public const string AR_PROCESSOR_TYPE_YOUTUBE = "Youtube";
        public const string AR_PROCESSOR_TYPE_TEXTVIEW = "TextView";
        //------------------------------------------------------------------------------------

        // Campaign types
        public const string CAMPAIGN_TYPE_CHECK_IN_URL = "checkin";
        public const string CAMPAIGN_TYPE_TOUR_URL = "tour";
        public const string CAMPAIGN_TYPE_THEATER_URL = "theater";
        //------------------------------------------------------------------------------------

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string MSG_SUCCESS = "Successfully";
        public const string MSG_FAILED = "Failed";
        public const string DUMMY_DATA = "Dummy data";
        public const int MAX_LENGTH_ROW_VERSION_ARRAY = 64;
        public const string NA = "NA";
        public const string CAMPAIGN_AVATAR = "CampaignAvatar";
        public const string CAMPAIGN_BANNER = "CampaignBanner";
        public const string MISSION_AVATAR = "MissionAvatar";
        public const string TARGET = "Target";
        #endregion IConstants
    }
}