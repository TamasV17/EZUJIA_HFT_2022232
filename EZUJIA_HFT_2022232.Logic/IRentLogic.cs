using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Logic
{
    public interface IRentLogic
    {
        void Create(Rent item);

        void Update(Rent item);

        void Delete(int id);

        Rent Read(int id);

        IEnumerable<Rent> ReadAll();
        IEnumerable<string> TheRentsCarBrand();
        IEnumerable<BrandperRentsCount> BrandperRentsCountsMethod();
    }
}
