using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDbContext ctx = new MyDbContext();
            CarsRepository repo = new CarsRepository(ctx);
           
            Console.ReadLine();
        }
    }
}
