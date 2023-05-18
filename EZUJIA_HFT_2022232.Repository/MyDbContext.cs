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


            modelBuilder.Entity<Rent>().HasOne(t => t.CarId).WithMany(t => t.Owner).HasForeignKey(t => t.RentcarId);

            modelBuilder.Entity<Rent>().HasOne(t => t.Employees).WithMany(t => t.RentCar).HasForeignKey(t => t.EmployeesID);





            modelBuilder.Entity<Cars>().HasData(new Cars[]
            {

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
