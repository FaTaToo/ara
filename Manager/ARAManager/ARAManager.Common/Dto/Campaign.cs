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
using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_Campaign]", NameType = typeof(Campaign), Lazy = false)]
    public class Campaign: ModelBase {

        #region IProperties

        [DataMember]
        [Id(0, Column = "CampaignId", Name = "CampaignId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int CampaignId { get; set; }

        [DataMember]
        [Property(Column = "Name", Name = "Name", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Name { get; set; }

        [DataMember]
        [Property(Column = "StartTime", Name = "StartTime", TypeType = typeof(DateTime), NotNull = true)]
        public virtual DateTime StartTime { get; set; }

        [DataMember]
        [Property(Column = "EndTime", Name = "EndTime", TypeType = typeof(DateTime), NotNull = false)]
        public virtual DateTime? EndTime { get; set; }

        [DataMember]
        [Property(Column = "Descriptor", Name = "Descriptor", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Descriptor { get; set; }

        [DataMember]
        [Property(Column = "Banner", Name = "Banner", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Banner { get; set; }

        [DataMember]
        [Property(Column = "Avatar", Name = "Avatar", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Avatar { get; set; }

        [DataMember]
        [Property(Column = "Gift", Name = "Gift", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Gift { get; set; }
        
        [DataMember]
        [Property(Column = "NumMission", Name = "NumMission", TypeType = typeof(int), NotNull = true)]
        public virtual string NumMission { get; set; }

        [ManyToOne(Name = "Company", Column = "CompanyId", NotNull = true, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Company Company { get; set; }

        #endregion IProperties

    }
}
