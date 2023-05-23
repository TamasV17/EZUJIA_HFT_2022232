using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EZUJIA_HFT_2022232.Logic.CarsLogic;

namespace EZUJIA_HFT_2022232.Logic
{
    public interface ICarLogic
    {
        void Create(Cars item);

        void Delete(int id);

        Cars Read(int id);

        IEnumerable<Cars> ReadAll();

        void Update(Cars item);
        TheMostFamous TheMostFamousBrand();
        IEnumerable<AvarageCarHP> AvarageHPperCar();
    }
}
