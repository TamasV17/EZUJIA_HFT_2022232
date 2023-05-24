using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Repository
{
    public class CarsRepository : Repository<Cars>
    {
        public CarsRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public override Cars Read(int id)
        {
            return this.ctx.cars.FirstOrDefault(t => t.CarsId == id);
        }

        public override void Update(Cars id)
        {
            var olditem = Read(id.CarsId);
            foreach (var item in olditem.GetType().GetProperties())
            {
                if (item.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    item.SetValue(olditem, item.GetValue(id));
                }
            }
            ctx.SaveChanges();
        }
        }
    }
