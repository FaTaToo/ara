// --------------------------------------------------------------------------------------------------------------------
/* <header file="Target.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the Target.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "ARA_Target", NameType = typeof(Target), Lazy = false)]
    public class Target: ModelBase {

        #region IProperties
        [DataMember]
        [Id(0, Column = "TargetId", Name = "TargetId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int TargetId { get; set; }

        [DataMember]
        [Property(Column = "Url", Name = "Url", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Url { get; set; }

        [DataMember]
        [Property(Column = "TargetName", Name = "TargetName", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string TargetName { get; set; }

        [DataMember]
        [Property(Column = "Latitude", Name = "Latitude", TypeType = typeof(double),NotNull = false)]
        public virtual double? Latitude { get; set; }

        [DataMember]
        [Property(Column = "Longitude", Name = "Longitude", TypeType = typeof(double), NotNull = false)]
        public virtual double? Longitude { get; set; }
        
        [DataMember]
        [Property(Column = "FacebookUrl", Name = "FacebookUrl", TypeType = typeof(string), Length = 500, NotNull = false)]
        public virtual string FacebookUrl { get; set; }

        [DataMember]
        [Property(Column = "YoutubeUrl", Name = "YoutubeUrl", TypeType = typeof(string), Length = 500, NotNull = false)]
        public virtual string YoutubeUrl { get; set; }

        [ManyToOne(Name = "Mission", Column = "MissionId", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Mission Mission { get; set; }

        #endregion IProperties
    }
}
