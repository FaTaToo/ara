using System.ServiceModel;

namespace ARAManager.Common.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccount" in both code and config file together.
    [ServiceContract]
    public interface IAccount
    {
        [OperationContract]
        void DoWork();
    }
}
