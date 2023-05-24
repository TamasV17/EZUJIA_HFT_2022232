using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EZUJIA_HFT_2022232.Logic.CarsLogic;

namespace EZUJIA_HFT_2022232.Test
{
    [TestFixture]
    class CarTesterClass
    {
        CarsLogic logic;
        Mock<IRepository<Cars>> mockCarRepo;
        List<Cars> carlist;

        [SetUp]
        public void Init()
        {
            carlist = new List<Cars>()
            {
                new Cars()
                {
                    CarsId = 1,
                    CarBrandId = 1,
                    Year = 2001,
                    Type = "Supra",
                    LicensePlateNumber = "ABC-121",
                    PerformanceInHP = 450,
                    CarBrand = new CarBrand()
                    {
                        CarBrandID = 1,
                        Name = "Toyota"
                    },
                    AllRents = new List<Rent>()
                    {
                        new Rent()
                        {
                            RentId = 1,
                            CarsId = 1,
                            OwnerName = "Paul Walker",
                            RentTime = "1976-04-23"
                        }
                    }
                }
            };
            mockCarRepo = new Mock<IRepository<Cars>>();
            mockCarRepo.Setup(x => x.ReadAll()).Returns(() => carlist.AsQueryable());
            logic = new CarsLogic(mockCarRepo.Object);
        }

        [Test]
        public void AvarageHPperCarTest()
        {
            var actual = logic.AvarageHPperCar().ToList();
            var excepted = new List<AvarageCarHP>
            {
                new AvarageCarHP("Supra",450)
            };
            Assert.AreEqual(excepted, actual);
        }
        [Test]
        public void TheMostFamousBrand()
        {
            var actual = logic.TheMostFamousBrand().ToList();
            var excepted = new List<TheMostFamous>
            {
                new TheMostFamous("Honda",1)
            };
            Assert.AreEqual(excepted, actual);

        }
        [Test]
        public void NotEqualTest()
        {
            var actual = logic.ReadAll().ToList();
            var excepted = new List<Cars>()
            {
               new Cars()
               {
                CarsId = 2,
                CarBrandId = 1,
                Year = 2001,
                Type = "Civic",
                LicensePlateNumber = "ABC-121",
                PerformanceInHP = 450,
                CarBrand = new CarBrand()
                {
                    CarBrandID = 1,
                    Name = "Honda"
                },
                AllRents = new List<Rent>()
                    {
                        new Rent()
                        {
                            RentId = 1,
                            CarsId = 1,
                            OwnerName = "Paul Walker",
                            RentTime = "1978-03-14"
                        }
                    }
               }
            };

            Assert.AreNotEqual(excepted, actual);
        }
    }
}
