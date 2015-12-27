// --------------------------------------------------------------------------------------------------------------------
/* <header file="CampaignDataAccessImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the Data access class for Campaign.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

// --------------------------------------------------------------------------------------------------------------------
// <header file="ProgramCheckInController.cs" group="288-462">
//
// Last modified:
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ProgramCheckInController.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using ARAManager.Business.Service.Ninject;
using ARAManager.Common.Factory;
using Ninject;
using Ninject.Web.Common;

namespace ARAManager.Business.Service
{
    /// <summary>
    ///     Global of the webservice
    /// </summary>
    public class Global : NinjectHttpApplication
    {
        /// <summary>
        ///     Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the Start event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Session_Start(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the BeginRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the AuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the End event of the Session control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Session_End(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Handles the End event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Application_End(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>
        ///     The created kernel.
        /// </returns>
        protected override IKernel CreateKernel()
        {
            var kernel = NinjectKernelFactory.Kernel;
            kernel.Load(new ServiceBindingModule());
            return kernel;
        }
    }
}