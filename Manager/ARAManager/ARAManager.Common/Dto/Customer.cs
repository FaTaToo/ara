// --------------------------------------------------------------------------------------------------------------------
/* <header file="Customer.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the Customer.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "ARA_Customer", NameType = typeof(Customer), Lazy = false)]
    public class Customer : ModelBase {
        #region IFields

        private ICollection<Subscription> m_subscriptions;

        #endregion IFields

        #region IConstructors

        public Customer() {
            m_subscriptions = new HashSet<Subscription>();
        }

        #endregion IConstructors

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
        [Property(Column = "Sex", Name = "Sex", TypeType = typeof(string), Length = 6, NotNull = true)]
        public virtual string Sex { get; set; }

        [DataMember]
        [Property(Column = "BirthDay", Name = "BirthDay", TypeType = typeof(DateTime), NotNull = true)]
        public virtual DateTime BirthDay { get; set; }

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
        [Set(0, Table = "ARA_Subscription", Inverse = true, Cascade = "all-delete-orphan", Access = "field", Lazy = CollectionLazy.False, Name = "m_subscriptions")]
        [Key(1, Column = "CustomerId")]
        [OneToMany(2, ClassType = typeof(Subscription))]
        public virtual ICollection<Subscription> Subscriptions  {
            get {
                m_subscriptions = m_subscriptions ?? new HashSet<Subscription>();
                return m_subscriptions;
            }
        }

        #endregion IProperties
    }
}
