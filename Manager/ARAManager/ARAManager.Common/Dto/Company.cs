// --------------------------------------------------------------------------------------------------------------------
// <header file="Company.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Company.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_Company]", NameType = typeof(Company), Lazy = false)]
    public class Company: ModelBase {
        #region IProperties

        [DataMember]
        [Id(0, Column = "CompanyId", Name = "CompanyId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int CompanyId { get; set; }

        [DataMember]
        [Property(Column = "CompanyName", Name = "Name", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Name { get; set; }

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
