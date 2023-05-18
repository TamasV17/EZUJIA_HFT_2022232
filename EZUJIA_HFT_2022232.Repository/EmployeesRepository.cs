using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Repository
{
    class EmployeesRepository : Repository<Employees>
    {
        public EmployeesRepository(MyDbContext ctx)
        {
        }

        public override Employees Read(int id)
        {
            return this.ctx.employees.FirstOrDefault(t => t.EmployeesID == id);
        }

        public override void Update(Employees id)
        {
            var olditem = Read(id.EmployeesID);
            foreach (var item in olditem.GetType().GetProperties())
            {
                item.SetValue(olditem, item.GetValue(id));
            }
        }
    }
}
