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

namespace EZUJIA_HFT_2022232.Test
{
    [TestFixture]
    class CarBrandTester
    {
        CarBrandLogic logic;
        Mock<IRepository<CarBrand>> mockCarBrandrepo;
        List<CarBrand> carbrandlist;

        [SetUp]
        public void Init()
        {

            carbrandlist = new List<CarBrand>
            {
                new CarBrand()
                {
                    Name = "Toyota",
                    CarBrandID = 1,
                    Cars = new List<Cars>()
                    {
                       new Cars()
                       {
                       CarBrandId = 1,
                       CarsId = 1,
                       Type = "Supra",
                       LicensePlateNumber = "ABC-123",
                       PerformanceInHP = 500,
                       Year = 2011,
                       AllRents = new List<Rent>()
                       {
                           new Rent()
                           {
                               CarsId = 1,
                               RentId = 1,
                               RentTime = "2006-11-21",
                               OwnerName = "Paul Walker"

                           }
                       }

                       }
                    }

                }
            };
            mockCarBrandrepo = new Mock<IRepository<CarBrand>>();
            mockCarBrandrepo.Setup(t => t.ReadAll()).Returns(() => carbrandlist.AsQueryable());
            logic = new CarBrandLogic(mockCarBrandrepo.Object);


        }

        [Test]
        public void NotEqualTest()
        {
            var actual = logic.ReadAll().ToList();
            var excepted = new List<CarBrand>
            {
                new CarBrand()
                {
                    Name = "Supra",
                    CarBrandID = 2,
                    Cars = new List<Cars>()
                    {
                       new Cars()
                       {
                       CarBrandId = 1,
                       CarsId = 1,
                       Type = "Toyota",
                       LicensePlateNumber = "ABC-123",
                       PerformanceInHP = 500,
                       Year = 2011,
                       AllRents = new List<Rent>()
                       {
                           new Rent()
                           {
                               CarsId = 1,
                               RentId = 1,
                               RentTime = "2002-04-12",
                               OwnerName = "Paul Walker"

                           }
                       }

                       }
                    }

                }
            };
            Assert.AreNotEqual(excepted, actual);
        }


    }
}
