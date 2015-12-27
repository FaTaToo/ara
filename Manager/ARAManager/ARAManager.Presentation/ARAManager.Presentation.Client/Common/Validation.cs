// --------------------------------------------------------------------------------------------------------------------
/* <header file="NewCampaignCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement Validator helper for web form.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

namespace ARAManager.Presentation.Client.Common
{
    public class Validation
    {
        #region IFields

        public const string VALIDATOR_REQUIRED_CRITERION_SEARCH = "Please enter at lease one criterion to search.";

        public const string VALIDATOR_ADDRESS = "Please enter address with length from 1 to 500.";
        public const string VALIDATOR_AVATAR = "Please upload avatar.";
        public const string VALIDATOR_COMPANY_NAME = "Please enter company name with length from 1 to 100.";
        public const string VALIDATOR_CUSTOMER_NAME = "Please enter customer name with length from 1 to 100.";
        public const string VALIDATOR_CAMPAIGN_NAME = "Please enter campaign name with length from 1 to 100.";
        public const string VALIDATOR_DATE_FORMAT = "Not correct datetime format";
        public const string VALIDATOR_DESCRIPTION = "Please enter description with length from 1 to 100.";
        public const string VALIDATOR_EMAIL = "Please enter email address with length from 1 to 100.";
        public const string VALIDATOR_FACEBOOK = "Please enter Facebook url with length from 1 to 500.";
        public const string VALIDATOR_GIFT = "Please enter gift with length from 1 to 500.";
        public const string VALIDATOR_MISSION_NAME = "Please enter mission name with length from 1 to 100.";
        public const string VALIDATOR_NUM_MISSION = "Please enter number of mission in range from 0 to 2,147,483,647.";
        public const string VALIDATOR_PASSWORD = "Please enter password with length from 1 to 100.";
        public const string VALIDATOR_PHONE = "Please enter phone number with length from 1 to 20.";
        public const string VALIDATOR_TARGET_NAME = "Please enter target name with length from 1 to 100.";
        public const string VALIDATOR_USEREMAIL_FORMAT = "Incorrect username format";
        public const string VALIDATOR_USERPASS_FORMAT = "Incorrect password format";
        public const string VALIDATOR_USERNAME = "Please enter user name with length from 1 to 100.";
        public const string VALIDATOR_VIDEO = "Please enter Video url with length from 1 to 500.";
        public const string VALIDATOR_YOUTUBE = "Please enter Youtube url with length from 1 to 500.";

        public const string REQUIRE_COMPANYADMIN_NAME = "Company name can not be empty.";
        public const string REQUIRE_CUSTOMER_NAME = "Customer name can not be empty.";
        public const string REQUIRE_CUSTOMER_SEX = "Sex can not be empty.";
        public const string REQUIRE_CAMPAIGNCOMPANY_NAME = "Campaign name can not be empty.";
        public const string REQUIRE_CAMPAIGNCOMPANY_STARTTIME = "Start time can not be empty.";
        public const string REQUIRE_CAMPAIGNCOMPANY_DESCRIPTION = "Description can not be empty.";
        public const string REQUIRE_CAMPAIGNCOMPANY_GIFT = "Gift can not be empty.";
        public const string REQUIRE_CAMPAIGNCOMPANY_NUM_MISSION = "Number of mission can not be empty.";
        public const string REQUIRE_MISSIONCAMPAIGNCOMPANY_NAME = "Mission name can not be empty.";
        public const string REQUIRE_MISSIONCAMPAIGNCOMPANY_DESCRIPTION = "Description can not be empty.";
        public const string REQUIRE_MISSIONCAMPAIGNCOMPANY_NUM_TARGET = "Number of target can not be empty.";
        public const string REQUIRE_TARGETMISSIONCAMPAIGNCOMPANY_NAME = "Target name can not be empty.";
        public const string REQUIRE_TARGETMISSIONCAMPAIGNCOMPANY_FACEBOOK = "Facebook URL can not be empty.";
        public const string REQUIRE_TARGETMISSIONCAMPAIGNCOMPANY_YOUTUBE = "Youtube URL can not be empty.";

        public const string REQUIRE_ADDRESS = "Adress can not be empty.";
        public const string REQUIRE_EMAIL = "Email address wcan not be empty.";
        public const string REQUIRE_PHONE = "Phone number with length from 1 to 20.";
        public const string REQUIRE_USERNAME = "User name can not be empty.";
        public const string REQUIRE_PASSWORD = "Password can not be empty.";
        public const string VALIDATOR_ENDTIME = "End time can not smaller than start time.";

        #endregion IFields

        #region IMethods

        /// <summary>
        ///     Validate input fields with length from 1 to 20
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public bool ValidateChar20(string inp)
        {
            if (inp.Length > 20)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Validate input fields with length from 1 to 100
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public bool ValidateChar100(string inp)
        {
            if (inp.Length > 100)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        ///     Validate input fields with length from 1 to 500
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public bool ValidateChar500(string inp)
        {
            if (inp.Length > 500)
            {
                return false;
            }
            return true;
        }

        #endregion IMethods
    }
}