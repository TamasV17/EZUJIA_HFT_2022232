﻿using EZUJIA_HFT_2022232.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZUJIA_HFT_2022232.Repository
{
    public class CarBrandRepository : Repository<CarBrand>
    {

        public CarBrandRepository(MyDbContext ctx) : base(ctx)
        {
        }

        public override CarBrand Read(int id)
        {
            return this.ctx.carbrand.FirstOrDefault(t => t.CarBrandID == id);
        }

        public override void Update(CarBrand id)
        {
            var olditem = Read(id.CarBrandID);
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
