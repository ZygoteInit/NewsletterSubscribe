using GreenFinch.Data.Infrastructure;
using GreenFinch.Data.Repositories;
using GreenFinch.Models;
using GreenFinch.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenFinch.Tests
{
    [TestClass]
   public class SourceRepositoryTest
    {
        Mock<ISourceRepository> sourceRepository;
        ISourceService sourceService;
        Mock<IUnitOfWork> unitOfWork;
        List<Source> lstSources;

        [TestInitialize]
        public void Initialize()
        {
            sourceRepository = new Mock<ISourceRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            sourceService = new SourceService(sourceRepository.Object, unitOfWork.Object);
            lstSources = new List<Source>() {
             new Source() { SourceId = 1, Name = "Advedrt" },
             new Source() { SourceId = 2, Name = "Word Of Mouth" },
             new Source() { SourceId = 3, Name = "Others" }
            };


        }

        [TestMethod]
        public void Sources_Get_All()
        {
            //Arrange
            sourceRepository.Setup(x => x.GetAll()).Returns(lstSources);

            //Act
            List<Source> results = sourceService.GetSources() as List<Source>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


    }
}
