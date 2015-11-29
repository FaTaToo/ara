// --------------------------------------------------------------------------------------------------------------------
/* <header file="CustomerCampaign.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement CustomerCampaign service of presenter.
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
    public class CustomerCampaign : ICustomerCampaign
    {
        public List<Campaign> GetListOfCampaigns()
        {
            throw new NotImplementedException();
        }

        public Campaign GetCampaignByName(string campaignName)
        {
            throw new NotImplementedException();
        }
    }
}