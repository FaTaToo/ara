// --------------------------------------------------------------------------------------------------------------------
/* <header file="StringExtension.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the StringExtension.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using System.Web.Script.Serialization;

namespace ARAManager.Common.Extension
{
    /// <summary>
    ///     Extension methods for class string.
    /// </summary>
    public static class StringExtension
    {
        #region SMethods

        /// <summary>
        ///     Bring the Append() method of StringBuilder for String
        /// </summary>
        /// <param name="para"></param>
        /// <param name="add"></param>
        /// <returns></returns>
        public static string Append(this string para, string add)
        {
            var str = new StringBuilder(para);
            str.Append(add);
            return para;
        }

        /// <summary>
        ///     Convert object to JSON string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        #endregion SMethods
    }
}