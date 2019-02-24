using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RishavBookReadingEventManagement.Controllers;

namespace RishavBookReadingEventManagement.Tests
{
    [TestClass]
    public class BookReadingEventControllerTest
    {
     
        [TestMethod]
        public void ReturnsGetBookReadingEventDetailsView()
        {
            BookReadingEventController controllerUnderTest = new BookReadingEventController();
            var result = controllerUnderTest.GetBookReadingEventDetails(4) as ViewResult;
            Assert.AreEqual("GetBookReadingEventDetails", result.ViewName);

        }

        [TestMethod]
        public void CheckModel()
        {
            BookReadingEventController controllerUnderTest = new BookReadingEventController();
            var result = controllerUnderTest.GetBookReadingEventDetails(4) as ViewResult;
            Assert.AreEqual(null, result.Model);

        }
    }
}
