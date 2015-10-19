namespace ARAManager.Common
{
    public class Messages
    {
        #region Constants

        public const string USERNAME_CONSTRAINT_EXCEPTION_MSG = "The username has already existed.";
        public const string ACCOUNT_CONCURRENT_UPDATE_EXCEPTION_MSG = "The account has been edited by another.";
        public const string ACCOUNT_DELETED_EXCEPTION_MSG = "The account has been already deleted.";

        public const string UNIQUE_CONSTRAINT_EXCEPTION_REASON = "Violate unique constraint";
        public const string CONCURRENT_UPDATE_EXCEPTION_REASON = "Concurrent update exception";
        public const string DELETED_EXCEPTION_REASON = "Deleted data";
        public const string UNKNOWN_REASON = "Unknown exception reason";

        #endregion Constants
    }
}
