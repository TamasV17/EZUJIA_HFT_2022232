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
        //Mock<IRepository<Rents>> rentsrepo;


        [SetUp]
        public void Init()
        {
            mockCarRepo = new Mock<IRepository<Cars>>();
            mockCarRepo.Setup(m => m.ReadAll()).Returns(new List<Cars>()
            {
                new Cars("11,1,Civic,HFG-434,2004,310"),
                new Cars("5,2,Niva,YYY-444,1967,674")
            }.AsQueryable());

            carbrandrepo = new Mock<IRepository<CarBrand>>();
            carbrandrepo.Setup(m => m.ReadAll()).Returns(new List<CarBrand>()
            {
                new CarBrand("11,Honda"),
                new CarBrand("5,Volvo")
            }.AsQueryable());

            //rentsrepo = new Mock<IRepository<Rents>>();
            //rentsrepo.Setup(m => m.ReadAll()).Returns(new List<Rents>()
            //{
            //    new Rent("11,2002-01-11,Ella Clark,3"),
            //    new Rent("5,2015-04-25,James Martinez,10"),
            //}.AsQueryable());

            logic = new CarsLogic(mockCarRepo.Object);
            carbrandlogic = new CarBrandLogic(carbrandrepo.Object);
            //rentlogic = new RentsLogic(rentsrepo.Object);

        }

        [Test]
        public void CreateCarTest()
        {
            var car = new Cars()
            {
                Year = 2000,
                CarBrandId = 1,
                CarsId = 3,
                PerformanceInHP = 500,
                Type = "X6",
                LicensePlateNumber = "ABC-123"


            };
            logic.Create(car);
            mockCarRepo.Verify(r => r.Create(car), Times.Once);


        }

        [Test]
        public void CreateCarBrandTest()
        {
            var carbrand = new CarBrand()
            {
                Name = "Honda",
                CarBrandID = 3


            };
            carbrandlogic.Create(carbrand);
            carbrandrepo.Verify(r => r.Create(carbrand), Times.Once);


        }




    }
}
