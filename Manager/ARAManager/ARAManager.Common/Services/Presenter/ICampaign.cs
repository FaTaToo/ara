using System.ServiceModel;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICampaign
    {
        [OperationContract]
        void DoWork();
    }
}
