using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EZUJIA_HFT_2022232.Test
{
    [TestFixture]
    public class TesterClass
    {
        CarsLogic logic;
        CarBrandLogic carbrandlogic;
        RentLogic rentlogic;
        Mock<IRepository<Cars>> mockCarRepo;
        Mock<IRepository<CarBrand>> carbrandrepo;
        Mock<IRepository<Rent>> rentsrepo;


        [SetUp]
        public void Init()
        {
            mockCarRepo = new Mock<IRepository<Cars>>();
            mockCarRepo.Setup(m => m.ReadAll()).Returns(new List<Cars>()
            {
                new Cars("1,1,E60,HFG-453,2004,310"),
                new Cars("5,21,V60,RST-876,2021,300")
            }.AsQueryable());

            carbrandrepo = new Mock<IRepository<CarBrand>>();
            carbrandrepo.Setup(m => m.ReadAll()).Returns(new List<CarBrand>()
            {
                new CarBrand("1,BMW"),
                new CarBrand("2,Volvo")
            }.AsQueryable());

            rentsrepo = new Mock<IRepository<Rent>>();
            rentsrepo.Setup(m => m.ReadAll()).Returns(new List<Rent>()
            {
                new Rent("1,2020-9-11,Lily Parker,1"),
                new Rent("5,2015-04-25,James Martinez,10")
            }.AsQueryable());

            logic = new CarsLogic(mockCarRepo.Object);
            carbrandlogic = new CarBrandLogic(carbrandrepo.Object);
            rentlogic = new RentLogic(rentsrepo.Object);

        }

        [Test]
        public void CreateCarTest()
        {
            var car = new Cars()
            {
                CarsId = 1,
                CarBrandId = 1,
                Type = "BMW",
                LicensePlateNumber = "HFG-435",
                Year = 2004,
                PerformanceInHP = 310

            };
            logic.Create(car);
            mockCarRepo.Verify(r => r.Create(car), Times.Once);


        }


    }
}
