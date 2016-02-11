// --------------------------------------------------------------------------------------------------------------------
/* <header file="CampaignType.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the CampaignType.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto
{
    [DataContract]
    [Class(Table = "ARA_CampaignType", NameType = typeof (CampaignType), Lazy = false)]
    public class CampaignType : ModelBase
    {
        [DataMember]
        [Id(0, Column = "CampaignTypeId", Name = "CampaignTypeId", TypeType = typeof (int))]
        [Generator(1, Class = "identity")]
        public virtual int CampaignTypeId { get; set; }

        [DataMember]
        [Property(Column = "CampaignTypeName", Name = "CampaignTypeName", TypeType = typeof (string), Length = 100,
            NotNull = true)]
        public virtual string CampaignTypeName { get; set; }
    }
}