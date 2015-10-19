// --------------------------------------------------------------------------------------------------------------------
// <header file="NinjectKernelFactory.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the NinjectKernelFactory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Ninject;

namespace ARAManager.Common.Factory
{
    /// <summary> 
    /// Class summary. 
    /// </summary>
    public class NinjectKernelFactory
    {
        #region S_Fields

        /// <summary>
        /// The cached kernel instance.
        /// </summary>
        private static readonly IKernel s_kernel = new StandardKernel();

        #endregion

        #region IProperties

        /// <summary>
        /// Gets the kernel. One application only has one kernel instance.
        /// </summary>
        /// <returns>The singlton Kernerl instance.</returns>
        public static IKernel Kernel
        {
            get
            {
                return s_kernel;
            }
        }

        #endregion
    }
}
