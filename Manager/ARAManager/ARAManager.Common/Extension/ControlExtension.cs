// --------------------------------------------------------------------------------------------------------------------
// <header file="ControlExtension.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
//      Implement the ControlExtension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.UI;

namespace ARAManager.Common.Extension
{
    /// <summary>
    /// Extension to for control in asp.net
    /// </summary>
    public static class ControlExtension
    {
        #region SMethods
        public static IEnumerable<T> GetAllControlsOfType<T>(this Control parent) where T : Control
        {
            var result = new List<T>();
            foreach (Control control in parent.Controls)
            {
                var item = control as T;
                if (item != null)
                {
                    result.Add(item);
                }
                if (control.HasControls())
                {
                    result.AddRange(control.GetAllControlsOfType<T>());
                }
            }
            return result;
        }

        #endregion SMethods
    }
}
