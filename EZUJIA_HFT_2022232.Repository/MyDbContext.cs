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
            

            modelBuilder.Entity<Employees>().HasData(new Employees[]
            {
                //100workers
                //new Employees("John Smith,1,Management,+1 123-456-7890,1965-08-15"),
                //new Employees("Emily Johnson,2,HR,+1 234-567-8901,1982-03-22"),
                //new Employees("Michael Williams,3,Finance,+1 345-678-9012,1979-11-10"),
                //new Employees("Emma Jones,4,Marketing,+1 456-789-0123,1991-06-27"),
                //new Employees("Daniel Brown,5,IT,+1 567-890-1234,1987-02-04"),
                //new Employees("Olivia Davis,6,Sales,+1 678-901-2345,1984-09-19"),
                //new Employees("Matthew Miller,7,Operations,+1 789-012-3456,1977-04-12"),
                //new Employees("Sophia Wilson,8,Research,+1 890-123-4567,1995-01-31"),
                //new Employees("William Taylor,9,Engineering,+1 901-234-5678,1980-12-08"),
                //new Employees("Ava Anderson,10,Product Development,+1 012-345-6789,1993-07-23"),
                //new Employees("James Martinez,11,Management,+1 123-456-7890,1974-09-03"),
                //new Employees("Isabella Davis,12,HR,+1 234-567-8901,1988-06-18"),
                //new Employees("Ethan Clark,13,Finance,+1 345-678-9012,1972-03-07"),
                //new Employees("Mia Thomas,14,Marketing,+1 456-789-0123,1990-10-24"),
                //new Employees("Alexander Hall,15,IT,+1 567-890-1234,1986-05-09"),
                //new Employees("Charlotte White,16,Sales,+1 678-901-2345,1981-01-26"),
                //new Employees("Daniel Johnson,17,Operations,+1 789-012-3456,1975-08-11"),
                //new Employees("Amelia Davis,18,Research,+1 890-123-4567,1998-05-28"),
                //new Employees("Joseph Brown,19,Engineering,+1 901-234-5678,1976-02-14"),
                //new Employees("Harper Wilson,20,Product Development,+1 012-345-6789,1999-09-30"),
                //new Employees("Benjamin Thompson,21,Management,+1 123-456-7890,1983-12-17"),
                //new Employees("Ella Miller,22,HR,+1 234-567-8901,1997-09-02"),
                //new Employees("Christopher Davis,23,Finance,+1 345-678-9012,1971-05-19"),
                //new Employees("Lily Clark,24,Marketing,+1 456-789-0123,1989-02-05"),
                //new Employees("Grace Adams,26,Sales,+1 567-890-1234,1985-07-22"),
                //new Employees("Samuel Hill,27,Operations,+1 678-901-2345,1979-04-09"),
                //new Employees("Victoria Evans,28,Research,+1 789-012-3456,1992-11-26"),
                //new Employees("David Baker,29,Engineering,+1 901-234-5678,1987-08-13"),
                //new Employees("Scarlett Collins,30,Product Development,+1 012-345-6789,1996-03-30"),
                //new Employees("Luke Turner,31,Management,+1 123-456-7890,1978-01-16"),
                //new Employees("Chloe Mitchell,32,HR,+1 234-567-8901,1993-10-03"),
                //new Employees("Henry Stewart,33,Finance,+1 345-678-9012,1976-06-20"),
                //new Employees("Zoe Murphy,34,Marketing,+1 456-789-0123,1991-03-07"),
                //new Employees("Gabriel Martinez,35,IT,+1 567-890-1234,1984-11-24"),
                //new Employees("Penelope Hill,36,Sales,+1 678-901-2345,1977-08-10"),
                //new Employees("Jack Adams,37,Operations,+1 789-012-3456,1990-05-27"),
                //new Employees("Lillian Evans,38,Research,+1 890-123-4567,1983-02-12"),
                //new Employees("Owen Baker,39,Engineering,+1 901-234-5678,1975-09-29"),
                //new Employees("Aria Collins,40,Product Development,+1 012-345-6789,1988-07-15"),
                //new Employees("Matthew Foster,41,Management,+1 123-456-7890,1973-05-02"),
                //new Employees("Sofia Myers,42,HR,+1 234-567-8901,1989-12-19"),
                //new Employees("Wyatt Murphy,43,Finance,+1 345-678-9012,1974-09-05"),
                //new Employees("Avery Sanders,44,Marketing,+1 456-789-0123,1996-06-22"),
                //new Employees("Jackson Watson,45,IT,+1 567-890-1234,1981-03-09"),
                //new Employees("Evelyn Scott,46,Sales,+1 678-901-2345,1976-11-26"),
                //new Employees("Sebastian Parker,47,Operations,+1 789-012-3456,1994-09-13"),
                //new Employees("Scarlett Wright,48,Research,+1 890-123-4567,1987-06-30"),
                //new Employees("Carter Hughes,49,Engineering,+1 901-234-5678,1972-03-17"),
                //new Employees("Maxwell Foster,51,Management,+1 123-456-7890,1984-09-03"),
                //new Employees("Nora Myers,52,HR,+1 234-567-8901,1998-06-18"),
                //new Employees("Julian Murphy,53,Finance,+1 345-678-9012,1972-03-07"),
                //new Employees("Avery Thompson,54,Marketing,+1 456-789-0123,1990-10-24"),
                //new Employees("Samuel Collins,55,IT,+1 567-890-1234,1986-05-09"),
                //new Employees("Emma Davis,56,Sales,+1 678-901-2345,1981-01-26"),
                //new Employees("Liam Johnson,57,Operations,+1 789-012-3456,1975-08-11"),
                //new Employees("Ella Wilson,58,Research,+1 890-123-4567,1998-05-28"),
                //new Employees("Jacob Brown,59,Engineering,+1 901-234-5678,1976-02-14"),
                //new Employees("Mia Turner,60,Product Development,+1 012-345-6789,1999-09-30"),
                //new Employees("Ethan Martinez,61,Management,+1 123-456-7890,1974-09-03"),
                //new Employees("Ava Davis,62,HR,+1 234-567-8901,1988-06-18"),
                //new Employees("Oliver Clark,63,Finance,+1 345-678-9012,1972-03-07"),
                //new Employees("Sophia Thomas,64,Marketing,+1 456-789-0123,1990-10-24"),
                //new Employees("Logan White,65,IT,+1 567-890-1234,1986-05-09"),
                //new Employees("Isabella Johnson,66,Sales,+1 678-901-2345,1981-01-26"),
                //new Employees("Mason Adams,67,Operations,+1 789-012-3456,1975-08-11"),
                //new Employees("Harper Evans,68,Research,+1 890-123-4567,1998-05-28"),
                //new Employees("Lucas Baker,69,Engineering,+1 901-234-5678,1976-02-14"),
                //new Employees("Aria Collins,70,Product Development,+1 012-345-6789,1999-09-30"),
                //new Employees("Henry Thompson,71,Management,+1 123-456-7890,1983-12-17"),
                //new Employees("Grace Miller,72,HR,+1 234-567-8901,1997-09-02"),
                //new Employees("Leo Davis,73,Finance,+1 345-678-9012,1971-05-19"),
                //new Employees("Scarlett Clark,74,Marketing,+1 456-789-0123,1989-02-05"),
                //new Employees("Wyatt Wilson,75,IT,+1 567-890-1234,1981-03-09"),
                //new Employees("Lily Parker,76,Sales,+1 678-901-2345,1976-11-26"),
                //new Employees("Jackson Adams,77,Operations,+1 789-012-3456,1994-09-13"),
                //new Employees("Evelyn Evans,78,Research,+1 890-123-4567,1987-06-30"),
                //new Employees("Owen Baker,79,Engineering,+1 901-234-5678,1972-03-17"),
                //new Employees("Amelia Foster,80,Product Development,+1 012-345-6789,1988-07-15"),
                //new Employees("Benjamin Thompson,81,Management,+1 123-456-7890,1983-12-17"),
                //new Employees("Ella Miller,82,HR,+1 234-567-8901,1997-09-02"),
                //new Employees("Christopher Davis,83,Finance,+1 345-678-9012,1971-05-19"),
                //new Employees("Lily Clark,84,Marketing,+1 456-789-0123,1989-02-05"),
                //new Employees("Charlotte White,86,Sales,+1 567-890-1234,1985-07-22"),
                //new Employees("Daniel Johnson,87,Operations,+1 678-901-2345,1979-04-09"),
                //new Employees("Amelia Davis,88,Research,+1 789-012-3456,1992-11-26"),
                //new Employees("Joseph Brown,89,Engineering,+1 901-234-5678,1987-08-13"),
                //new Employees("Harper Collins,90,Product Development,+1 012-345-6789,1996-03-30"),
                //new Employees("William Thompson,91,Management,+1 123-456-7890,1978-01-16"),
                //new Employees("Ava Mitchell,92,HR,+1 234-567-8901,1993-10-03"),
                //new Employees("Oliver Stewart,93,Finance,+1 345-678-9012,1976-06-20"),
                //new Employees("Mia Murphy,94,Marketing,+1 456-789-0123,1991-03-07"),
                //new Employees("James Martinez,95,IT,+1 567-890-1234,1984-11-24"),
                //new Employees("Isabella Davis,96,Sales,+1 678-901-2345,1981-08-10"),
                //new Employees("Ethan Adams,97,Operations,+1 789-012-3456,1990-05-27"),
                //new Employees("Sophia Evans,98,Research,+1 890-123-4567,1983-02-12"),
                //new Employees("Benjamin Baker,99,Engineering,+1 901-234-5678,1975-09-29"),
                //new Employees("Emma Turner,100,Product Development,+1 012-345-6789,1988-07-15"),
                //new Employees("Noah Thompson,101,Management,+1 123-456-7890,1983-12-17"),
                //new Employees("Mia Miller,102,HR,+1 234-567-8901,1997-09-02"),
                //new Employees("Liam Davis,103,Finance,+1 345-678-9012,1971-05-19"),
                //new Employees("Ella Clark,104,Marketing,+1 456-789-0123,1989-02-05")
            });

            modelBuilder.Entity<Rent>().HasData(new Rent[]
            {
                new Rent("1,2020-9-11,Lily Parker,1"),
                new Rent("3,2012-10-11,Maxwell Foster,2"),
                new Rent("11,2002-01-11,Ella Clark,3"),
                new Rent("5,2015-04-25,James Martinez,10"),
                new Rent("5,2015-04-25,James Martinez,10")
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
                new CarBrand("9,Honda"),
                new CarBrand("10,Toyota"),
                new CarBrand("11,Honda"),
                new CarBrand("12,Audi"),

        });

        }




    }
}
