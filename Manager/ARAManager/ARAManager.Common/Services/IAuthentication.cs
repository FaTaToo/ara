using System.ServiceModel;

namespace ARAManager.Common.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthentication" in both code and config file together.
    [ServiceContract]
    public interface IAuthentication
    {
        [OperationContract]
        void DoWork();
    }
}
