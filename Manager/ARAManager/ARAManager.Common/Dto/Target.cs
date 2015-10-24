// --------------------------------------------------------------------------------------------------------------------
// <header file="Target.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Target.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_Target]", NameType = typeof(Target), Lazy = false)]
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
        [Property(Column = "TargetName", Name = "Name", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Name { get; set; }

        [DataMember]
        [Property(Column = "Latitude", Name = "Latitude", TypeType = typeof(int),NotNull = false)]
        public virtual int Latitude { get; set; }

        [DataMember]
        [Property(Column = "Longitude", Name = "Longitude", TypeType = typeof(int), NotNull = false)]
        public virtual int Longitude { get; set; }
        
        [DataMember]
        [Property(Column = "Description", Name = "Description", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Description { get; set; }

        [DataMember]
        [Property(Column = "IsComplete", Name = "IsComplete", TypeType = typeof(bool), NotNull = true)]
        public virtual bool IsComplete { get; set; }

        [ManyToOne(Name = "Mission", Column = "MissionName", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Mission Mission { get; set; }

        [ManyToOne(Name = "PreTarget", Column = "TargetName", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Target PreTarget { get; set; }
        #endregion IProperties
    }
}
