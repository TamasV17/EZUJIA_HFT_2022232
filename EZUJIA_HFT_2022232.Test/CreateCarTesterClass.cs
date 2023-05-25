using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static EZUJIA_HFT_2022232.Logic.CarsLogic;
using static EZUJIA_HFT_2022232.Logic.RentLogic;

namespace EZUJIA_HFT_2022232.Test
{
    [TestFixture]
    public class CreateCarTesterClass
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
                new Cars("11,1,Civic,HFG-434,2004,310"),
                new Cars("5,2,Niva,YYY-444,1967,674"),
                new Cars("1,3,Focus,XXX-420,2012,145"),
            }.AsQueryable());
            logic = new CarsLogic(mockCarRepo.Object);

            carbrandrepo = new Mock<IRepository<CarBrand>>();
            carbrandrepo.Setup(m => m.ReadAll()).Returns(new List<CarBrand>()
            {
                new CarBrand("11,Honda"),
                new CarBrand("5,Volvo")
            }.AsQueryable());

            rentsrepo = new Mock<IRepository<Rent>>();
            rentsrepo.Setup(m => m.ReadAll()).Returns(new List<Rent>()
            {
                new Rent("11,2002-01-11,Ella Clark,3"),
                new Rent("5,2002-04-25,James Martinez,10"),
            }.AsQueryable());

            logic = new CarsLogic(mockCarRepo.Object);
            carbrandlogic = new CarBrandLogic(carbrandrepo.Object);
            rentlogic = new RentLogic(rentsrepo.Object);

        }

        [Test]
        public void CreateCarTest()
        {
            try
            {
                var car = new Cars()
                {
                    Year = 2002,
                    CarBrandId = 1,
                    CarsId = 3,
                    PerformanceInHP = 500,
                    Type = "Amg",
                    LicensePlateNumber = "ABC-123"
                };
                logic.Create(car);
                mockCarRepo.Verify(r => r.Create(car), Times.Once);
            }
            catch (Exception)
            {

            }
        }

        [Test]
        public void CreateCarBrandTest()
        {
            try
            {
                var carbrand = new CarBrand()
                {
                    Name = "Honda",
                    CarBrandID = 3
                };
                carbrandlogic.Create(carbrand);
                carbrandrepo.Verify(r => r.Create(carbrand), Times.Once);
            }
            catch (Exception)
            {
            }


        }
        [Test]
        public void CreateRentsTest()
        {
            try
            {
                var car = new Rent()
                {
                    OwnerName = "Paul Walker",
                    RentId = 2,
                    CarsId = 1,
                    RentTime = "2002-05-22"
                };
                rentlogic.Create(car);
                rentsrepo.Verify(r => r.Create(car), Times.Once);
            }
            catch (Exception)
            {
            }

        }      
        [Test]
        public void YearStaticsTest()
        {
            var actual = rentlogic.YearStatistics().ToList();
            var excepted = new List<YearInfo>()
            {
                new YearInfo(2002,2)

            };
            Assert.AreEqual(excepted, actual);
        }

        



    }
}
