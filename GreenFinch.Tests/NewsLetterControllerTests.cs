using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreenFinch.Web.Controllers;
using GreenFinch.Service;
using Moq;
using System.Web.Mvc;
using GreenFinch.Models;
using GreenFinch.Web.ViewModels;

namespace GreenFinch.Tests
{
    [TestClass]
    public class NewsLetterControllerTests
    {
        NewsLetterController ControllerUnderTest;
        private Mock<ISubscriberService> SubscriberService;
        private Mock<ISourceService> SourceService;

        [TestInitialize]
        public void Setup()
        {
            SubscriberService = new Mock<ISubscriberService>();
            SourceService = new Mock<ISourceService>();
            ControllerUnderTest = new NewsLetterController(SubscriberService.Object, SourceService.Object);

        }

        [TestMethod]
        public void ControllerRendersCreateView()
        {
            var result = ControllerUnderTest.Create() as ViewResult;

            Assert.AreEqual("", result.ViewName);
         
        }

        [TestMethod]
        public void Invalid_Subscriber_Create()
        {
            SubscriberViewModel viewModel = new SubscriberViewModel();

            var result = ControllerUnderTest.Create(viewModel) as ViewResult;

            Assert.AreEqual("", result.ViewName);

        }

    }
}
