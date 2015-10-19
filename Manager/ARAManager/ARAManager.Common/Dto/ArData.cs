// --------------------------------------------------------------------------------------------------------------------
// <header file="ArData.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ArData.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto {
    [DataContract]
    [Class(Table = "[ARA_ArData]", NameType = typeof(ArData), Lazy = false)]
    public class ArData: ModelBase {

        #region IProperties

        [DataMember]
        [Id(0, Column = "ArDataId", Name = "ArDataId", TypeType = typeof(int))]
        [Generator(1, Class = "identity")]
        public virtual int ArDataId { get; set; }

        [DataMember]
        [Property(Column = "VideoUrl", Name = "VideoUrl", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string VideoUrl { get; set; }

        [DataMember]
        [Property(Column = "FacebookUrl", Name = "FacebookUrl", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string FacebookUrl { get; set; }

        [DataMember]
        [Property(Column = "YoutubeUrl", Name = "YoutubeUrl", TypeType = typeof(string), Length = 500, NotNull = true)]
        public virtual string YoutubeUrl { get; set; }

        [ManyToOne(Name = "Target", Column = "TargetId", NotNull = false, Fetch = FetchMode.Select)]
        [DataMember]
        public virtual Target Target { get; set; }

        #endregion IProperties

    }
}
