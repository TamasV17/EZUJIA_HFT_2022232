using EZUJIA_HFT_2022232.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Repository
{
    public class MyDbContext : DbContext
    {
        public DbSet<Cars> cars { get; set; }

        public DbSet<CarBrand> carbrand { get; set; }

        public DbSet<Rent> rents { get; set; }

        public MyDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("data").UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Cars>(t => t.HasMany(t => t.AllRents).WithOne(t => t.cars).HasForeignKey(t => t.CarsId));
            modelBuilder.Entity<Cars>(t => t.HasOne(t => t.CarBrand).WithMany(t => t.Cars).HasForeignKey(t => t.CarBrandId));




            modelBuilder.Entity<Cars>().HasData(new Cars[]
            {
                //25
                new Cars("1,1,E60,HFG-453,2004,310"),
                new Cars("2,2,C-Class,ABC-789,2010,200"),
                new Cars("12,3,A4,XYZ-123,2015,180"),
                new Cars("3,4,Focus,PQR-567,2018,120"),
                new Cars("10,5,Camry,LMO-901,2019,190"),
                new Cars("10,6,Accord,DEF-321,2016,150"),
                new Cars("4,7,Golf,JKL-654,2014,110"),
                new Cars("7,8,Cruze,GHI-987,2017,140"),
                new Cars("6,9,Sonata,MNO-246,2013,160"),
                new Cars("2,10,S60,RST-789,2020,250"),
                new Cars("1,11,E90,UVW-543,2012,280"),
                new Cars("2,12,E-Class,DEF-123,2017,220"),
                new Cars("12,13,A6,XYZ-987,2016,200"),
                new Cars("3,14,Fiesta,PQR-654,2015,100"),
                new Cars("7,15,Corolla,ABC-321,2019,150"),
                new Cars("9,16,Civic,JKL-789,2018,130"),
                new Cars("4,17,Passat,MNO-432,2014,170"),
                new Cars("4,18,Golf,PBO-432,2015,120"),
                new Cars("7,19,Impala,GHI-210,2013,190"),
                new Cars("6,20,Elantra,LMO-765,2012,140"),
                new Cars("5,21,V60,RST-876,2021,300"), //transport cars
                new Cars("5,22,V60,RST-876,2021,300"),
                new Cars("5,23,V60,RST-876,2021,300"),
                new Cars("5,24,V60,RST-876,2021,300"),
                new Cars("5,25,V60,RST-876,2021,300"),

            });
                       

            modelBuilder.Entity<Rent>().HasData(new Rent[]
            {
                new Rent("1,2020-9-11,Lily Parker,1"),
                new Rent("3,2012-10-11,Maxwell Foster,2"),
                new Rent("11,2002-01-11,Ella Clark,3"),
                new Rent("5,2015-04-25,James Martinez,10"),
                new Rent("4,2016-04-25,James Martinez,11")
            });

            modelBuilder.Entity<CarBrand>().HasData(new CarBrand[]
            {
                new CarBrand("1,BMW"),
                new CarBrand("2,Mercedes-Benz"),
                new CarBrand("3,Ford"),
                new CarBrand("4,Volkswagen"),
                new CarBrand("5,Volvo"),
                new CarBrand("6,Hyundai"),
                new CarBrand("7,Chevrolet,"),
                new CarBrand("9,Lada"),
                new CarBrand("10,Toyota"),
                new CarBrand("11,Honda"),
                new CarBrand("12,Audi"),

        });

        }




    }
}
