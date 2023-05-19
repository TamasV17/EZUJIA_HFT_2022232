using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EZUJIA_HFT_2022232.Models
{
    public class Cars
    {
        public string Brand { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentcarId { get; set; }
        public int CarsID { get; set; }

        public string Type { get; set; }
        public int CarBrandId { get; set; }

        public string LicensePlateNumber { get; set; }

        public int Year { get; set; }

        public int PerformanceInHP { get; set; }

        //public int EmployeesId { get; set; }

        public virtual ICollection<Rent> AllRents { get; set; }
        public Cars(string path)
        {
            string[] splitarray = path.Split(',');

            CarBrandId = int.Parse(splitarray[0]);
            CarsID = int.Parse(splitarray[1]);
            Type = splitarray[2];
            LicensePlateNumber = splitarray[3];
            Year = int.Parse(splitarray[4]);
            PerformanceInHP = int.Parse(splitarray[5]);
            this.AllRents = new HashSet<Rent>();

        }
        public Cars()
        {
            //Owner = new HashSet<Employees>();
        }

    }
}
