// --------------------------------------------------------------------------------------------------------------------
/* <header file="Company.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the Company.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "ARA_Company", NameType = typeof(Company), Lazy = false)]
    public class Company: ModelBase {
        #region IFields

        private ICollection<Campaign> m_campaigns;

        #endregion IFields
        #region IConstructors
        public Company() {
            m_campaigns = new HashSet<Campaign>();
        }
        #endregion IConstructors

        #region IProperties

        [DataMember]
        [Id(0, Column = "CompanyId", Name = "CompanyId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int CompanyId { get; set; }

        [DataMember]
        [Property(Column = "CompanyName", Name = "CompanyName", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string CompanyName { get; set; }

        [DataMember]
        [Property(Column = "Address", Name = "Address", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string Address { get; set; }

        [DataMember]
        [Property(Column = "Email", Name = "Email", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Email { get; set; }

        [DataMember]
        [Property(Column = "Phone", Name = "Phone", TypeType = typeof(string), Length = 20, NotNull = true)]
        public virtual string Phone { get; set; }

        [DataMember]
        [Property(Column = "UserName", Name = "UserName", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string UserName { get; set; }

        [DataMember]
        [Property(Column = "Password", Name = "Password", TypeType = typeof(string), Length = 100, NotNull = true)]
        public virtual string Password { get; set; }

        [DataMember]
        [Set(0, Table = "ARA_Campaign", Inverse = true, Cascade = "all-delete-orphan", Access = "field", Lazy = CollectionLazy.False, Name = "m_campaigns")]
        [Key(1, Column = "CompanyId")]
        [OneToMany(2, ClassType = typeof(Campaign))]
        public virtual ICollection<Campaign> Campaigns {
            get {
                m_campaigns = m_campaigns ?? new HashSet<Campaign>();
                return m_campaigns;
            }
        }

        #endregion IProperties
    }
}
