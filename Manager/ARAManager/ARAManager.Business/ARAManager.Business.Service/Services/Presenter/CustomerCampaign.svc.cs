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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Factory;
using ARAManager.Common.PresenterJson.ArResources;
using ARAManager.Common.Services.Presenter;
using Newtonsoft.Json;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services.Presenter
{
    public class CustomerCampaign : ICustomerCampaign
    {
        #region IMethods
        public IList<Campaign> GetListOfCampaigns()
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();
            return srvDao.FindByCriteria(criteria);
        }

        public Campaign GetCampaignByName(string campaignName)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();
            if (!string.IsNullOrEmpty(campaignName))
            {
                criteria.Add(Restrictions.Where<Campaign>(c => c.CampaignName == campaignName));
            }
            return srvDao.FindByCriteria(criteria).FirstOrDefault();
        }

        public RootObject GetArData(string targetUrl)
        {
            using (StreamReader streamReader = new StreamReader(Dictionary.PATH_AR_JSON + targetUrl + ".json"))
            {
                var jsonFile = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<RootObject>(jsonFile);
            }
        }

        #endregion IMethods
    }
}