using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_2022232.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Logic
{
    class EmployeesLogic : IEmployeesLogic
    {
        IRepository<Employees> repo;
        public void Create(Employees item)
        {
            if (item.Name.Length < 5)
            {
                throw new Exception("The name is too short");
            }
            else
            {
                repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Employees Read(int id)
        {
            var item = this.repo.Read(id);
            if (item == null)
            {
                throw new Exception("The employee you entered not exists");
            }
            else
            {
                return item;
            }
        }

        public IEnumerable<Employees> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Employees item)
        {
            this.repo.Update(item);
        }
    }
}
