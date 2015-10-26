// --------------------------------------------------------------------------------------------------------------------
// <header file="Validator.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement Validator helper for web form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ARAManager.Presentation.Client
{
    public class Validation
    {
        #region IFields

        public const string VALIDATOR_USEREMAIL = "Incorrect username format";
        public const string VALIDATOR_USERPASS = "Incorrect password format";

        #endregion IFields

        #region IMethods

        /// <summary>
        /// Validate input fields with length from 1 to 20
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
        ///  Validate input fields with length from 1 to 100
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        public bool ValidateChar100(string inp) {
            if (inp.Length > 100) {   
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate input fields with length from 1 to 500
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