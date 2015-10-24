// --------------------------------------------------------------------------------------------------------------------
// <header file="AccountType.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the AccountType.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_AccountType]", NameType = typeof(AccountType), Lazy = false)]
    public class AccountType: ModelBase {

        #region IProperties

        [DataMember]
        [Id(0, Column = "AccountTypeId", Name = "AccountTypeId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int AccountTypeId { get; set; }

        [DataMember]
        [Property(Column = "Name", Name = "Name", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Name { get; set; }

        [DataMember]
        [Property(Column = "GroupType", Name = "GroupType", TypeType = typeof(int), NotNull = true)]
        public virtual int GroupType { get; set; }

        #endregion IProperties

    }
}
