// --------------------------------------------------------------------------------------------------------------------
// <header file="Mission.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Mission.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_Mission]", NameType = typeof(Mission), Lazy = false)]
    public class Mission: ModelBase {
        #region IProperties

        [DataMember]
        [Id(0, Column = "MissionId", Name = "MissionId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int MissionId { get; set; }

        [DataMember]
        [Property(Column = "Name", Name = "Name", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Name { get; set; }

        [DataMember]
        [Property(Column = "Descriptor", Name = "Descriptor", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Descriptor { get; set; }

        [DataMember]
        [Property(Column = "Avatar", Name = "Avatar", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Avatar { get; set; }

        [DataMember]
        [Property(Column = "IsComplete", Name = "IsComplete", TypeType = typeof(bool), NotNull = true)]
        public virtual bool IsComplete { get; set; }
        
        [DataMember]
        [Property(Column = "NumTarget", Name = "NumTarget", TypeType = typeof(int), NotNull = true)]
        public virtual int NumTarget { get; set; }

        [ManyToOne(Name = "Campaign", Column = "CampaignId", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Campaign Campaign { get; set; }

        [ManyToOne(Name = "PreMission", Column = "PreMission", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Mission PreMission { get; set; }

        #endregion IProperties
    }
}
