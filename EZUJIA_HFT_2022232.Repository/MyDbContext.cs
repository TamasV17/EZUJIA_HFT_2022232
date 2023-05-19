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

        public DbSet<Employees> employees { get; set; }

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


            modelBuilder.Entity<Rent>().HasOne(t => t.CarId).WithOne(t => t.Owner);

            modelBuilder.Entity<Rent>().HasOne(t => t.Employees).WithMany(t => t.RentCar).HasForeignKey(t => t.EmployeesID);


           

            modelBuilder.Entity<Cars>().HasData(new Cars[]
            {
                //25
                new Cars("BMW,1,E60,HFG-453,2004,310"),
                new Cars("Mercedes-Benz,2,C-Class,ABC-789,2010,200"),
                new Cars("Audi,3,A4,XYZ-123,2015,180"),
                new Cars("Ford,4,Focus,PQR-567,2018,120"),
                new Cars("Toyota,5,Camry,LMO-901,2019,190"),
                new Cars("Honda,6,Accord,DEF-321,2016,150"),
                new Cars("Volkswagen,7,Golf,JKL-654,2014,110"),
                new Cars("Chevrolet,8,Cruze,GHI-987,2017,140"),
                new Cars("Hyundai,9,Sonata,MNO-246,2013,160"),
                new Cars("Volvo,10,S60,RST-789,2020,250"),
                new Cars("BMW,11,E90,UVW-543,2012,280"),
                new Cars("Mercedes-Benz,12,E-Class,DEF-123,2017,220"),
                new Cars("Audi,13,A6,XYZ-987,2016,200"),
                new Cars("Ford,14,Fiesta,PQR-654,2015,100"),
                new Cars("Toyota,15,Corolla,ABC-321,2019,150"),
                new Cars("Honda,16,Civic,JKL-789,2018,130"),
                new Cars("Volkswagen,17,Passat,MNO-432,2014,170"),
                new Cars("Volkswagen,18,Golf,PBO-432,2015,120"),
                new Cars("Chevrolet,19,Impala,GHI-210,2013,190"),
                new Cars("Hyundai,20,Elantra,LMO-765,2012,140"),
                new Cars("Volvo,21,V60,RST-876,2021,300"), //transport cars
                new Cars("Volvo,22,V60,RST-876,2021,300"),
                new Cars("Volvo,23,V60,RST-876,2021,300"),
                new Cars("Volvo,24,V60,RST-876,2021,300"),
                new Cars("Volvo,25,V60,RST-876,2021,300"),

            });
            

            modelBuilder.Entity<Employees>().HasData(new Employees[]
            {

            });

            modelBuilder.Entity<Rent>().HasData(new Rent[]
            {

            });


        }




    }
}
