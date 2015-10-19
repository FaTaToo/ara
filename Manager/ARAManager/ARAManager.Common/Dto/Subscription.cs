// --------------------------------------------------------------------------------------------------------------------
// <header file="Subscription.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Subscription.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_Subscription]", NameType = typeof(Subscription), Lazy = false)]
    public class Subscription: ModelBase {
        #region IProperties
        [CompositeId(1)]
        [KeyManyToOne(2, Name = "Customer", Column = "CustomerId")]
        [KeyManyToOne(3, Name = "Campaign", Column = "CampaignId")]

        [ManyToOne(Name = "Customer", Column = "CustomerId", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Customer Customer { get; set; }

        [ManyToOne(Name = "Campaign", Column = "CampaignId", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Campaign Campaign { get; set; }

        [DataMember]
        [Property(Column = "IsComplete", Name = "IsComplete", TypeType = typeof(bool), NotNull = true)]
        public virtual bool IsComplete { get; set; }

        [DataMember]
        [Property(Column = "GiftCode", Name = "GiftCode", TypeType = typeof(string), Length = 20, NotNull = true)]
        public virtual string GiftCode { get; set; }

        [DataMember]
        [Property(Column = "Comment", Name = "Comment", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Comment { get; set; }

        [DataMember]
        [Property(Column = "Rating", Name = "Rating", TypeType = typeof(int), NotNull = true)]
        public virtual int Rating { get; set; }
        #endregion IProperties
    }
}
