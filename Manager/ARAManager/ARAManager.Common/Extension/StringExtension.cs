// --------------------------------------------------------------------------------------------------------------------
// <header file="StringExtension.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the StringExtension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;

namespace ARAManager.Common.Extension
{
    /// <summary>
    /// Extension methods for class string.
    /// </summary>
    public static class StringExtension
    {
        #region SMethods
        public static string Append(this string para, string add)
        {
            var str= new StringBuilder(para);
            str.Append(add);
            return para;
        }
        #endregion SMethods
    }
}
