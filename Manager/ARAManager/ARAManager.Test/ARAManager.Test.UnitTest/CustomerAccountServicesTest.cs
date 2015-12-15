using ARAManager.Business.Service.Services.Presenter;
using ARAManager.Common.PresenterJson;
using NUnit.Framework;

namespace ARAManager.Test.UnitTest
{
    [TestFixture]
    public class CustomerAccountServicesTest
    {
        [Test]
        public void Authenticate()
        {
            var customerAccount =new CustomerAccount();
            Assert.AreEqual("Succes",customerAccount.Authenticate(
                                new AuthenticationJsonRequest()
                                {
                                    UserName = "tma",
                                    Password = "tma"
                                }).Message);
        }
    }
}
