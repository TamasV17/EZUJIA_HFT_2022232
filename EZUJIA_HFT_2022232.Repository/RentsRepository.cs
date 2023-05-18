using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Repository
{
    class RentsRepository : Repository<Rent>
    {
        public RentsRepository(MyDbContext ctx)
        {
        }

        public override Rent Read(int id)
        {
            return ctx.rents.FirstOrDefault(t => t.RentId == id);
        }

        public override void Update(Rent id)
        {
            var olditem = Read(id.RentId);
            foreach (var item in olditem.GetType().GetProperties())
            {
                item.SetValue(olditem, item.GetValue(id));
            }
        }
    }
}
