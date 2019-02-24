using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RishavBookReadingEventManagement.Controllers;


namespace RishavBookReadingEventManagement.Tests
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod]
        public void ReturnsSignUpView()
        {
            LoginController controllerUnderTest = new LoginController();
            var result = controllerUnderTest.SignUp() as ViewResult;
            Assert.AreEqual("SignUp", result.ViewName);
        }

        [TestMethod]
        public void CheckModel()
        {
            LoginController controllerUnderTest = new LoginController();
            var result = controllerUnderTest.LoginUser() as ViewResult;
            Assert.AreEqual(null, result.Model);

        }
    }
}
