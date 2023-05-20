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
        public void Create(Rent item)
        {
            this.repo.Create(item);
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
                throw new Exception("The rent id not exists");
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
    }
}
