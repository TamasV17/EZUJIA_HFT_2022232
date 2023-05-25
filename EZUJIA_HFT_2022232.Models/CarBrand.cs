﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Models
{
    public class CarBrand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarBrandID { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Cars> Cars { get; set; }
        public CarBrand(string path)
        {
            string[] array = path.Split(',');
            this.CarBrandID = int.Parse(array[0]);
            this.Name = array[1];
            this.Cars = new HashSet<Cars>();

        }
        public CarBrand()
        {
            this.Cars = new HashSet<Cars>();
        }
    }
}

