using System.ServiceModel;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerAccount
    {
        [OperationContract]
        void DoWork();
    }
}
