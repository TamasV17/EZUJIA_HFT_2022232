using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Logic
{
    interface IEmployeesLogic
    {
        void Create(Employees item);

        void Delete(int id);

        void Update(Employees item);

        Employees Read(int id);

        IEnumerable<Employees> ReadAll();
    }
}
