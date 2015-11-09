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

using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "ARA_Mission", NameType = typeof(Mission), Lazy = false)]
    public class Mission: ModelBase {
        #region IFields

        private ICollection<Target> m_targets;
        private ICollection<Subscription> m_subscriptions; 

        #endregion IFields

        #region IConstructors

        public Mission() {
            m_targets = new HashSet<Target>();
            m_subscriptions = new HashSet<Subscription>();
        }

        #endregion IConstructors

        #region IProperties

        [DataMember]
        [Id(0, Column = "MissionId", Name = "MissionId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int MissionId { get; set; }

        [DataMember]
        [Property(Column = "MissionName", Name = "Name", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Name { get; set; }

        [DataMember]
        [Property(Column = "Description", Name = "Description", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Description { get; set; }

        [DataMember]
        [Property(Column = "Avatar", Name = "Avatar", TypeType = typeof(byte[]), Length = 500, NotNull = true)]
        public virtual byte[] Avatar { get; set; }
        
        [DataMember]
        [Property(Column = "NumTarget", Name = "NumTarget", TypeType = typeof(int), NotNull = true)]
        public virtual int NumTarget { get; set; }

        [ManyToOne(Name = "Campaign", Column = "CampaignName", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Campaign Campaign { get; set; }

        [DataMember]
        [Set(0, Table = "ARA_Target", Inverse = true, Cascade = "all-delete-orphan", Access = "field", Lazy = CollectionLazy.False, Name = "m_targets")]
        [Key(1, Column = "MissionName")]
        [OneToMany(2, ClassType = typeof(Target))]
        public virtual ICollection<Target> Targets {
            get {
                m_targets = m_targets ?? new HashSet<Target>();
                return m_targets;
            }
        }

        [DataMember]
        [Set(0, Table = "ARA_Subscription", Inverse = true, Cascade = "all-delete-orphan", Access = "field", Lazy = CollectionLazy.False, Name = "m_subscriptions")]
        [Key(1, Column = "CurrentMission")]
        [OneToMany(2, ClassType = typeof(Subscription))]
        public virtual ICollection<Subscription> Subscriptions {
            get {
                m_subscriptions = m_subscriptions ?? new HashSet<Subscription>();
                return m_subscriptions;
            }
        }

        #endregion IProperties
    }
}
