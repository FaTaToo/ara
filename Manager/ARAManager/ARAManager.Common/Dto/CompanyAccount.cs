// --------------------------------------------------------------------------------------------------------------------
// <header file="CompanyAccount.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the CompanyAccount.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_CompanyAccount]", NameType = typeof(CompanyAccount), Lazy = false)]
    public class CompanyAccount: ModelBase {

        #region IProperties

        [CompositeId(1)]
        [KeyManyToOne(2, Name = "Account", Column = "AccountId")]
        [KeyManyToOne(3, Name = "Company", Column = "CompanyId")]
        
        [ManyToOne(Name = "Account", Column = "AccountId", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Account Account { get; set; }

        [ManyToOne(Name = "Company", Column = "CompanyId", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Company Company { get; set; }

        [DataMember]
        [Property(Column = "UserName", Name = "UserName", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string UserName { get; set; }

        [DataMember]
        [Property(Column = "Password", Name = "Password", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Password { get; set; }

        #endregion IProperties
    }
}
