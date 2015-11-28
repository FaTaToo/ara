// --------------------------------------------------------------------------------------------------------------------
/* <header file="PreserveReferencesOperationBehavior.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the PreserveReferencesOperationBehavior.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.Xml;

namespace ARAManager.Common.Services.Behaviors
{
    /// <summary> 
    /// Class summary. 
    /// </summary>
    public class PreserveReferencesOperationBehavior : DataContractSerializerOperationBehavior
    {
        #region Constants

        /// <summary>
        /// Max item in object graph is allowed
        /// </summary>
        private const int MAX_ITEM_IN_OBJECT_GRAPH = 0x7FFF;

        #endregion Constants

        #region IFields
        #endregion IFields

        #region IConstructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PreserveReferencesOperationBehavior"/> class.
        /// </summary>
        /// <param name="operationDescription">The operation description.</param>
        public PreserveReferencesOperationBehavior(OperationDescription operationDescription)
            : base(operationDescription)
        {
        }

        #endregion IConstructors

        #region IProperties
        #endregion IProperties

        #region IMethods

        /// <summary>
        /// Creates an instance of a class that inherits from <see cref="T:System.Runtime.Serialization.XmlObjectSerializer"/> for serialization and deserialization processes.
        /// </summary>
        /// <param name="type">The <see cref="T:System.Type"/> to create the serializer for.</param>
        /// <param name="name">The name of the generated type.</param>
        /// <param name="ns">The namespace of the generated type.</param>
        /// <param name="knownTypes">An <see cref="T:System.Collections.Generic.IList`1"/> of <see cref="T:System.Type"/> that contains known types.</param>
        /// <returns>
        /// An instance of a class that inherits from the <see cref="T:System.Runtime.Serialization.XmlObjectSerializer"/> class.
        /// </returns>
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(
                type,
                name,
                ns,
                knownTypes,
                MAX_ITEM_IN_OBJECT_GRAPH /*maxItemsInObjectGraph*/,
                false /*ignoreExtensionDataObject*/,
                true /*preserveObjectReferences*/,
                null/*dataContractSurrogate*/);
        }

        /// <summary>
        /// Creates an instance of a class that inherits from <see cref="T:System.Runtime.Serialization.XmlObjectSerializer"/> for serialization and deserialization processes with an <see cref="T:System.Xml.XmlDictionaryString"/> that contains the namespace.
        /// </summary>
        /// <param name="type">The type to serialize or deserialize.</param>
        /// <param name="name">The name of the serialized type.</param>
        /// <param name="ns">An <see cref="T:System.Xml.XmlDictionaryString"/> that contains the namespace of the serialized type.</param>
        /// <param name="knownTypes">An <see cref="T:System.Collections.Generic.IList`1"/> of <see cref="T:System.Type"/> that contains known types.</param>
        /// <returns>
        /// An instance of a class that inherits from the <see cref="T:System.Runtime.Serialization.XmlObjectSerializer"/> class.
        /// </returns>
        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes, MAX_ITEM_IN_OBJECT_GRAPH, false, true /* preserveObjectReferences */, null);
        }

        #endregion IMethods
    }
}
