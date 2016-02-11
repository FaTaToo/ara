// --------------------------------------------------------------------------------------------------------------------
/* <header file="CampaignTypeServiceImp.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the service class for CampaignType.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Common.Dto;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services
{
    public class CampaignTypeServiceImpl : ICampaignTypeServiceImpl
    {
        #region IMethods

        /// <summary>
        ///     Get campaign type by campaing id
        /// </summary>
        /// <param name="campaignTypeId"></param>
        /// <returns></returns>
        public CampaignType GetCampaignTypeById(int campaignTypeId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignTypeDataAccess>();
            return srvDao.GetById(campaignTypeId);
        }

        /// <summary>
        ///     Get campaign type by name
        /// </summary>
        /// <param name="campaignTypeName"></param>
        /// <returns></returns>
        public CampaignType GetCampaignTypeByName(string campaignTypeName)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignTypeDataAccess>();
            var criteria = DetachedCriteria.For<CampaignType>();
            if (!string.IsNullOrEmpty(campaignTypeName))
            {
                criteria.Add(Restrictions.Where<CampaignType>(c => c.CampaignTypeName == campaignTypeName));
            }
            return srvDao.FindByCriteria(criteria).FirstOrDefault();
        }

        #endregion IMethods
    }
}