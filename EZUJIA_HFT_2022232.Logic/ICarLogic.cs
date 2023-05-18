using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Logic
{
    interface ICarLogic
    {
        void Create(Cars item);

        void Delete(int id);

        Cars Read(int id);

        IEnumerable<Cars> ReadAll();

        void Update(Cars item);
    }
}
