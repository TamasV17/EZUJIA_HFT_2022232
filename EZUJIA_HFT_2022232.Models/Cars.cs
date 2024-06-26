﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EZUJIA_HFT_2022232.Models
{
    public class Cars
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarsId { get; set; }

        public string Type { get; set; }
        public int CarBrandId { get; set; }

        public string LicensePlateNumber { get; set; }

        public int Year { get; set; }

        public int PerformanceInHP { get; set; }
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Rent> AllRents { get; set; }
        [JsonIgnore]
        public virtual CarBrand CarBrand { get; set; }
        public Cars(string path)
        {
            string[] splitarray = path.Split(',');

            CarBrandId = int.Parse(splitarray[0]);
            CarsId = int.Parse(splitarray[1]);
            Type = splitarray[2];
            LicensePlateNumber = splitarray[3];
            Year = int.Parse(splitarray[4]);
            PerformanceInHP = int.Parse(splitarray[5]);
            this.AllRents = new HashSet<Rent>();

        }
        public Cars()
        {
            this.AllRents = new HashSet<Rent>();

        }
        public override bool Equals(object obj)
        {
            Cars b = obj as Cars;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.CarsId == b.CarsId;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.CarsId);
        }


    }
}
