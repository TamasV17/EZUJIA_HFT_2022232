using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Logic
{
    public class CarBrandLogic : ICarBrandLogic
    {
        IRepository<CarBrand> repo;
        public CarBrandLogic(IRepository<CarBrand> repo)
        {
            this.repo = repo;
        }
        public void Create(CarBrand item)
        {
            var olditem = repo.ReadAll().FirstOrDefault(t => t.CarBrandID == item.CarBrandID);
            if (olditem != null)
            {
                throw new ArgumentException("The Carbrand already exists!");
            }
            else
            {
                this.repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public CarBrand Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new Exception("The carbrand id does not exist");
            }
            else
            {
                return item;
            }
        }

        public IEnumerable<CarBrand> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(CarBrand item)
        {
            this.repo.Update(item);

        }
    }
}
