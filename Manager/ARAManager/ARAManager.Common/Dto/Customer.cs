// --------------------------------------------------------------------------------------------------------------------
// <header file="Customer.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Customer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto
{
    [DataContract]
    [Class(Table = "[ARA_Customer]", NameType = typeof(Customer), Lazy = false)]
    public class Customer : ModelBase
    {

        #region IProperties

        [DataMember]
        [Id(0, Column = "CustomerId", Name = "CustomerId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int CustomerId { get; set; }

        [DataMember]
        [Property(Column = "FirstName", Name = "FirstName", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string FirstName { get; set; }

        [DataMember]
        [Property(Column = "LastName", Name = "LastName", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string LastName { get; set; }

        [DataMember]
        [Property(Column = "Sex", Name = "Sex", TypeType = typeof(bool), NotNull = true)]
        public virtual bool Sex { get; set; }

        [DataMember]
        [Property(Column = "BirthDay", Name = "BirthDay", TypeType = typeof(DateTime), NotNull = false)]
        public virtual string BirthDay { get; set; }

        [DataMember]
        [Property(Column = "Address", Name = "Address", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Address { get; set; }

        [DataMember]
        [Property(Column = "Email", Name = "Email", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Email { get; set; }

        [DataMember]
        [Property(Column = "Phone", Name = "Phone", TypeType = typeof(string), Length = 20, NotNull = true)]
        public virtual string Phone { get; set; }

        [ManyToOne(Column = "UserName", Name = "Account", NotNull = true, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Account Account { get; set; }

        #endregion IProperties

    }
}
