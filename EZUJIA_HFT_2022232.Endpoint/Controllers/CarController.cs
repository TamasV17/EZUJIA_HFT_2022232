using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EZUJIA_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        ICarLogic logic;

        public CarController(ICarLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Cars> Get()
        {
            return this.logic.ReadAll();
        }


        [HttpGet("{id}")]
        public Cars Get(int id)
        {
            return this.logic.Read(id);

        }


        [HttpPost]
        public void Post([FromBody] Cars value)
        {
            this.logic.Create(value);
        }


        [HttpPut("{id}")]
        public void Put([FromBody] Cars value)
        {
            this.logic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
