// --------------------------------------------------------------------------------------------------------------------
/* <header file="CustomerSubscription.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement CustomerSubscription service of presenter.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using ARAManager.Common.Dto;
using ARAManager.Common.Services.Presenter;

namespace ARAManager.Business.Service.Services.Presenter
{
    public class CustomerSubscription : ICustomerSubscription
    {
        public bool JoinCampaign(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public IList<Subscription> GetListOfSubscriptions(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Subscription GetSubscription(int subscriptionId)
        {
            throw new NotImplementedException();
        }
    }
}