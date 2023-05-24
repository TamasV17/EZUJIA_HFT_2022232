using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Logic
{
    public class RentLogic : IRentLogic
    {
        IRepository<Rent> repo;
        public RentLogic(IRepository<Rent> repo)
        {
            this.repo = repo;
        }
        public void Create(Rent item)
        {
            var olditem = repo.ReadAll().FirstOrDefault(t => t.RentId == item.RentId);
            if (olditem != null)
            {
                throw new ArgumentException("The rent already exists!");
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

        public Rent Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new Exception("The rent id does not exist");
            }
            else
            {
                return item;
            }
        }

        public IEnumerable<Rent> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rent item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<string> TheRentsCarBrand()
        {
            var item = from t in repo.ReadAll()
                       select t.cars.CarBrand.Name;

            return item;

        }
       // public record BrandperRentsCount(string brand, int count);
        public IEnumerable<BrandperRentsCount> BrandperRentsCountsMethod()
        {
            var item = from t in repo.ReadAll()
                       group t by t.cars.CarBrand.Name into g
                       select new BrandperRentsCount(g.Key, g.Count());

            return item;
        }
        public class BrandperRentsCount
        {
            public string brand { get; set; }

            public int count { get; set; }

            public BrandperRentsCount(string brand, int count)
            {
                this.brand = brand;
                this.count = count;
            }
        }

    }
}
