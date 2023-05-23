using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using System;
using ConsoleTools;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZUJIA_HFT_2022232.Client;
using EZUJIA_HFT_2022232.Logic;

namespace EZUJIA_HFT_2022232
{
    class Program
    {

        static CarsLogic carlogic;
        static CarBrandLogic carbrandlogic;
        static RentLogic rentslogic;
        static RestService rest;

        static void Create(string entity)
        {                      
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Car")
            {
                //List<Cars> cars = rest.Get<Cars>("cars");
                //foreach (var item in cars)
                //{
                //    Console.WriteLine(item.CarBrandID);
                //}




                var items = carlogic.ReadAll();
                var items2 = carlogic.TheMostFamousBrand();
                var item3 = carlogic.AvarageHPperCar();
                Console.WriteLine("Id " + " \t" + "Name");
                //foreach (var item in items)
                //{
                //    Console.WriteLine(item.CarBrand.Name);
                //}
                Console.WriteLine(items2);
                Console.WriteLine();
                foreach (var item in item3)
                {
                    Console.WriteLine(item);
                }


            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
                    Console.WriteLine(entity + " update");
                    Console.ReadLine();
        }
        static void Delete(string entity)
        {
                    Console.WriteLine(entity + " delete");
                    Console.ReadLine();
        }
        static void Main(string[] args)
        {
            var ctx = new MyDbContext();
            var carrepo = new CarsRepository(ctx);
            var carbrandrepo = new CarBrandRepository(ctx);
            var rentsrepo = new RentsRepository(ctx);


            carlogic = new CarsLogic(carrepo);
            carbrandlogic = new CarBrandLogic(carbrandrepo);
            rentslogic = new RentLogic(rentsrepo);
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






                    var menu = new ConsoleMenu(args, level: 0)
                        .Add("Car", () => carSubMenu.Show())
                        .Add("CarBrand", () => carbrandSubMenu.Show())
                        .Add("Rents", () => rentsSubMenu.Show())

                        .Add("Exit", ConsoleMenu.Close);

                    menu.Show();


                    Console.ReadLine();

         }
     }
}
    
    
