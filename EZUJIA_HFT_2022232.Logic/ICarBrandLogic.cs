using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Logic
{
    interface ICarBrandLogic
    {
        void Create(CarBrand item);

        void Update(CarBrand item);

        void Delete(int id);

        CarBrand Read(int id);

        IEnumerable<CarBrand> ReadAll();
    }
}
