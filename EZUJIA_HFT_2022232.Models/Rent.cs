using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Models
{
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }

        public string RentTime { get; set; }


        public int RentcarId { get; set; }

        public int EmployeesID { get; set; }

        public virtual Cars CarId { get; private set; }

        public virtual Employees Employees { get; private set; }

    }
}
