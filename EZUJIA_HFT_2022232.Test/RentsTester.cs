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
using static EZUJIA_HFT_2022232.Logic.RentLogic;

namespace EZUJIA_HFT_2022232.Test
{
    [TestFixture]
    class RentsTesterClass
    {
        RentLogic logic;
        Mock<IRepository<Rent>> mockRentsRepo;
        List<Rent> rentslist;

        [SetUp]
        public void Init()
        {
            rentslist = new List<Rent>()
            {
                new Rent()
                {
                    RentId = 1,
                    OwnerName = "Kiss Attila",
                    RentTime = "2001-06-22",
                    CarsId = 1,
                    cars = new Cars()
                    {
                        CarBrandId = 1,
                        CarsId = 1,
                        LicensePlateNumber = "ABC-123",
                        PerformanceInHP = 400,
                        Type = "AMG",
                        Year = 2010,
                        CarBrand = new CarBrand()
                        {
                            CarBrandID = 1,
                            Name = "Mercedes-Benz"
                        }
                    }
                }
            };
            mockRentsRepo = new Mock<IRepository<Rent>>();
            mockRentsRepo.Setup(x => x.ReadAll()).Returns(() => rentslist.AsQueryable());
            logic = new RentLogic(mockRentsRepo.Object);
        }

        [Test]
        public void TheRentsCarBrandTest()
        {
            var actual = logic.TheRentsCarBrand().ToList();
            var excepted = new List<string>
            {
                "Mercedes-Benz"
            };
            Assert.AreEqual(excepted, actual);
        }

        [Test]
        public void BrandperRentsCountsMethod()
        {
            var actual = logic.BrandperRentsCountsMethod().ToList();
            var excepted = new List<BrandperRentsCount>
            {
                new BrandperRentsCount()
                {
                    brand = "Mercedes-Benz",
                    count = 1
                }
            };
            Assert.AreEqual(excepted, actual);
        }

        [Test]
        public void NotEqualsTest()
        {
            var actual = logic.ReadAll().ToList();
            var excepted = new List<Rent>
            {
                 new Rent()
                {
                    RentId = 3,
                    OwnerName = "Paul Walker",
                    RentTime = "2001-06-22",
                    CarsId = 1,
                    cars = new Cars()
                    {
                        CarBrandId = 1,
                        CarsId = 1,
                        LicensePlateNumber = "ABC-123",
                        PerformanceInHP = 400,
                        Type = "Supra",
                        Year = 2010,
                        CarBrand = new CarBrand()
                        {
                            CarBrandID = 1,
                            Name = "Toyota"
                        }
                    }
                }
            };
            Assert.AreNotEqual(excepted, actual);
        }
    }
}
