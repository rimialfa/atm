using AutomatedTellerMachine.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Tests.Controllers
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AuthController controller = new AuthController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
