namespace ARAManager.Common
{
    public class Messages
    {
        #region Constants

        #region ExceptionMessages

        #region Generic
        public const string USERNAME_CONSTRAINT_EXCEPTION_MSG =
        "The username has already existed.";
        public const string EMAIL_CONSTRAINT_EXCEPTION_MSG =
        "The email address has already been registered.";
        public const string PHONE_CONSTRAINT_EXCEPTION_MSG =
       "The phone has already been registered.";
        #endregion Generic

        #region Campaign
        public const string CAMPAIGN_CONCURRENT_UPDATE_EXCEPTION_MSG =
        "The campaign has been edited by another.";
        public const string CAMPAIGN_DELETED_EXCEPTION_MSG =
        "The campaign has been already deleted.";
        public const string CAMPAIGN_NAME_CONSTRAINT_EXCEPTION_MSG =
        "The campaign name has already existed.";
        #endregion Campaign

        #region Company
        public const string COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG =
       "The company has been edited by another.";
        public const string COMPANY_DELETED_EXCEPTION_MSG =
        "The company has been already deleted.";
        public const string COMPANY_NAME_CONSTRAINT_EXCEPTION_MSG =
        "The company name has already existed.";
        #endregion Company

        #region Customer
        public const string CUSTOMER_CONCURRENT_UPDATE_EXCEPTION_MSG =
       "The customer has been edited by another.";
        public const string CUSTOMER_DELETED_EXCEPTION_MSG =
        "The customer has been already deleted.";
        #endregion Customer

        #region Mission
        public const string MISSION_CONCURRENT_UPDATE_EXCEPTION_MSG =
        "The mission has been edited by another.";
        public const string MISSION_DELETED_EXCEPTION_MSG =
        "The mission has been already deleted.";
        public const string MISSION_NAME_CONSTRAINT_EXCEPTION_MSG =
        "The mission name has already existed.";
        public const string PRE_MISSION_CONSTRAINT_EXCEPTION_MSG =
        "The pre mission has already existed.";
        #endregion Mission

        #region Subscription
        public const string SUBSCRIPTION_CONCURRENT_UPDATE_EXCEPTION_MSG =
        "The subscription has been edited by another.";
        public const string SUBSCRIPTION_DELETED_EXCEPTION_MSG =
        "The subscription has been already deleted.";
        public const string SUBSCRIPTION_CONSTRAINT_EXCEPTION_MSG =
        "The subscription has already joined the campaign.";
        #endregion Subscription

        #endregion ExceptionMessages

        #region ExceptionReasons

        public const string UNIQUE_CONSTRAINT_EXCEPTION_REASON =
        "Violate unique constraint";
        public const string CONCURRENT_UPDATE_EXCEPTION_REASON =
        "Concurrent update exception";
        public const string DELETED_EXCEPTION_REASON =
        "Deleted data";
        public const string UNKNOWN_REASON =
        "Unknown exception reason";

        #endregion ExceptionReasons

        #region GuiMessages

        public const string INVALID_LOGIN = "Invalid credentials. Please try again.";

        #endregion GuiMessages

        #endregion Constants
    }
}
