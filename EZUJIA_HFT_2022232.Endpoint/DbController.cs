using EZUJIA_HFT_2022232.Logic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace EZUJIA_HFT_2022232.Endpoint
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]/[actions]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        ICarLogic carslogic;

        public DbController(ICarLogic carslogic)
        {
            this.carslogic = carslogic;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public IEnumerable<int> TheMostFamousBrand()
        {
            return carslogic.TheMostFamousBrand();
        }
    }
}
