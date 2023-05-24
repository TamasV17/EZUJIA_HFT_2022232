﻿using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EZUJIA_HFT_2022232.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        ICarBrandLogic logic;

        public CarBrandController(ICarBrandLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<CarBrandController>
        [HttpGet]
        public IEnumerable<CarBrand> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<CarBrandController>/5
        [HttpGet("{id}")]
        public CarBrand Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<CarBrandController>
        [HttpPost]
        public void Create([FromBody] CarBrand value)
        {
            logic.Create(value);
        }

        // PUT api/<CarBrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CarBrand value)
        {
            logic.Update(value);
        }

        // DELETE api/<CarBrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
