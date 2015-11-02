// --------------------------------------------------------------------------------------------------------------------
// <header file="Campaign.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Campaign.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "ARA_Campaign", NameType = typeof(Campaign), Lazy = false)]
    public class Campaign: ModelBase {
        #region IFields

        private ICollection<Mission> m_missions;
        private ICollection<Subscription> m_subscriptions;

        #endregion IFields

        #region IConstructors
        public Campaign() {
            m_missions = new HashSet<Mission>();
            m_subscriptions = new HashSet<Subscription>();
        }

        #endregion IConstructors

        #region IProperties

        [DataMember]
        [Id(0, Column = "CampaignId", Name = "CampaignId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int CampaignId { get; set; }

        [DataMember]
        [Property(Column = "CampaignName", Name = "Name", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Name { get; set; }

        [DataMember]
        [Property(Column = "StartTime", Name = "StartTime", TypeType = typeof(DateTime), NotNull = true)]
        public virtual DateTime StartTime { get; set; }

        [DataMember]
        [Property(Column = "EndTime", Name = "EndTime", TypeType = typeof(DateTime), NotNull = false)]
        public virtual DateTime? EndTime { get; set; }

        [DataMember]
        [Property(Column = "Description", Name = "Description", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Description { get; set; }

        [DataMember]
        [Property(Column = "Banner", Name = "Banner", TypeType = typeof(byte[]), NotNull = true)]
        public virtual byte[] Banner { get; set; }

        [DataMember]
        [Property(Column = "Avatar", Name = "Avatar", TypeType = typeof(byte[]), NotNull = true)]
        public virtual byte[] Avatar { get; set; }

        [DataMember]
        [Property(Column = "Gift", Name = "Gift", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Gift { get; set; }
        
        [DataMember]
        [Property(Column = "NumMission", Name = "NumMission", TypeType = typeof(int), NotNull = true)]
        public virtual int NumMission { get; set; }

        [ManyToOne(Name = "Company", Column = "CompanyName", NotNull = true, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Company Company { get; set; }

        [DataMember]
        [Set(0, Table = "Mission", Inverse = true, Cascade = "all-delete-orphan", Access = "field", Lazy = CollectionLazy.False, Name = "m_missions")]
        [Key(1, Column = "CampaignName")]
        [OneToMany(2, ClassType = typeof(Mission))]
        public virtual ICollection<Mission> Missions {
            get {
                m_missions = m_missions ?? new HashSet<Mission>();
                return m_missions;
            }
        }

        [DataMember]
        [Set(0, Table = "Subscription", Inverse = true, Cascade = "all-delete-orphan", Access = "field", Lazy = CollectionLazy.False, Name = "m_subscriptions")]
        [Key(1, Column = "CampaignId")]
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
