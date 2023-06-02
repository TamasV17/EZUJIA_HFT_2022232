﻿using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using System;
using ConsoleTools;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZUJIA_HFT_2022232.Client;
using EZUJIA_HFT_2022232.Logic;
using static EZUJIA_HFT_2022232.Logic.RentLogic;
using static EZUJIA_HFT_2022232.Logic.CarsLogic;

namespace EZUJIA_HFT_2022232
{
    internal class Program
    {
        static RestService rest;
       

        static void Create(string entity)
        {
            if (entity == "Car")
            {
                Console.WriteLine("Enter the CarId: ");
                int carid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the CarBrandId: ");
                int carbrandid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the LicensePlateNumber: ");
                string licenseplatenumberstring = Console.ReadLine();
                Console.WriteLine("Enter the HorsePower: ");
                int horsepower = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Car Type: ");
                string cartype = Console.ReadLine();
                Console.WriteLine("Enter the year: ");
                int year = int.Parse(Console.ReadLine());
                rest.Post(new Cars()
                {
                    CarsId = carid,
                    CarBrandId = carbrandid,
                    LicensePlateNumber = licenseplatenumberstring,
                    PerformanceInHP = horsepower,
                    Type = cartype,
                    Year = year
                }, "Cars");


            }
            else if (entity == "CarBrand")
            {
                Console.WriteLine("Enter the CarBrandId: ");
                int carbrandid = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the CarBrand Name: ");
                string name = Console.ReadLine();
                rest.Post(new CarBrand()
                {
                    CarBrandID = carbrandid,
                    Name = name
                }, "carbrand");
            }
            else if (entity == "Rents")
            {
                Console.WriteLine("Enter the RentID: ");
                int rentId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the RentTime: ");
                string renttime = Console.ReadLine();
                Console.WriteLine("Enter the Owner Name: ");
                string ownername = Console.ReadLine();
                Console.WriteLine("Enter the CarId: ");
                int carid = int.Parse(Console.ReadLine());
                rest.Post(new Rent()
                {
                    RentId = rentId,
                    RentTime = renttime,
                    OwnerName = ownername,
                    CarsId = carid
                }, "rent");

            }
        }
        static void List(string entity)
        {
            if (entity == "Car")
            {
                List<Cars> cars = rest.Get<Cars>("cars");
                foreach (var item in cars)
                {
                    Console.WriteLine($" {item.CarsId} {item.CarBrandId} {item.LicensePlateNumber} {item.PerformanceInHP} {item.Type} {item.Year}");

                }

                Console.WriteLine("");
                Console.WriteLine("Press ENTER to return!");
                Console.ReadKey();

            }
            else if (entity == "CarBrand")
            {
                List<CarBrand> carbrand = rest.Get<CarBrand>("carbrand");
                foreach (var item in carbrand)
                {
                    Console.WriteLine($"{item.CarBrandID} {item.Name}");

                }
            }

            else if (entity == "Rents")
            {
                List<Rent> rents = rest.Get<Rent>("rents");
                foreach (var item in rents)
                {
                    Console.WriteLine($"{item.RentId} {item.RentTime} {item.OwnerName} {item.CarsId}");

                }
            }
            else if (entity == "Noncrud")
            {
                Console.WriteLine("All method: ");
                Console.WriteLine("AvgCarHP: ");
                List<AvarageCarHP> avgcar = rest.Get<AvarageCarHP>("CrudMethod/AvarageHPperCar");
                foreach (var item in avgcar)
                {
                    Console.WriteLine($"{item.name} - {item.avarage}");
                }
                Console.WriteLine();
                Console.WriteLine("MostFamousCar");
                List<TheMostFamous> mostfamouscar = rest.Get<TheMostFamous>("CrudMethod/TheMostFamousBrand");
                
                foreach (var item in mostfamouscar)
                {
                    Console.WriteLine($"1. {item.name} - {item.count}");
                }



                Console.WriteLine();
                Console.WriteLine("RentsCars: ");
                List<string> allcar = rest.Get<string>("CrudMethod/TheRentsCarBrand");
                foreach (var item in allcar)
                {
                    Console.WriteLine($"{item}");
                }

                Console.WriteLine();
                Console.WriteLine("RentsCars: ");
                List<BrandperRentsCount> brandperrents = rest.Get<BrandperRentsCount>("CrudMethod/BrandperRentsCountsMethod");
                foreach (var item in brandperrents)
                {
                    Console.WriteLine($"{item.brand} - {item.count}");
                }
                Console.WriteLine();
                Console.WriteLine("YearStatics: ");
                List<YearInfo> yearstaticslist = rest.Get<YearInfo>("CrudMethod/YearStatistics");
                foreach (var item in yearstaticslist)
                {
                    Console.WriteLine($"{item.Year} - {item.Count}");
                }

                Console.ReadLine();
            }
        }
        static void Update(string entity)
        {
                if (entity == "Cars")
                {
                    Console.WriteLine("Enter the Car's Id: ");
                    int id = int.Parse(Console.ReadLine());
                    Cars one = rest.Get<Cars>(id, "cars");

                    Console.WriteLine($"Enter the new id[old: {one.CarsId}]");
                    int carsid = int.Parse(Console.ReadLine());
                    one.CarsId = carsid;

                    Console.WriteLine($"Enter the new CarBrandId[old: {one.CarBrandId}]: ");
                    int carbrandid = int.Parse(Console.ReadLine());
                    one.CarBrandId = carbrandid;

                    Console.WriteLine($"Enter the new LicensePlateNumber[old: {one.LicensePlateNumber}]: ");
                    string licenseplatenumberstring = Console.ReadLine();
                    one.LicensePlateNumber = licenseplatenumberstring;


                    Console.WriteLine($"Enter the new  HorsePower[old: {one.PerformanceInHP}]: ");
                    int horsepower = int.Parse(Console.ReadLine());
                    one.PerformanceInHP = horsepower;

                    Console.WriteLine($"Enter the new Car Type[old: {one.Type}]: ");
                    string cartype = Console.ReadLine();
                    one.Type = cartype;

                    Console.WriteLine($"Enter the new car  year[old: {one.Year}]: ");
                    int year = int.Parse(Console.ReadLine());
                    one.Year = year;

                    rest.Put(one, "cars");
                }
                else if (entity == "CarBrand")
                {
                    Console.WriteLine("Enter the CarBrand's Id: ");
                    int id = int.Parse(Console.ReadLine());
                    CarBrand one = rest.Get<CarBrand>(id, "carbrand");

                    Console.WriteLine($"Enter the new CarBrandId[old: {one.CarBrandID}]: ");
                    int carbrandid = int.Parse(Console.ReadLine());
                    one.CarBrandID = carbrandid;

                    Console.WriteLine($"Enter the new CarBrand Name[old: {one.Name}]: ");
                    string name = Console.ReadLine();
                    one.Name = name;

                    rest.Put(one, "carbrand");


                }
                else if (entity == "Rents")
                {
                    Console.WriteLine("Enter the Rent's Id: ");
                    int id = int.Parse(Console.ReadLine());
                    Rent one = rest.Get<Rent>(id, "rents");

                    Console.WriteLine($"Enter the new RentID[old: {one.RentId}]: ");
                    int rentId = int.Parse(Console.ReadLine());
                    one.RentId = rentId;


                    Console.WriteLine($"Enter the new  RentTime[old: {one.RentTime}]: ");
                    string renttime = Console.ReadLine();
                    one.RentTime = renttime;


                    Console.WriteLine($"Enter the new Owner Name[old: {one.OwnerName}]: ");
                    string ownername = Console.ReadLine();
                    one.OwnerName = ownername;


                    Console.WriteLine($"Enter the new CarId[old: {one.CarsId}]: ");
                    int carid = int.Parse(Console.ReadLine());
                    one.CarsId = carid;

                    rest.Put(one, "rent");


                }
        }

        static void Delete(string entity)
        {
                if (entity == "Car")
                {
                    Console.WriteLine("Enter the Car's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "cars");
                }
                else if (entity == "CarBrand")
                {
                    Console.WriteLine("Enter the CarBrand's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "carbrand");
                }
                else if (entity == "Rents")
                {
                    Console.WriteLine("Enter the Rent's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "rent");
                }
        }

        static void Main(string[] args)
        {
            //MyDbContext db = new MyDbContext();
            //CarsRepository carsRepository = new CarsRepository(db);
            //CarsLogic carsLogic = new CarsLogic(carsRepository);
            //IEnumerable<Cars> cars = carsLogic.ReadAll();
            //CarBrandRepository carBrandRepository = new CarBrandRepository(db);
            //CarBrandLogic carBrandLogic = new CarBrandLogic(carBrandRepository);
            //IEnumerable<CarBrand> carBrands = carBrandRepository.ReadAll();
            //RentsRepository rentsRepository = new RentsRepository(db);
            //RentLogic rentLogic = new RentLogic(rentsRepository);
            //IEnumerable<Rent> rents = rentLogic.ReadAll();
            
            rest = new RestService("http://localhost:63234/", "Cars");

            Console.WriteLine("hello world");


            var carSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Car"))
                .Add("Create", () => Create("Car"))
                .Add("Delete", () => Delete("Car"))
                .Add("Update", () => Update("Car"))
                .Add("Exit", ConsoleMenu.Close);

            var carbrandSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("CarBrand"))
                .Add("Create", () => Create("CarBrand"))
                .Add("Delete", () => Delete("CarBrand"))
                .Add("Update", () => Update("CarBrand"))
                .Add("Exit", ConsoleMenu.Close);

            var rentsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Rents"))
                .Add("Create", () => Create("Rents"))
                .Add("Delete", () => Delete("Rents"))
                .Add("Update", () => Update("Rents"))
                .Add("Exit", ConsoleMenu.Close);

            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("All Noncrud method", () => List("Noncrud"));

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Car", () => carSubMenu.Show())
                .Add("CarBrand", () => carbrandSubMenu.Show())
                .Add("Rents", () => rentsSubMenu.Show())
                .Add("NonCrudmethod", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);


            menu.Show();

        }
    }
}

    
    
