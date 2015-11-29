// --------------------------------------------------------------------------------------------------------------------
/* <header file="PreserveReferencesAttribute.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the PreserveReferencesAttribute.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace ARAManager.Common.Services.Behaviors
{
    /// <summary>
    /// Create Preservce reference attribute to solve problem circulation serialization
    /// http://msdn2.microsoft.com/en-us/library/aa730857(VS.80).aspx#netremotewcf_topic8
    /// http://blogs.msdn.com/b/drnick/archive/2007/05/15/replacing-the-serializer-part-1.aspx
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class PreserveReferencesAttribute : Attribute, IOperationBehavior
    {
       #region IMethods

        /// <summary>
        /// Adding bindingParameters.
        /// </summary>
        /// <param name="operationDescription">operationDescription of operation</param>
        /// <param name="bindingParameters">collection od bindingParameters</param>
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        /// Add client behavior.
        /// </summary>
        /// <param name="operationDescription">Description of operation</param>
        /// <param name="clientOperation">Proxy of client</param>
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            ReplaceDataContractSerializerOperationBehavior(operationDescription);
        }

        /// <summary>
        /// Apply behavior.
        /// </summary>
        /// <param name="operationDescription">operationDescription of operation</param>
        /// <param name="dispatchOperation">Dispatch behavior</param>
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            ReplaceDataContractSerializerOperationBehavior(operationDescription);
        }

        /// <summary>
        /// Validate operation operationDescription
        /// </summary>
        /// <param name="operationDescription">operationDescription of operation</param>
        public void Validate(OperationDescription operationDescription)
        {
        }

        /// <summary>
        /// Replaces the data contract serializer operation behavior.
        /// </summary>
        /// <param name="description">The description.</param>
        private static void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
        {
            var dcsOperationBehavior = description.Behaviors.Find<DataContractSerializerOperationBehavior>();
            if (dcsOperationBehavior != null)
            {
                description.Behaviors.Remove(dcsOperationBehavior);
                description.Behaviors.Add(new PreserveReferencesOperationBehavior(description));
            }
        }

        #endregion IMethods
    }
}
