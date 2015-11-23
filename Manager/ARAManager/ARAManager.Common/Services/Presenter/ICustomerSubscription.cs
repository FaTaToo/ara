using System.ServiceModel;

namespace ARAManager.Common.Services.Presenter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerSubscription" in both code and config file together.
    [ServiceContract]
    public interface ICustomerSubscription
    {
        [OperationContract]
        void DoWork();
    }
}
