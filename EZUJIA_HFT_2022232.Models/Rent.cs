using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }

        public string RentTime { get; set; }

        public string OwnerName { get; set; }
      
        public int CarsId { get; set; }
        public virtual Cars CarId { get; private set; }
        [JsonIgnore]
        public virtual Cars cars { get; set; }

        public Rent(string path)
        {
            string[] array = path.Split(',');
            RentId = int.Parse(array[0]);
            RentTime = array[1];
            OwnerName = array[2];
            CarsId = int.Parse(array[3]);
        }
        public Rent()
        {

        }
    }
}
