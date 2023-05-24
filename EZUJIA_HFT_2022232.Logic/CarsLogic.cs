using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EZUJIA_HFT_2022232.Logic
{
    public class CarsLogic : ICarLogic
    {
        IRepository<Cars> repo;
        IRepository<CarBrand> carbranrepo;

        public CarsLogic(IRepository<Cars> repo)
        {
            this.repo = repo;
        }

        public void Create(Cars item)
        {
            if (item.Year < 1950)
            {
                throw new ArgumentException("The year is too short!");
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

        public Cars Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("The car you entered does not exists!");
            }
            else
            {
                return item;
            }
        }

        public IEnumerable<Cars> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Cars item)
        {
            this.repo.Update(item);
        }
        public record TheMostFamous(string name, int count);
        public TheMostFamous TheMostFamousBrand()
        {
            var item = (from t in repo.ReadAll()
                        group t by t.CarBrand.Name into g
                        orderby g.Count() descending
                        select new TheMostFamous(g.Key,g.Count())).First();

            return item;


        }
        public record AvarageCarHP(string name, double avarage);

        public IEnumerable<AvarageCarHP> AvarageHPperCar()
        {

            var item = from t in repo.ReadAll()
                       group t by t.CarBrand.Name into g
                       select new AvarageCarHP(g.Key, g.Average(t => t.PerformanceInHP));

            return item;
        }
    }
}
