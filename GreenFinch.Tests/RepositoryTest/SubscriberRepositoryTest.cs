using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreenFinch.Data.Repositories;
using GreenFinch.Service;
using GreenFinch.Data.Infrastructure;
using GreenFinch.Models;
using System.Collections.Generic;
using Moq;

namespace GreenFinch.Tests.RepositoryTest
{
    [TestClass]
    public class SubscriberRepositoryTest
    {
        Mock<ISubscriberRepository> subscriberRepository;
        ISubscriberService subscriberService;
        Mock<IUnitOfWork> unitOfWork;
        List<Subscriber> lstSubscriber;
        Mock<ISourceRepository> sourceRepository;
        List<Source> lstSources;

        [TestInitialize]
        public void Initialize()
        {
            subscriberRepository = new Mock<ISubscriberRepository>();
            sourceRepository = new Mock<ISourceRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            subscriberService = new SubscriberService(subscriberRepository.Object,sourceRepository.Object, unitOfWork.Object);

            lstSources = new List<Source>() {
             new Source() { SourceId = 1, Name = "Advedrt" },
             new Source() { SourceId = 2, Name = "Word Of Mouth" },
             new Source() { SourceId = 3, Name = "Others" }
            };


            lstSubscriber = new List<Subscriber>() {
             new Subscriber() { Id = 1, SubscriptionReason = "Test 1", SourceId=1, Email="hanzala@outlook.com" },
             new Subscriber() { Id = 2, SubscriptionReason = "Test 2", SourceId=1, Email="hanzala1@outlook.com" },
              new Subscriber() { Id = 3, SubscriptionReason = "Test 3", SourceId=1, Email="hanzala2@outlook.com" },
            };


        }

        [TestMethod]
        public void Subscriber_Get_All()
        {
            //Arrange
            sourceRepository.Setup(x => x.GetAll()).Returns(lstSources);
            subscriberRepository.Setup(x => x.GetAll()).Returns(lstSubscriber);

            //Act
            List<Subscriber> results = subscriberService.GetSubscribers() as List<Subscriber>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void CheckIfEmailExists()
        {
            //Arrange
            subscriberRepository.Setup(x => x.GetAll()).Returns(lstSubscriber);

            //Act
            bool result = subscriberService.CheckIfEmailExists("hanzala@outlook.com");

            //Assert
            Assert.AreEqual(false, result);

        }


    }
}

