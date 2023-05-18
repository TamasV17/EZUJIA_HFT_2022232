﻿using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Repository
{
    public class CarsRepository : Repository<Cars>
    {
        public CarsRepository(MyDbContext ctx)
        {
        }

        public override Cars Read(int id)
        {
            return this.ctx.cars.FirstOrDefault(t => t.RentcarId == id);
        }

        public override void Update(Cars id)
        {
            var olditem = Read(id.CarsID);
            foreach (var item in olditem.GetType().GetProperties())
            {
                item.SetValue(olditem, item.GetValue(id));
            }
        }
    }
}
