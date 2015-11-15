using System.ServiceModel;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ISubscription
    {
        [OperationContract]
        void DoWork();
    }
}
