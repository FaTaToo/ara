// --------------------------------------------------------------------------------------------------------------------
/* <header file="ArResource.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *       ARResources - ArResource
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

namespace ARAManager.Common.ArResources
{
    public class ArResource
    {
        #region IProperties
        public string ArType { get; set; }
        public CommonAttributes CommonAttributes { get; set; }
        public string SpecialAttributes { get; set; }
        public string Tags { get; set; }
        public Platforms Platforms { get; set; }
        #endregion IProperties
    }
}
