// --------------------------------------------------------------------------------------------------------------------
// <header file="Account.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_Account]", NameType = typeof(Account), Lazy = false)]
    public class Account: ModelBase {

        #region IProperties

        [DataMember]
        [Id(0, Column = "AccountId", Name = "AccountId", TypeType = typeof (int))]
        [Generator(1, Class = "identity")]
        public virtual int AccountId { get; set; }

        [DataMember]
        [Property(Column = "UserName", Name = "UserName", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string UserName { get; set; }


        [DataMember]
        [Property(Column = "Password", Name = "Password", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Password { get; set; }

        [ManyToOne(Name = "AccountType", Column = "AccountTypeId", NotNull = true, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual AccountType AccountType { get; set; }
        #endregion IProperties

    }
}
